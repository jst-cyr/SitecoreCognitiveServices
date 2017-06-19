﻿

using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.EntityLinking;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models {
    public interface ILinkAnalysisResult
    {
        string FieldName { get; set; }
        string FieldValue { get; set; }
        EntityLink[] EntityAnalysis { get; set; }
        string HighlightLinks(string htmlEntity, string cssClass, double scoreThreshold);
    }
}