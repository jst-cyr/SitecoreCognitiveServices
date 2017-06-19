﻿using System;

namespace Microsoft.SharedSource.CognitiveServices.Models.Vision.Video
{
    public class MotionDetectionResult
    {
        public string Status { get; set; }
        public int Progress { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime LastActionDateTime { get; set; }
        public MotionDetectionAnalysis ProcessingResult { get; set; }
    }
}