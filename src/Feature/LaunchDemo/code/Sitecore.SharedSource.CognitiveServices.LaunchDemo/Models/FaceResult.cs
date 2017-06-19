﻿using Microsoft.SharedSource.CognitiveServices.Models.Vision.Face;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class FaceResult
    {
        public Face[] Result { get; set; }
        public string ImageUrl { get; set; }
    }
}