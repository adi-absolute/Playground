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
                var metrics = new FileMetrics();
                metrics.Name = file.Name;

                var commentStringLexer = new CommentStringLexer();
                var secondPassLexer = new SecondPassLexer();
                var c = commentStringLexer.GenerateTokens(file.Data);
                var s = secondPassLexer.SplitTokens(c);

                metrics.NumberOfLines = commentStringLexer.NumberOfLines;
                metrics.MaxWidth = commentStringLexer.MaxWidth;

                if (metrics.MaxWidth == 0)
                    return;

                metrics.CommentPercentage = CalculateCommentPercentage(c);

                var flCalc = new FunctionLengthCalculator(s);
                metrics.NumberOfFunctions = flCalc.NumberOfFunctions;
                metrics.MaxFunctionLength = flCalc.MaxLength;
                metrics.AvgFunctionLength = flCalc.AverageLength;

                var depthCalc = new FunctionDepthCalculator(flCalc.FunctionRangeSet());
                metrics.MaxFunctionDepth = depthCalc.MaxDepth;
                metrics.AvgFunctionDepth = depthCalc.AvgDepth;

                var complexityCalc = new FunctionComplexityCalculator(flCalc.FunctionRangeSet());
                metrics.MaxFunctionComplexity = complexityCalc.MaxComplexity;
                metrics.AvgFunctionComplexity = complexityCalc.AvgComplexity;
                info.Add(metrics);
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
