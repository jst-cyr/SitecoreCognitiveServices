﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.Recommendations
{
    public class ErrorDetails
    {
        public string ErrorCode { get; set; }
        public string ErrorText { get; set; }
        public List<ErrorLines> SampleErrorLines { get; set; }
    }
}