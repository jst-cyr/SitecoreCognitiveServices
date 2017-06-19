﻿using Microsoft.Extensions.DependencyInjection;
using Microsoft.SharedSource.CognitiveServices;
using Microsoft.SharedSource.CognitiveServices.CSV;
using Microsoft.SharedSource.CognitiveServices.Repositories;
using Microsoft.SharedSource.CognitiveServices.Repositories.Bing;
using Microsoft.SharedSource.CognitiveServices.Repositories.Knowledge;
using Microsoft.SharedSource.CognitiveServices.Repositories.Language;
using Microsoft.SharedSource.CognitiveServices.Repositories.Speech;
using Microsoft.SharedSource.CognitiveServices.Repositories.Vision;
using Sitecore.DependencyInjection;
using Sitecore.SharedSource.CognitiveServices.Repositories;
using Sitecore.SharedSource.CognitiveServices.Services.Knowledge;
using Sitecore.SharedSource.CognitiveServices.Services.Language;
using Sitecore.SharedSource.CognitiveServices.Services.Speech;
using Sitecore.SharedSource.CognitiveServices.Services.Vision;
using Sitecore.SharedSource.CognitiveServices.Services.Bing;
using Sitecore.SharedSource.CognitiveServices.Wrappers;

namespace Sitecore.SharedSource.CognitiveServices.App_Start
{
    public class IocConfig : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            //system
            serviceCollection.AddSingleton<IApplicationSettings, ApplicationSettings>();
            serviceCollection.AddSingleton<IApiKeys, ApiKeys>();
            serviceCollection.AddTransient<IRepositoryClient, RepositoryClient>();
            serviceCollection.AddTransient<ICSVParser, CSVParser>();

            //sitecore wrappers
            serviceCollection.AddTransient<ISitecoreDataWrapper, SitecoreDataWrapper>();
            serviceCollection.AddTransient<IWebUtilWrapper, WebUtilWrapper>();
            serviceCollection.AddTransient<ILogWrapper, LogWrapper>();
            serviceCollection.AddTransient<ITextTranslatorWrapper, TextTranslatorWrapper>();
            serviceCollection.AddTransient<IPublishWrapper, PublishWrapper>();

            //repositories
            serviceCollection.AddTransient<IEmotionRepository, EmotionRepository>();
            serviceCollection.AddTransient<IEntityLinkingRepository, EntityLinkingRepository>();
            serviceCollection.AddTransient<IFaceRepository, FaceRepository>();
            serviceCollection.AddTransient<ILinguisticRepository, LinguisticRepository>();
            serviceCollection.AddTransient<ITextAnalyticsRepository, TextAnalyticsRepository>();
            serviceCollection.AddTransient<ISpeakerIdentificationRepository, SpeakerIdentificationRepository>();
            serviceCollection.AddTransient<ISpeakerVerificationRepository, SpeakerVerificationRepository>();
            serviceCollection.AddTransient<IVideoRepository, VideoRepository>();
            serviceCollection.AddTransient<IVisionRepository, VisionRepository>();
            serviceCollection.AddTransient<IAutoSuggestRepository, AutoSuggestRepository>();
            serviceCollection.AddTransient<IImageSearchRepository, ImageSearchRepository>();
            serviceCollection.AddTransient<ISpellCheckRepository, SpellCheckRepository>();
            serviceCollection.AddTransient<IWebSearchRepository, WebSearchRepository>();
            serviceCollection.AddTransient<INewsSearchRepository, NewsSearchRepository>();
            serviceCollection.AddTransient<IVideoSearchRepository, VideoSearchRepository>();
            serviceCollection.AddTransient<IAcademicSearchRepository, AcademicSearchRepository>();
            serviceCollection.AddTransient<IRecommendationsRepository, RecommendationsRepository>();
            serviceCollection.AddTransient<IContentModeratorRepository, ContentModeratorRepository>();
            serviceCollection.AddTransient<IWebLanguageModelRepository, WebLanguageModelRepository>();
            serviceCollection.AddTransient<ILuisRepository, LuisRepository>();
            serviceCollection.AddTransient<ISpeechRepository, SpeechRepository>();
            serviceCollection.AddTransient<IQnAMakerRepository, QnAMakerRepository>();

            //services
            serviceCollection.AddTransient<IEmotionService, EmotionService>();
            serviceCollection.AddTransient<IEntityLinkingService, EntityLinkingService>();
            serviceCollection.AddTransient<IFaceService, FaceService>();
            serviceCollection.AddTransient<ILinguisticService, LinguisticService>();
            serviceCollection.AddTransient<ITextAnalyticsService, TextAnalyticsService>();
            serviceCollection.AddTransient<ISpeakerIdentificationService, SpeakerIdentificationService>();
            serviceCollection.AddTransient<ISpeakerVerificationService, SpeakerVerificationService>();
            serviceCollection.AddTransient<IVideoService, VideoService>();
            serviceCollection.AddTransient<IVisionService, VisionService>();
            serviceCollection.AddTransient<IAutoSuggestService, AutoSuggestService>();
            serviceCollection.AddTransient<IImageSearchService, ImageSearchService>();
            serviceCollection.AddTransient<ISpellCheckService, SpellCheckService>();
            serviceCollection.AddTransient<IWebSearchService, WebSearchService>();
            serviceCollection.AddTransient<INewsSearchService, NewsSearchService>();
            serviceCollection.AddTransient<IVideoSearchService, VideoSearchService>();
            serviceCollection.AddTransient<IAcademicSearchService, AcademicSearchService>();
            serviceCollection.AddTransient<IRecommendationsService, RecommendationsService>();
            serviceCollection.AddTransient<IContentModeratorService, ContentModeratorService>();
            serviceCollection.AddTransient<IWebLanguageModelService, WebLanguageModelService>();
            serviceCollection.AddTransient<ILuisService, LuisService>();
            serviceCollection.AddTransient<ISpeechService, SpeechService>();
            serviceCollection.AddTransient<IQnAMakerService, QnAMakerService>();
        }
    }
}