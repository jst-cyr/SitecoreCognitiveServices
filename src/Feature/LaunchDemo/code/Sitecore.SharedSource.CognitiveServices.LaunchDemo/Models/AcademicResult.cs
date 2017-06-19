﻿
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge;
using Microsoft.SharedSource.CognitiveServices.Models.Knowledge.AcademicSearch;

namespace Sitecore.SharedSource.CognitiveServices.LaunchDemo.Models
{
    public class AcademicResult
    {
        public CalcHistogramResponse Histogram { get; set; }
        public EvaluateResponse Evaluate { get; set; }
        public GraphSearchResponse GraphSearch { get; set; }
        public InterpretResponse Interpret { get; set; }
        public double Similarity { get; set; }
        public object SimilarityRun { get; set; }
    }
}