﻿using Newtonsoft.Json;
using System.Collections.Generic;

namespace Microsoft.SharedSource.CognitiveServices.Models.Language.Linguistic {
    public class ResultSet {
        [JsonProperty("Len")]
        public string Len { get; set; }
        [JsonProperty("Offset")]
        public int Offset { get; set; }
        [JsonProperty("Tokens")]
        public List<TokenResult> Tokens { get; set; }
    }
}