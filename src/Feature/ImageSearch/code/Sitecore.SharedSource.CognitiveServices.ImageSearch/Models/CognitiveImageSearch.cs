﻿
using System.Collections.Generic;

namespace Sitecore.SharedSource.CognitiveServices.ImageSearch.Models
{
    public class CognitiveImageSearch : ICognitiveImageSearch
    {
        public string Database { get; set; }
        public string Language { get; set; }
        public List<KeyValuePair<string, int>> Tags { get; set; }
    }
}