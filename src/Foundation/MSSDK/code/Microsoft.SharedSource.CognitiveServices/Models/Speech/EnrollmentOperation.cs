﻿using Microsoft.SharedSource.CognitiveServices.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Speech {
    public class EnrollmentOperation : Operation {
        public Enrollment ProcessingResult { get; set; }
    }
}
