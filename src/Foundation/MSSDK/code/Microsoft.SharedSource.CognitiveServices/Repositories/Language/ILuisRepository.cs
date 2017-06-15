﻿using Microsoft.SharedSource.CognitiveServices.Models.Language.Luis;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Repositories.Language { 
    public interface ILuisRepository
    {
        QueryResult Query(Guid appId, string query);
        Task<QueryResult> QueryAsync(Guid appId, string query);
        string AddApplication(AddApplicationRequest request);
        Task<string> AddApplicationAsync(AddApplicationRequest request);
        void DeleteApplication(Guid appId);
        Task DeleteApplicationAsync(Guid appId);
        List<List<string>> DownloadApplicationQueryLogs(Guid appId);
        Task<List<List<string>>> DownloadApplicationQueryLogsAsync(Guid appId);
        List<ApplicationCulture> GetApplicationCultures();
        Task<List<ApplicationCulture>> GetApplicationCulturesAsync();
        List<string> GetApplicationDomains();
        Task<List<string>> GetApplicationDomainsAsync();
        ApplicationInfo GetApplicationInfo(Guid appId);
        Task<ApplicationInfo> GetApplicationInfoAsync(Guid appId);
        List<string> GetApplicationUsageScenarios();
        Task<List<string>> GetApplicationUsageScenariosAsync();
        PersonalAssistantResponse GetPersonalAssistantApplications();
        Task<PersonalAssistantResponse> GetPersonalAssistantApplicationsAsync();
        List<UserApplication> GetUserApplications(int skip = 0, int take = 100);
        Task<List<UserApplication>> GetUserApplicationsAsync(int skip = 0, int take = 100);
        string ImportApplication(ApplicationDefinition request, string appName = "");
        Task<string> ImportApplicationAsync(ApplicationDefinition request, string appName = "");
        PublishResponse PublishApplication(Guid appId, PublishRequest request);
        Task<PublishResponse> PublishApplicationAsync(Guid appId, PublishRequest request);
        void RenameApplication(Guid appId, ApplicationRenameRequest request);
        Task RenameApplicationAsync(Guid appId, ApplicationRenameRequest request);
        AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request);
        Task<AddLabelResponse> AddLabelAsync(Guid appId, string versionId, AddLabelRequest request);
        List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request);
        Task<List<BatchAddLabelsResponse>> BatchAddLabelsAsync(Guid appId, string versionId, List<AddLabelRequest> request);
        void DeleteExampleLabel(Guid appId, string versionId, int exampleId);
        Task DeleteExampleLabelAsync(Guid appId, string versionId, int exampleId);
        List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<LabeledExamples>> ReviewLabeledExamplesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature);
        Task<int> CreatePatternFeatureAsync(Guid appId, string versionId, PatternFeature feature);
        int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature);
        Task<int> CreatePhraseListFeatureAsync(Guid appId, string versionId, PhraseListFeature feature);
        void DeletePatternFeature(Guid appId, string versionId, int patternId);
        Task DeletePatternFeatureAsync(Guid appId, string versionId, int patternId);
        void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId);
        Task DeletePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId);
        ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<ApplicationFeaturesResponse> GetApplicationVersionFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<PatternFeature>> GetApplicationVersionPatternFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<PhraseListFeature>> GetApplicationVersionPhraseListFeaturesAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId);
        Task<PatternFeature> GetPatternFeatureInfoAsync(Guid appId, string versionId, int patternId);
        PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId);
        Task<PhraseListFeature> GetPhraseListFeatureInfoAsync(Guid appId, string versionId, int phraselistId);
        void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature);
        Task UpdatePatternFeatureAsync(Guid appId, string versionId, int patternId, PatternFeature feature);
        void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature);
        Task UpdatePhraseListFeatureAsync(Guid appId, string versionId, int phraselistId, PhraseListFeature feature);
        List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames);
        Task<List<EntityInfo>> AddPrebuiltEntityExtractorsAsync(Guid appId, string versionId, List<string> extractorNames);
        Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request);
        Task<Guid> CreateClosedListEntityModelAsync(Guid appId, string versionId, ClosedListEntityRequest request);
        Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request);
        Task<Guid> CreateCompositeEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request);
        Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request);
        Task<Guid> CreateEntityExtractorAsync(Guid appId, string versionId, NamedEntityRequest request);
        Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request);
        Task<Guid> CreateHeirarchicalEntityExtractorAsync(Guid appId, string versionId, ComplexEntityRequest request);
        Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request);
        Task<Guid> CreateIntentClassifierAsync(Guid appId, string versionId, NamedEntityRequest request);
        void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId);
        Task DeleteClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId);
        void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId);
        Task DeleteCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId);
        void DeleteEntityModel(Guid appId, string versionId, Guid entityId);
        Task DeleteEntityModelAsync(Guid appId, string versionId, Guid entityId);
        void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId);
        Task DeleteHierarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId);
        void DeleteIntentModel(Guid appId, string versionId, Guid intentId);
        Task DeleteIntentModelAsync(Guid appId, string versionId, Guid intentId);
        void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId);
        Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid prebuiltId);
        void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId);
        Task DeletePrebuiltModelAsync(Guid appId, string versionId, Guid closedListEntityId, int sublistId);
        ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<ClosedListEntityInfo> GetApplicationVersionClosedListInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<ComplexEntityInfo> GetApplicationVersionCompositeEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<ComplexEntityInfo>> GetApplicationVersionHeirarchicalEntityInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionIntentInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionModelInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        Task<List<EntityInfo>> GetApplicationVersionPrebuiltInfosAsync(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId);
        Task<List<PrebuiltEntity>> GetAvailablePrebuiltEntityExtractorsAsync(Guid appId, string versionId);
        ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId);
        Task<ClosedListEntityInfo> GetClosedListEntityInfoAsync(Guid appId, string versionId, Guid closedListEntityId);
        ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId);
        Task<ComplexEntityInfo> GetCompositeEntityInfoAsync(Guid appId, string versionId, Guid compositeEntityId);
        EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId);
        Task<EntityInfo> GetEntityInfoAsync(Guid appId, string versionId, Guid entityId);
        ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId);
        Task<ComplexEntityInfo> GetHeirarchicalEntityInfoAsync(Guid appId, string versionId, Guid heirarchicalEntityId);
        EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId);
        Task<EntityInfo> GetIntentInfoAsync(Guid appId, string versionId, Guid intentId);
        EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId);
        Task<EntityInfo> GetPrebuiltInfoAsync(Guid appId, string versionId, Guid prebuiltId);
        void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request);
        Task PatchClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request);
        void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request);
        Task RenameEntityModelAsync(Guid appId, string versionId, Guid entityId, NamedEntityRequest request);
        void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request);
        Task RenameIntentModelAsync(Guid appId, string versionId, Guid intentId, NamedEntityRequest request);
        List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10);
        Task<List<LabeledExamples>> SuggestEndpointQueriesForEntitiesAsync(Guid appId, string versionId, Guid entityId, int take = 10);
        List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10);
        Task<List<LabeledExamples>> SuggestEndpointQueriesForIntentsAsync(Guid appId, string versionId, Guid intentId, int take = 10);
        void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request);
        Task UpdateClosedListEntityModelAsync(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request);
        void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request);
        Task UpdateCompositeEntityModelAsync(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request);
        void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request);
        Task UpdateHeirarchicalEntityModelAsync(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request);
        List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId);
        Task<List<ModelTrainingStatus>> GetApplicationVersionTrainingStatusAsync(Guid appId, string versionId);
        void TrainApplicationVersion(Guid appId, string versionId);
        Task TrainApplicationVersionAsync(Guid appId, string versionId);
        void AddExternalApiKey(ExternalApiKeyRequest request);
        Task AddExternalApiKeyAsync(ExternalApiKeyRequest request);
        void AddSubscriptionKey(SubscriptionKeySet request);
        Task AddSubscriptionKeyAsync(SubscriptionKeySet request);
        void DeleteExternalApiKey(string externalApiKey);
        Task DeleteExternalApiKeyAsync(string externalApiKey);
        void DeleteSubscriptionKey(string subscriptionKey);
        Task DeleteSubscriptionKeyAsync(string subscriptionKey);
        ExternalApiKeySet GetExternalApiKey();
        Task<ExternalApiKeySet> GetExternalApiKeyAsync();
        List<SubscriptionKeySet> GetSubscriptionKey();
        Task<List<SubscriptionKeySet>> GetSubscriptionKeyAsync();
        string ResetProgrammaticKey();
        Task<string> ResetProgrammaticKeyAsync();
        void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey);
        Task AssignSubscriptionKeyToVersionAsync(Guid appId, string versionId, string subscriptionKey);
        string CloneVersion(Guid appId, string versionId, VersionRequest request);
        Task<string> CloneVersionAsync(Guid appId, string versionId, VersionRequest request);
        void DeleteApplicationVersion(Guid appId, string versionId);
        Task DeleteApplicationVersionAsync(Guid appId, string versionId);
        void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType);
        Task DeleteApplicationVersionExternalKeyAsync(Guid appId, string versionId, string keyType);
        ApplicationDefinition ExportApplicationVersion(Guid appId, string versionId);
        Task<ApplicationDefinition> ExportApplicationVersionAsync(Guid appId, string versionId);
        ApplicationVersion GetApplicationVersion(Guid appId, string versionId);
        Task<ApplicationVersion> GetApplicationVersionAsync(Guid appId, string versionId);
        List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId);
        Task<List<ExternalApiKeySet>> GetApplicationVersionExternalApiKeysAsync(Guid appId, string versionId);
        SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId);
        Task<SubscriptionKeySet> GetApplicationVersionSubscriptionKeysAsync(Guid appId, string versionId);
        List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100);
        Task<List<ApplicationVersion>> GetApplicationVersionsAsync(Guid appId, int skip = 0, int take = 100);
        string ImportVersionToApplication(Guid appId, ApplicationDefinition definition, string versionId = "");
        Task<string> ImportVersionToApplicationAsync(Guid appId, ApplicationDefinition definition, string versionId = "");
        void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request);
        Task RenameApplicationVersionAsync(Guid appId, string versionId, VersionRequest request);
        void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request);
        Task UpdateApplicationVersionExternalKeyAsync(Guid appId, string versionId, ExternalApiKeyRequest request);
    }
}