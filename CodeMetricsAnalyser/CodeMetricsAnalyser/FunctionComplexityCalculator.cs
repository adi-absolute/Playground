using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMetricsAnalyser
{
    public class FunctionComplexityCalculator
    {
        public int MaxComplexity
        {
            get { return (complexities.Count != 0) ? complexities.Max() : 0; }
        }

        public decimal AvgComplexity
        {
            get { return (complexities.Count != 0) ? (decimal)complexities.Average() : 0m; }
        }

        List<int> complexities;

        int currentComplexity= 0;
        int openCurlyBraceCount = 0;
        int openRoundBraceCount = 0;
        bool conditionBeingEvaluated = false;
        int conditionsUnderEvaluation = 0;

        public FunctionComplexityCalculator(List<List<Token>> functionTokens)
        {
            complexities = new List<int>();

            foreach (List<Token> tokenList in functionTokens)
            {
                foreach (Token t in tokenList)
                {
                    Analyse(t);
                }
            }
        }

        private void Analyse(Token token)
        {
            string text = token.Text;

            if (conditionBeingEvaluated)
                AnalyseCondition(text);

            if (IsConditionalKeyword(text))
            {
                currentComplexity++;
                conditionBeingEvaluated = true;
                conditionsUnderEvaluation++;
            }
            else if (text == "case")
            {
                currentComplexity++;
            }

            HandleBraces(text);
        }

        private void AnalyseCondition(string text)
        {
            if (conditionsUnderEvaluation != 0)
            {
                if (text == "(")
                {
                    openRoundBraceCount++;
                }
                else if (text == ")")
                {
                    openRoundBraceCount--;
                    if (openRoundBraceCount == 0)
                    {
                    conditionsUnderEvaluation--;
                    }
                }
                else if ((text == "&&") || (text == "||"))
                {
                    currentComplexity++;
                }
            }
            else
            {
                conditionBeingEvaluated = false;
            }
        }

        private void HandleBraces(string text)
        {
            if (text == "{")
            {
                if (openCurlyBraceCount == 0)
                {
                    currentComplexity = 1;
                }
                openCurlyBraceCount++;
            }
            else if (text == "}")
            {
                openCurlyBraceCount--;
                if (openCurlyBraceCount == 0)
                {
                    complexities.Add(currentComplexity);
                    currentComplexity = 0;
                }
            }
        }

        bool IsConditionalKeyword(string text)
        {
            return text == "if" || text == "while" || text == "for";
        }
    }
}
