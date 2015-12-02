using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMetricsAnalyser
{
    public class FunctionDepthCalculator
    {
        public int MaxDepth 
        {
            get { return (depths.Count != 0) ? depths.Max() : 0; } 
        }
        public decimal AvgDepth
        {
            get { return (depths.Count != 0) ? (decimal)depths.Average() : 0m; } 
        }

        int currentDepth = 0;
        bool conditionBeingEvaluated = false;
        int conditionsUnderEvaluation = 0;
        int openRoundBraceCount = 0;
        int braceCount = 0;
        bool previousWordWasElse = false;
        int maxDepthForThisFunc = 0;

        Dictionary<int, bool> isConditionBraced;

        List<int> depths;

        public FunctionDepthCalculator(List<List<Token>> functionTokens)
        {
            isConditionBraced = new Dictionary<int, bool>();
            depths = new List<int>();

            foreach (List<Token> tokenList in functionTokens)
            {
                foreach (Token t in tokenList)
                {
                    Analyse(t);
                }
            }
        }

        private void IncrementCurrentDepth(bool braced = true)
        {
            if ((++currentDepth) > maxDepthForThisFunc)
                maxDepthForThisFunc = currentDepth;

            isConditionBraced[currentDepth] = braced;
        }

        private void DecrementCurrentDepth()
        {
            if (currentDepth > 0)
                currentDepth--;

            while ((currentDepth > 0) && isConditionBraced[currentDepth] == false)
                currentDepth--;
        }

        private void Analyse(Token token)
        {
            string text = token.Text;

            if (conditionBeingEvaluated)
                AnalyseCondition(text);

            HandleElseKeyword(text);

            HandleBraces(text);
   
            if (IsConditionalKeyword(text))
            {
                conditionBeingEvaluated = true;
                conditionsUnderEvaluation++;
            }  
        }

        
        void AnalyseCondition(string text)
        {
            if (text == "(")
            {
                openRoundBraceCount++;
            }
            else if (text == ")")
            {
                openRoundBraceCount--;
                if (openRoundBraceCount == 0)
                    conditionsUnderEvaluation--;
            }
            else if (openRoundBraceCount == 0)
            {
                IncrementCurrentDepth(text == "{");
                if (!IsConditionalKeyword(text))
                {
                    DecrementCurrentDepth();
                    conditionBeingEvaluated = false;
                }
            }
        }

        bool IsConditionalKeyword(string text)
        {   
            if ((text == "if") || (text == "while") || (text == "for") || (text == "else")
                && !previousWordWasElse)
                return true;

            return false;
        }

        void HandleBraces(string text)
        {
            if ((text == "{"))
            {
                braceCount++;
                IncrementCurrentDepth();
            }
            else if (text == "}")
            {
                DecrementCurrentDepth();
                braceCount--;
                if (braceCount == 0)
                {
                    depths.Add(maxDepthForThisFunc);
                    maxDepthForThisFunc = 0;
                    currentDepth = 0;
                }
            }
        }

        void HandleElseKeyword(string text)
        {
            if (previousWordWasElse && (text != "if") && (text != "{"))
                previousWordWasElse = false;

            if (text == "else")
                previousWordWasElse = true;
        }
    }
}
