using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CodeMetricsAnalyser;

namespace GUI
{
    public class Form2Presenter
    {
        private IView _view;

        public Form2Presenter(IView rename)
        {
            _view = rename;
            _view.FilesSelected += new FileSelectHandler(Analyse);
        }

        private void Analyse(List<FileInfo> files)
        {
            var info = new List<FileMetrics>();

            foreach (FileInfo file in files)
            {
                var fileInfo = new FileMetrics();
                fileInfo.Name = file.Name;

                var commentStringLexer = new CommentStringLexer();
                var secondPassLexer = new SecondPassLexer();
                var c = commentStringLexer.GenerateTokens(file.Data);
                var s = secondPassLexer.SplitTokens(c);

                if (commentStringLexer.MaxWidth == 0)
                    return;

                fileInfo.SetMetric(Metric.NoOfLines, commentStringLexer.NumberOfLines);
                fileInfo.SetMetric(Metric.CommentPercent, CalculateCommentPercentage(c));
                fileInfo.SetMetric(Metric.MaxWidth, commentStringLexer.MaxWidth);

                
                var flCalc = new FunctionLengthCalculator(s);
                fileInfo.SetMetric(Metric.NoOfFunctions, flCalc.NumberOfFunctions);
                fileInfo.SetMetric(Metric.MaxFuncLen, flCalc.MaxLength);
                fileInfo.SetMetric(Metric.AvgFuncLen, flCalc.AverageLength);

                var depthCalc = new FunctionDepthCalculator(flCalc.FunctionRangeSet());
                fileInfo.SetMetric(Metric.MaxFuncDepth, depthCalc.MaxDepth);
                fileInfo.SetMetric(Metric.AvgFuncDepth, depthCalc.AvgDepth);

                var complexityCalc = new FunctionComplexityCalculator(flCalc.FunctionRangeSet());
                fileInfo.SetMetric(Metric.MaxComplexity, complexityCalc.MaxComplexity);
                fileInfo.SetMetric(Metric.AvgComplexity, complexityCalc.AvgComplexity);
                info.Add(fileInfo);
            }

            _view.SetData(info);
            _view.SetVisibility(true);
            _view.UpdateDisplay();
        }

        private decimal CalculateCommentPercentage(List<Token> tokens)
        {
            //int tokenCounter = 0;
            int maxLength = 0;
            int totalChars = 0;
            int commentChars = 0;

            foreach (Token t in tokens)
            {
                int charCount = t.Text.Length;

                if (charCount > maxLength)
                    maxLength = charCount;

                totalChars += charCount;

                if (t.Type == TokenType.Comment)
                    commentChars += charCount;

                //cout << "*" << setw(2) << tokenCounter <<  "* " << token.text << endl;
                //tokenCounter++;  // Random comment \ with multiple slashes \
            }

            return (decimal)(commentChars * 100m / totalChars);
        }
    }
}
