﻿using System.Collections.Generic;
using System.IO;
using Sitecore.SharedSource.CognitiveServices.Models.Vision.ContentModerator;

namespace Sitecore.SharedSource.CognitiveServices.Services.Vision
{
    public interface IContentModeratorService
    {
        EvaluateResponse Evaluate(string imageUrl);
        EvaluateResponse Evaluate(Stream stream);
        FindFacesResponse FindFaces(string imageUrl);
        FindFacesResponse FindFaces(Stream stream);
        MatchResponse Match(string imageUrl, string listId = "");
        MatchResponse Match(Stream stream, string listId = "");
        OCRResult OCR(string imageUrl, string language = "", bool enhanced = false);
        OCRResult OCR(Stream stream, string language = "", bool enhanced = false);
        DetectLanguageResponse DetectLanguage(string text);
        ScreenResponse Screen(string text, string language = "eng", bool autocorrect = false, bool urls = false, bool PII = false, string listId = "");
        CreateJobResponse CreateImageJob(string imageUrl, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        CreateJobResponse CreateImageJob(Stream stream, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        CreateJobResponse CreateTextJob(string text, string teamName, string contentId, string workflowName, string callbackEndpoint = "");
        GetJobResponse GetJob(string teamName, string jobId);
        List<string> CreateReview(string teamName, List<ReviewRequest> requests, string subTeam = "");
        GetReviewResponse GetReview(string teamName, string reviewId);
        void CreateOrUpdateWorkflow(string teamName, string workflowName, WorkflowExpression expression);
        WorkflowExpression GetWorkflow(string teamName, string workflowName);
        List<WorkflowExpression> GetAllWorkflows(string teamName);
    }
}