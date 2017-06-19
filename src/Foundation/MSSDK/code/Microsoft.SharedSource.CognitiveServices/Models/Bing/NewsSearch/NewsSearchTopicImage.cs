﻿using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Bing.NewsSearch {
    public class NewsSearchTopicImage {
        public string Url { get; set; }
        public List<NewsProvider> Provider { get; set; }
    }
}