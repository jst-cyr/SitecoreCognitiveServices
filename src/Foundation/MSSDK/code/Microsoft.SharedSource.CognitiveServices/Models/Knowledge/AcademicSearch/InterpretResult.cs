﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch {
    public class InterpretResult
    {
        public float LogProb { get; set; }
        public string Parse { get; set; }
        public List<InterpretRule> Rules { get; set; }
    }
}