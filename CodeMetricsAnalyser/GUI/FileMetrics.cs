using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    enum Metric
    {
        NoOfLines,
        CommentPercent,
        MaxWidth,
        NoOfFunctions,
        MaxFuncLen,
        AvgFuncLen,
        MaxFuncDepth,
        AvgFuncDepth,
        MaxComplexity,
        AvgComplexity,
        NoOfMetrics
    }

    public class FileMetrics
    {
        private decimal[] _metrics;

        public FileMetrics()
        {
            _metrics = new decimal[(int)Metric.NoOfMetrics];
        }

        public string Name { get; set; }

        public decimal[] Met 
        {
            get { return _metrics; }
            set { _metrics = value; }
        }
    }
}
