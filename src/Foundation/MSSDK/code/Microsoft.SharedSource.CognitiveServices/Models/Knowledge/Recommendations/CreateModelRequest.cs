﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class CreateModelRequest
    {
        public string ModelName { get; set; }
        public string Description { get; set; }
    }
}