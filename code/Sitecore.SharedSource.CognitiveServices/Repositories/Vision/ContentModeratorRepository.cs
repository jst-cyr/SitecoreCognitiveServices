﻿extern alias MicrosoftProjectOxfordCommon;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Microsoft.ProjectOxford.Text.Core;
using Newtonsoft.Json;
using Sitecore.SharedSource.CognitiveServices.Models;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Vision {
    public class ContentModeratorRepository : TextClient, IContentModeratorRepository
    {
        //documentation
        //https://www.microsoft.com/cognitive-services/en-us/content-moderator/documentation/review-api-authentication#request-samples
        //moderate
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf753a3f9b070c105bd2c1/operations/57cf753a3f9b070868a1f66c/console
        //review
        //https://westus.dev.cognitive.microsoft.com/docs/services/580519463f9b070e5c591178/operations/580519483f9b0709fc47f9c5
        //list management
        //https://westus.dev.cognitive.microsoft.com/docs/services/57cf755e3f9b070c105bd2c2/operations/57cf755e3f9b070868a1f675

        protected static readonly string moderatorUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/moderate/v1.0";
        protected static readonly string reviewUrl = "https://westus.api.cognitive.microsoft.com/contentmoderator/review/v1.0/teams/";

        protected static readonly string moderateSessionTokenKey = "ModerateSessionTokenKey";

        protected readonly IApiKeys ApiKeys;
        protected readonly IRepositoryClient RepositoryClient;

        protected HttpContextBase Context { get; set; }

        public ContentModeratorRepository(
            IApiKeys apiKeys,
            IRepositoryClient repoClient,
            HttpContextBase context) : base(apiKeys.ContentModerator)
        {
            ApiKeys = apiKeys;
            RepositoryClient = repoClient;
            Context = context;
        }

        #region Moderate

        #region Evaluate

        private string GetImageUrlData(string imageUrl)
        {
            return $"{{\"DataRepresentation\":\"URL\",\"Value\":\"{imageUrl}\"}}";
        }

        public async Task<EvaluateResponse> EvaluateAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        public async Task<EvaluateResponse> EvaluateAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Evaluate", stream);

            return JsonConvert.DeserializeObject<EvaluateResponse>(response);
        }

        #endregion Evaluate

        #region Find Faces

        public async Task<FindFacesResponse> FindFacesAsync(string imageUrl)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        public async Task<FindFacesResponse> FindFacesAsync(Stream stream)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/FindFaces", stream);

            return JsonConvert.DeserializeObject<FindFacesResponse>(response);
        }

        #endregion Find Faces

        #region Match

        private string GetMatchQuerystring(string listId)
        {
            return string.IsNullOrEmpty(listId) ? "" : $"?listId={listId}";
        }

        public async Task<MatchResponse> MatchAsync(string imageUrl, string listId = "")
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        public async Task<MatchResponse> MatchAsync(Stream stream, string listId = "")
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/Match{GetMatchQuerystring(listId)}", stream);

            return JsonConvert.DeserializeObject<MatchResponse>(response);
        }

        #endregion Match

        #region OCR

        private string GetOCRQuerystring(string language, bool enhanced)
        {
            StringBuilder sb = new StringBuilder();

            if (!string.IsNullOrEmpty(language))
                sb.Append($"?language={language}");

            if (enhanced)
            {
                var concat = (sb.Length > 0) ? "&" : "?";
                sb.Append($"{concat}enhanced={enhanced}");
            }

            return sb.ToString();
        }

        public async Task<OCRResult> OCRAsync(string imageUrl, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendJsonPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", GetImageUrlData(imageUrl));

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        public async Task<OCRResult> OCRAsync(Stream stream, string language = "", bool enhanced = false)
        {
            var response = await RepositoryClient.SendImagePostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessImage/OCR{GetOCRQuerystring(language, enhanced)}", stream);

            return JsonConvert.DeserializeObject<OCRResult>(response);
        }

        #endregion OCR

        #region Detect Language

        public async Task<DetectLanguageResponse> DetectLanguageAsync(string text)
        {
            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessText/DetectLanguage", text);

            return JsonConvert.DeserializeObject<DetectLanguageResponse>(response);
        }

        #endregion Detect Language

        #region Screen

        public async Task<ScreenResponse> ScreenAsync(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "")
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"?language={language}");

            if (autocorrect)
                sb.Append($"&autocorrect={autocorrect}");

            if (urls)
                sb.Append($"&urls={urls}");

            if (PII)
                sb.Append($"&PII={PII}");

            if (!string.IsNullOrEmpty(listId))
                sb.Append($"&listId={listId}");

            var response = await RepositoryClient.SendTextPostAsync(ApiKeys.ContentModerator, $"{moderatorUrl}/ProcessText/Screen{sb}", text);

            return JsonConvert.DeserializeObject<ScreenResponse>(response);
        }

        #endregion Screen

        #endregion Moderate

        #region Review
        
        protected string GetToken()
        { 
            if (Context?.Session?[moderateSessionTokenKey] != null) {
                var sessionToken = (TokenResponse)Context.Session[moderateSessionTokenKey];
                if (sessionToken.Expires_On != null && sessionToken.ExpirationDate >= DateTime.Now)
                    return sessionToken.Access_Token;
            }

            var token = RepositoryClient.SendTokenRequest(ApiKeys.ContentModeratorPrivateKey, ApiKeys.ContentModeratorClientId);
            Context.Session.Add(moderateSessionTokenKey, token);

            return token.Access_Token;
        }

        #region Create Job

        private string GetCreateJobQuerystring(string callbackEndpoint)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(callbackEndpoint))
                sb.Append($"&CallBackEndpoint={callbackEndpoint}");

            return sb.ToString();
        }

        private string GetCreateJobData(string content)
        {
            return $"{{ \"ContentValue\": \"{content}\" }}";
        }

        public async Task<CreateJobResponse> CreateImageJobAsync(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator, 
                $"{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}", 
                GetCreateJobData(imageUrl), 
                "application/json", 
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public async Task<CreateJobResponse> CreateImageJobAsync(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/jobs?ContentType=Image&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                RepositoryClient.GetStreamString(stream),
                "image/jpeg",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        public async Task<CreateJobResponse> CreateTextJobAsync(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "")
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/jobs?ContentType=Text&ContentId={contentId}&WorkflowName={workflowName}{GetCreateJobQuerystring(callbackEndpoint)}",
                GetCreateJobData(text),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<CreateJobResponse>(response);
        }

        #endregion Create Job

        #region Get Job

        public async Task<GetJobResponse> GetJobAsync(string teamName, string jobId)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/jobs/{jobId}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetJobResponse>(response);
        }

        #endregion Get Job

        #region Create Review

        public async Task<List<string>> CreateReviewAsync(string teamName, List<ReviewRequest> requests, string subTeam = "")
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(subTeam))
                sb.Append($"?subTeam={subTeam}");
            
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/reviews{sb}",
                JsonConvert.SerializeObject(requests),
                "application/json",
                "POST",
                GetToken());

            return JsonConvert.DeserializeObject<List<string>>(response);
        }

        #endregion Create Review

        #region Get Review

        public async Task<GetReviewResponse> GetReviewAsync(string teamName, string reviewId)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/reviews/{reviewId}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<GetReviewResponse>(response);
        }

        #endregion Get Review

        #region Create or Update Workflow

        public async Task CreateOrUpdateWorkflowAsync(string teamName, string workflowName, WorkflowExpression expression)
        {
            var response = await RepositoryClient.SendAsync(
                ApiKeys.ContentModerator,
                $"{reviewUrl}{teamName}/workflows/{workflowName}",
                JsonConvert.SerializeObject(expression),
                "application/json",
                "PUT",
                GetToken());
        }

        #endregion Create or Update Workflow

        #region Get Workflow

        public async Task<WorkflowExpression> GetWorkflowAsync(string teamName, string workflowName)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/workflows/{workflowName}", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<WorkflowExpression>(response);
        }

        public async Task<List<WorkflowExpression>> GetAllWorkflowsAsync(string teamName)
        {
            var response = await RepositoryClient.SendAsync(ApiKeys.ContentModerator, $"{reviewUrl}{teamName}/workflows", "", "application/json", "GET", GetToken());

            return JsonConvert.DeserializeObject<List<WorkflowExpression>>(response);
        }

        #endregion Get Workflow

        #endregion Review

        #region List Management

        #endregion List Management
    }
}