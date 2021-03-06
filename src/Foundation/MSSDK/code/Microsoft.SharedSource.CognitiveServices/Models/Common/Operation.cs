﻿using Microsoft.SharedSource.CognitiveServices.Enums;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Common {
    public class Operation {
        [JsonConverter(typeof(StringEnumConverter))]
        public Status Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime LastActionDateTime { get; set; }

        public string Message { get; set; }
    }
}
