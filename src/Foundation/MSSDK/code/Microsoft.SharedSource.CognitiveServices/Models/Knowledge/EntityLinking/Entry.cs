﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.SharedSource.CognitiveServices.Models.Knowledge.EntityLinking {
    [DataContract]
    public class Entry {
        [DataMember(Name = "offset")]
        public int Offset { get; set; }

        [DataMember(Name = "score")]
        public double Score { get; set; }
    }
}
