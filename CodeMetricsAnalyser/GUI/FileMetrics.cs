using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public enum Metric
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

    public enum Level
    {
        None,
        Warning,
        Danger
    }
    
    public class FileMetrics
    {
        struct MetricLevels
        {
            public bool IsComparable;
            public decimal WarningLevel;
            public decimal DangerLevel;

            public MetricLevels(bool i = false, decimal w = 0m, decimal d = 0m)
            {
                IsComparable = i;
                WarningLevel = w;
                DangerLevel = d;
            }

        }

        private decimal[] _metrics;
        private MetricLevels[] _levels;

        public FileMetrics()
        {
            _metrics = new decimal[(int)Metric.NoOfMetrics];
            _levels = new MetricLevels[(int)Metric.NoOfMetrics];

            SetupMetricLevels();
        }

        private void SetupMetricLevels()
        {
            _levels[(int)Metric.MaxFuncDepth] = new MetricLevels(true, 4m, 7m);
            _levels[(int)Metric.AvgFuncDepth] = new MetricLevels(true, 4m, 7m);
            _levels[(int)Metric.MaxFuncLen] = new MetricLevels(true, 50m, 100m);
            _levels[(int)Metric.AvgFuncLen] = new MetricLevels(true, 50m, 100m);
            _levels[(int)Metric.MaxComplexity] = new MetricLevels(true, 3m, 6m);
            _levels[(int)Metric.AvgComplexity] = new MetricLevels(true, 3m, 6m);
        }

        public string Name { get; set; }

        public void SetMetric(Metric metric, decimal value)
        {
            _metrics[(int)metric] = value;
        }

        public decimal[] MetricValue 
        {
            get { return _metrics; }
        }

        public Level GetMetricLevel(Metric metric)
        {
            Level lvl = Level.None;
            int index = (int)metric;

            if (_levels[index].IsComparable)
            {
                if (_metrics[index] > _levels[index].DangerLevel)
                    lvl = Level.Danger;
                else if (_metrics[index] > _levels[index].WarningLevel)
                    lvl = Level.Warning;
            }

            return lvl;
        }
    }
}
