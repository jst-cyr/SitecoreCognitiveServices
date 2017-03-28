﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using log4net.Repository.Hierarchy;
using Sitecore.SharedSource.CognitiveServices.Models.Language.Luis;
using Sitecore.SharedSource.CognitiveServices.Repositories.Language;

namespace Sitecore.SharedSource.CognitiveServices.Services.Language {
    public interface ILuisService
    {
        QueryResult Query(Guid appId, string query);
        string AddApplication(AddApplicationRequest request);
        void DeleteApplication(Guid appId);
        List<List<string>> DownloadApplicationQueryLogs(Guid appId);
        List<ApplicationCulture> GetApplicationCultures();
        List<string> GetApplicationDomains();
        ApplicationInfo GetApplicationInfo(Guid appId);
        List<string> GetApplicationUsageScenarios();
        PersonalAssistantResponse GetPersonalAssistantApplications();
        List<UserApplication> GetUserApplications(int skip = 0, int take = 100);
        string ImportApplication(ApplicationDefinition request, string appName = "");
        PublishResponse PublishApplication(Guid appId, PublishRequest request);
        void RenameApplication(Guid appId, ApplicationRenameRequest request);
        AddLabelResponse AddLabel(Guid appId, string versionId, AddLabelRequest request);
        List<BatchAddLabelsResponse> BatchAddLabels(Guid appId, string versionId, List<AddLabelRequest> request);
        void DeleteExampleLabel(Guid appId, string versionId, int exampleId);
        List<LabeledExamples> ReviewLabeledExamples(Guid appId, string versionId, int skip = 0, int take = 100);
        int CreatePatternFeature(Guid appId, string versionId, PatternFeature feature);
        int CreatePhraseListFeature(Guid appId, string versionId, PhraseListFeature feature);
        void DeletePatternFeature(Guid appId, string versionId, int patternId);
        void DeletePhraseListFeature(Guid appId, string versionId, int phraselistId);
        ApplicationFeaturesResponse GetApplicationVersionFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PatternFeature> GetApplicationVersionPatternFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PhraseListFeature> GetApplicationVersionPhraseListFeatures(Guid appId, string versionId, int skip = 0, int take = 100);
        PatternFeature GetPatternFeatureInfo(Guid appId, string versionId, int patternId);
        PhraseListFeature GetPhraseListFeatureInfo(Guid appId, string versionId, int phraselistId);
        void UpdatePatternFeature(Guid appId, string versionId, int patternId, PatternFeature feature);
        void UpdatePhraseListFeature(Guid appId, string versionId, int phraselistId, PhraseListFeature feature);
        List<EntityInfo> AddPrebuiltEntityExtractors(Guid appId, string versionId, List<string> extractorNames);
        Guid CreateClosedListEntityModel(Guid appId, string versionId, ClosedListEntityRequest request);
        Guid CreateCompositeEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request);
        Guid CreateEntityExtractor(Guid appId, string versionId, NamedEntityRequest request);
        Guid CreateHeirarchicalEntityExtractor(Guid appId, string versionId, ComplexEntityRequest request);
        Guid CreateIntentClassifier(Guid appId, string versionId, NamedEntityRequest request);
        void DeleteClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId);
        void DeleteCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId);
        void DeleteEntityModel(Guid appId, string versionId, Guid entityId);
        void DeleteHierarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId);
        void DeleteIntentModel(Guid appId, string versionId, Guid intentId);
        void DeletePrebuiltModel(Guid appId, string versionId, Guid prebuiltId);
        void DeletePrebuiltModel(Guid appId, string versionId, Guid closedListEntityId, int sublistId);
        ClosedListEntityInfo GetApplicationVersionClosedListInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        ComplexEntityInfo GetApplicationVersionCompositeEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<ComplexEntityInfo> GetApplicationVersionHeirarchicalEntityInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionIntentInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionModelInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<EntityInfo> GetApplicationVersionPrebuiltInfos(Guid appId, string versionId, int skip = 0, int take = 100);
        List<PrebuiltEntity> GetAvailablePrebuiltEntityExtractors(Guid appId, string versionId);
        ClosedListEntityInfo GetClosedListEntityInfo(Guid appId, string versionId, Guid closedListEntityId);
        ComplexEntityInfo GetCompositeEntityInfo(Guid appId, string versionId, Guid compositeEntityId);
        EntityInfo GetEntityInfo(Guid appId, string versionId, Guid entityId);
        ComplexEntityInfo GetHeirarchicalEntityInfo(Guid appId, string versionId, Guid heirarchicalEntityId);
        EntityInfo GetIntentInfo(Guid appId, string versionId, Guid intentId);
        EntityInfo GetPrebuiltInfo(Guid appId, string versionId, Guid prebuiltId);
        void PatchClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, PatchClosedListEntityModelRequest request);
        void RenameEntityModel(Guid appId, string versionId, Guid entityId, NamedEntityRequest request);
        void RenameIntentModel(Guid appId, string versionId, Guid intentId, NamedEntityRequest request);
        List<LabeledExamples> SuggestEndpointQueriesForEntities(Guid appId, string versionId, Guid entityId, int take = 10);
        List<LabeledExamples> SuggestEndpointQueriesForIntents(Guid appId, string versionId, Guid intentId, int take = 10);
        void UpdateClosedListEntityModel(Guid appId, string versionId, Guid closedListEntityId, ClosedListEntityRequest request);
        void UpdateCompositeEntityModel(Guid appId, string versionId, Guid compositeEntityId, ComplexEntityRequest request);
        void UpdateHeirarchicalEntityModel(Guid appId, string versionId, Guid heirarchicalEntityId, ComplexEntityRequest request);
        List<ModelTrainingStatus> GetApplicationVersionTrainingStatus(Guid appId, string versionId);
        void TrainApplicationVersion(Guid appId, string versionId);
        void AddExternalApiKey(ExternalApiKeyRequest request);
        void AddSubscriptionKey(SubscriptionKeySet request);
        void DeleteExternalApiKey(string externalApiKey);
        void DeleteSubscriptionKey(string subscriptionKey);
        ExternalApiKeySet GetExternalApiKey();
        List<SubscriptionKeySet> GetSubscriptionKey();
        string ResetProgrammaticKey();
        void AssignSubscriptionKeyToVersion(Guid appId, string versionId, string subscriptionKey);
        string CloneVersion(Guid appId, string versionId, VersionRequest request);
        void DeleteApplicationVersion(Guid appId, string versionId);
        void DeleteApplicationVersionExternalKey(Guid appId, string versionId, string keyType);
        ApplicationDefinition ExportApplicationVersoin(Guid appId, string versionId);
        ApplicationVersion GetApplicationVersion(Guid appId, string versionId);
        List<ExternalApiKeySet> GetApplicationVersionExternalApiKeys(Guid appId, string versionId);
        SubscriptionKeySet GetApplicationVersionSubscriptionKeys(Guid appId, string versionId);
        List<ApplicationVersion> GetApplicationVersions(Guid appId, int skip = 0, int take = 100);
        string GetApplicationVersions(Guid appId, ApplicationDefinition definition, string versionId = "");
        void RenameApplicationVersion(Guid appId, string versionId, VersionRequest request);
        void UpdateApplicationVersionExternalKey(Guid appId, string versionId, ExternalApiKeyRequest request);
    }
}