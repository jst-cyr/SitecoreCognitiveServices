﻿using System;
using System.Threading.Tasks;
using Microsoft.ProjectOxford.Text.Sentiment;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Microsoft.SharedSource.CognitiveServices.Models.Language.Sentiment;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;
using Microsoft.ProjectOxford.Video.Contract;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language
{
    public class SentimentService : ISentimentService
    {
        protected ISentimentRepository SentimentRepository;
        protected ILogWrapper Logger;

        public SentimentService(
            ISentimentRepository sentimentRepository,
            ILogWrapper logger)
        {
            SentimentRepository = sentimentRepository;
            Logger = logger;
        }

        public virtual SentimentResponse GetSentiment(SentimentRequest request)
        {
            try
            {
                var result = SentimentRepository.GetSentiment(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentService.GetSentiment failed", this, ex);
            }

            return null;
        }

        public virtual KeyPhraseSentimentResponse GetKeyPhrases(SentimentRequest request)
        {
            try
            {
                var result = SentimentRepository.GetKeyPhrases(request);

                return result;
            }
            catch (Exception ex)
            {
                Logger.Error("SentimentService.GetKeyPhrasesAsync failed", this, ex);
            }

            return null;
        }

        public virtual string GetTopics(TopicRequest request)
        {
            try {
                var result = SentimentRepository.GetTopics(request);

                return result;
            } catch (Exception ex) {
                Logger.Error("SentimentService.GetTopics failed", this, ex);
            }

            return null;
        }

        public virtual OperationResult GetOperation(string operationLocationUrl)
        {
            try {
                var result = SentimentRepository.GetOperation(operationLocationUrl);

                return result;
            } catch (Exception ex) {
                Logger.Error("SentimentService.GetOperation failed", this, ex);
            }

            return null;
        }
    }
}