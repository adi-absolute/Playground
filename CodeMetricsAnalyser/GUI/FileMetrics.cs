using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class FileMetrics
    {
        public string Filename { get; set; }
        public int NumberOfLines { get; set; }
        public decimal CommentPercentage { get; set; }
        public int MaxWidth { get; set; }
        public int NumberOfFunctions { get; set; }
        public int MaxFunctionLength { get; set; }
        public decimal AvgFunctionLength { get; set; }
        public int MaxFunctionDepth { get; set; }
        public decimal AvgFunctionDepth { get; set; }
        public int MaxFunctionComplexity { get; set; }
        public decimal AvgFunctionComplexity { get; set; }
    }
}
