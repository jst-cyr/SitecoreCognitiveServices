﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq.Utilities;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Security;
using Sitecore.SharedSource.CognitiveServices.Wrappers;
using Sitecore.Data.Items;
using Sitecore.Data;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Search
{
    public class CognitiveImageSearchContext : ICognitiveImageSearchContext
    {
        protected readonly ISitecoreDataWrapper DataWrapper;
        protected readonly IImageSearchSettings ImageSearchSettings;

        public CognitiveImageSearchContext(
            ISitecoreDataWrapper dataWrapper,
            IImageSearchSettings imageSearchSettings) {
            DataWrapper = dataWrapper;
            ImageSearchSettings = imageSearchSettings;
        }

        public virtual ICognitiveImageSearchResult GetAnalysis(string itemId, string languageCode, string dbName) {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                return context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a =>
                        a.UniqueId.Contains(itemId.ToLower())
                        && a.Language == languageCode)
                    .Take(1)
                    .FirstOrDefault();
            }
        }

        public virtual void AddItemToIndex(string itemId, string dbName) {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            AddItemToIndex(i, dbName);
        }

        public virtual void AddItemToIndex(Item item, string dbName) {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;
            ContentSearchManager.GetIndex(GetIndexName(dbName)).Refresh(tempItem);
        }

        public virtual void UpdateItemInIndex(string itemId, string dbName) {
            ID id = DataWrapper.GetID(itemId);
            if (id.IsNull)
                return;

            Item i = DataWrapper.GetDatabase(dbName).GetItem(id);
            if (i == null)
                return;

            UpdateItemInIndex(i, dbName);
        }

        public virtual void UpdateItemInIndex(Item item, string dbName) {
            if (item == null)
                return;

            var tempItem = (SitecoreIndexableItem)item;

            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));

            index.Update(tempItem.UniqueId);
        }

        protected virtual string GetIndexName(string dbName) {
            if (dbName == null) {
                dbName = "master";
            }
            return string.Format(ImageSearchSettings.IndexNameFormat, dbName);
        }
        
        public virtual List<ICognitiveImageSearchResult> GetMediaResults(Dictionary<string, string[]> tagParameters, Dictionary<string, string[]> rangeParameters, int gender, int glasses, int size, string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck))
            {
                IQueryable<CognitiveImageSearchResult> queryable = context.GetQueryable<CognitiveImageSearchResult>()
                    .Where(a => a.Language == languageCode);
                
                if (gender != 0)
                {
                    queryable = queryable.Where(x => x.Gender == gender);
                }

                if (glasses >= 0)
                {
                    queryable = queryable.Where(x => x.Glasses.Contains(glasses));
                }

                foreach (var parameter in tagParameters)
                {
                    var thisParamPredicate = GetDefaultFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                    {
                        queryable = queryable.Where(thisParamPredicate);
                    }
                }

                var hasAge = rangeParameters.Keys.Any(k => k.StartsWith("age"));
                if (hasAge)
                {
                    var ageKey = rangeParameters.ContainsKey("age_td") ? "age_td" : "age";
                    var age = rangeParameters[ageKey];
                    
                    var min = double.Parse(age[0]);
                    var max = double.Parse(age[1]);

                    if(min > 0d)
                        queryable = queryable.Where(r => r.AgeMin >= min);

                    if(max < 100d)
                        queryable = queryable.Where(r => r.AgeMax <= max);

                    rangeParameters.Remove(ageKey);
                }

                if (size > 0)
                {
                    queryable = queryable.Where(r => r.Size >= size);
                }

                foreach (var parameter in rangeParameters)
                {
                    var thisParamPredicate = GetRangeFilter(parameter.Value, parameter.Key);
                    if (thisParamPredicate != null)
                    {
                        queryable = queryable.Where(thisParamPredicate);
                    }
                }

                return queryable.ToList<ICognitiveImageSearchResult>();
            }
        }

        /// <summary>
        /// Default filters in query predicate
        /// </summary>
        /// <param name="parameterValues"></param>
        /// <param name="fieldName"></param>
        /// <returns></returns>
        public virtual Expression<Func<CognitiveImageSearchResult, bool>> GetDefaultFilter(string[] parameterValues, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || parameterValues == null || !parameterValues.Any())
            {
                return null;
            }

            Expression<Func<CognitiveImageSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveImageSearchResult>();
            foreach (string val in parameterValues.Where(d => !string.IsNullOrEmpty(d)))
            {
                string parameterValue = val;
                innerPredicate = innerPredicate.Or(i => (string)i[(ObjectIndexerKey)fieldName] == parameterValue);
            }

            return innerPredicate;
        }

        public virtual Expression<Func<CognitiveImageSearchResult, bool>> GetRangeFilter(string[] parameterValues, string fieldName)
        {
            if (string.IsNullOrEmpty(fieldName) || !parameterValues.Any())
            {
                return null;
            }

            if (parameterValues[0] == "0" && parameterValues[1] == "100")
            {
                //no need for a query
                return null;
            }

            Expression<Func<CognitiveImageSearchResult, bool>> innerPredicate = PredicateBuilder.True<CognitiveImageSearchResult>();

            //scientific notation
            double min = double.Parse(parameterValues[0]);
            double max = double.Parse(parameterValues[1]);

            if (parameterValues[0] == "0")
            {
                //place limit only on the high end
                return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] <= max);
            }

            if (parameterValues[1] == "100")
            {
                //place limit only on the low end
                return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] >= min);
            }

            return innerPredicate.And(i => (double)i[(ObjectIndexerKey)fieldName] >= min && (double)i[(ObjectIndexerKey)fieldName] <= max);
        }

        public virtual List<KeyValuePair<string, int>> GetTags(string languageCode, string dbName)
        {
            var index = ContentSearchManager.GetIndex(GetIndexName(dbName));
            
            using (var context = index.CreateSearchContext(SearchSecurityOptions.DisableSecurityCheck)) {
                var results = context.GetQueryable<CognitiveImageSearchResult>()
                        .Where(a => a.Language == languageCode)
                        .ToArray();

                var tags = results
                        .Where(x => x.Tags != null)
                        .SelectMany(x => x.Tags)
                        .ToArray();

                return tags.GroupBy(x => x)
                    .Select(x => new KeyValuePair<string, int>(x.Key, x.Count()))
                    .OrderByDescending(x => x.Value)
                    .ToList();
            }
        }
    }
}