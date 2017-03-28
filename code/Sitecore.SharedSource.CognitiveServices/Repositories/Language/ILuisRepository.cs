﻿using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.Repositories.Language { 
    public interface ILuisRepository
    {
        Task<QueryResult> QueryAsync(Guid appId, string query);
        Task<string> AddApplicationAsync(AddApplicationRequest request);
        Task DeleteApplicationAsync(Guid appId);
        Task<List<List<string>>> DownloadApplicationQueryLogsAsync(Guid appId);
        Task<List<ApplicationCulture>> GetApplicationCulturesAsync();
        Task<List<string>> GetApplicationDomainsAsync();
        Task<ApplicationInfo> GetApplicationInfoAsync(Guid appId);
        Task<List<string>> GetApplicationUsageScenariosAsync();
        Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync();
        Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100);
        Task<string> ImportApplicationAsync(ApplicationDefinition request, string appName = "");
        Task<PublishResponse> PublishApplicationAsync(Guid appId, PublishRequest request);
        Task RenameApplicationAsync(Guid appId, ApplicationRenameRequest request);
        Task<AddLabelResponse> AddLabelAsync(Guid appId, string versionId, AddLabelRequest request);
        Task<List<BatchAddLabelsResponse>> BatchAddLabelsAsync(Guid appId, string versionId, List<AddLabelRequest> request);
        Task DeleteExampleLabelAsync(Guid appId, string versionId, int exampleId);
        Task<List<LabeledExamples>> ReviewLabeledExamplesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<int> CreatePatternFeatureAsync(Guid appId, string versionId, PatternFeature feature);
        Task<int> CreatePhraseListFeatureAsync(Guid appId, string versionId, PhraseListFeature feature);
        Task DeletePatternFeatureAsync(Guid appId, string versionId, int patternId);
        Task DeletePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId);
        Task<ApplicationFeaturesResponse> GetApplicationVersionFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<PatternFeature>> GetApplicationVersionPatternFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<PhraseListFeature>> GetApplicationVersionPhraseListFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<PatternFeature> GetPatternFeatureInfoAsync(Guid appId, string versionId, int patternId);
        Task<PhraseListFeature> GetPhraseListFeatureInfoAsync(Guid appId, string versionId, int phraselistId);
        Task UpdatePatternFeatureAsync(Guid appId, string versionId, int patternId, PatternFeature feature);
        Task UpdatePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId, PhraseListFeature feature);
        Task<List<EntityInfo>> AddPrebuiltEntityExtractorsAsync(Guid appId, string versionId, List<string> extractorNames);
        Task<Guid> CreateClosedListEntityModelAsync(Guid appId, string versionId, ClosedListEntityRequest request);
        Task<Guid> CreateCompositeEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request);
        Task<Guid> CreateEntityExtractorAsync(Guid appId, string versionId, NamedEntityRequest request);
        Task<Guid> CreateHeirarchicalEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request);
        Task<Guid> CreateIntentClassifierAsync(Guid appId, string versionId, NamedEntityRequest request);
        Task DeleteClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId);
        Task DeleteCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId);
        Task DeleteEntityModelAsync(Guid appId, string versionId, Guid entityId);
        Task DeleteHierarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId);
        Task DeleteIntentModelAsync(Guid appId, string versionId, Guid intentId);
        Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid prebuiltId);
        Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid closedListEntityId, int sublistId);
        Task<ClosedListEntityInfo> GetApplicationVersionClosedListInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<ComplexEntityInfo> GetApplicationVersionCompositeEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<ComplexEntityInfo>> GetApplicationVersionHeirarchicalEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionIntentInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionModelInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionPrebuiltInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<PrebuiltEntity>> GetAvailablePrebuiltEntityExtractorsAsync(Guid appId, string versionId);
        Task<ClosedListEntityInfo> GetClosedListEntityInfoAsync(Guid appId, string versionId, Guid closedListEntityId);
        Task<ComplexEntityInfo> GetCompositeEntityInfoAsync(Guid appId, string versionId, Guid compositeEntityId);
        Task<EntityInfo> GetEntityInfoAsync(Guid appId, string versionId, Guid entityId);
        Task<ComplexEntityInfo> GetHeirarchicalEntityInfoAsync(Guid appId, string versionId, Guid heirarchicalEntityId);
        Task<EntityInfo> GetIntentInfoAsync(Guid appId, string versionId, Guid intentId);
        Task<EntityInfo> GetPrebuiltInfoAsync(Guid appId, string versionId, Guid prebuiltId);
        Task PatchClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request);
        Task RenameEntityModelAsync(Guid appId, string versionId, Guid entityId, NamedEntityRequest request);
        Task RenameIntentModelAsync(Guid appId, string versionId, Guid intentId, NamedEntityRequest request);
        Task<List<LabeledExamples>> SuggestEndpointQueriesForEntitiesAsync(Guid appId, string versionId, Guid entityId, int take = 10);
        Task<List<LabeledExamples>> SuggestEndpointQueriesForIntentsAsync(Guid appId, string versionId, Guid intentId, int take = 10);
        Task UpdateClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request);
        Task UpdateCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request);
        Task UpdateHeirarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request);
        Task<List<ModelTrainingStatus>> GetApplicationVersionTrainingStatusAsync(Guid appId, string versionId);
        Task TrainApplicationVersionAsync(Guid appId, string versionId);
        Task AddExternalApiKeyAsync(ExternalApiKeyRequest request);
        Task AddSubscriptionKeyAsync(SubscriptionKeySet request);
        Task DeleteExternalApiKeyAsync(string externalApiKey);
        Task DeleteSubscriptionKeyAsync(string subscriptionKey);
        Task<ExternalApiKeySet> GetExternalApiKeyAsync();
        Task<List<SubscriptionKeySet>> GetSubscriptionKeyAsync();
        Task<string> ResetProgrammaticKeyAsync();
        Task AssignSubscriptionKeyToVersionAsync(Guid appId, string versionId, string subscriptionKey);
        Task<string> CloneVersionAsync(Guid appId, string versionId, VersionRequest request);
        Task DeleteApplicationVersionAsync(Guid appId, string versionId);
        Task DeleteApplicationVersionExternalKeyAsync(Guid appId, string versionId, string keyType);
        Task<ApplicationDefinition> ExportApplicationVersoinAsync(Guid appId, string versionId);
        Task<ApplicationVersion> GetApplicationVersionAsync(Guid appId, string versionId);
        Task<List<ExternalApiKeySet>> GetApplicationVersionExternalApiKeysAsync(Guid appId, string versionId);
        Task<SubscriptionKeySet> GetApplicationVersionSubscriptionKeysAsync(Guid appId, string versionId);
        Task<List<ApplicationVersion>> GetApplicationVersionsAsync(Guid appId, int skip = 0, int take = 100);
        Task<string> GetApplicationVersionsAsync(Guid appId, ApplicationDefinition definition, string versionId = "");
        Task RenameApplicationVersionAsync(Guid appId, string versionId, VersionRequest request);
        Task UpdateApplicationVersionExternalKeyAsync(Guid appId, string versionId, ExternalApiKeyRequest request);
    }
}