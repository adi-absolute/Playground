using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeMetricsAnalyser
{
    public class FunctionLengthCalculator
    {
        int openCurlyBraces = 0;
        bool functionBeingProcessed = false;
        bool functionBeingDefined = false;
        bool firstOpenCurlyBraceFound = false;
        int firstLineNumber = 0;
        int previousLineNumber = 0;
        bool previousWordWasUsing = false;
        bool isEmptyFunction = false;
        
        bool functionStart = false;
        bool functionEnd = false;

        List<int> lengths;
        List<List<Token>> functionRangeSet;

        public int MaxLength
        {
            get 
            {
                if (lengths.Count != 0)
                    return lengths.Max();
                return 0;
            }
        }

        public  decimal AverageLength
        {
            get
            {
                if (lengths.Count != 0)
                    return (decimal)lengths.Average();
                return 0;
            }
        }

        public int NumberOfFunctions
        {
            get
            {
                return lengths.Count;
            }
        }

        public FunctionLengthCalculator(List<Token> tokens)
        {
            lengths = new List<int>();
            functionRangeSet = new List<List<Token>>();
            var functionTokenList = new List<Token>();

            foreach (Token t in tokens)
            {
                Analyse(t);

                if (functionStart)
                {
                    functionTokenList.Add(t);
                }

                if (functionEnd)
                {
                    functionEnd = false;
                    functionStart = false;
                    functionRangeSet.Add(functionTokenList);
                    functionTokenList = new List<Token>();
                }
            }
        }

        private void Analyse(Token token)
        {
            var text = token.Text;

            if (text == "{")
            {
                openCurlyBraces++;

                if (!functionBeingProcessed && functionBeingDefined)
                {
                    firstOpenCurlyBraceFound = true;
                    functionBeingProcessed = true;
                    functionStart = true;
                    return;
                }
            }

            if (firstOpenCurlyBraceFound)
            {
                firstLineNumber = token.Line;
                isEmptyFunction = true;
                previousLineNumber = firstLineNumber;
                firstOpenCurlyBraceFound = false;
            }

            if (functionBeingProcessed)
                ProcessToken(token);

            CheckFunctionBeingDefined(text);
            CheckKeyword(text);
        }

        private int FunctionLength()
        {
            int length = 0;

            if (!isEmptyFunction)
            {
                length = previousLineNumber - firstLineNumber + 1;
            }

            return length;
        }

        private void ProcessToken(Token token)
        {
            if (token.Text == "}")
            {
                openCurlyBraces--;
                if (openCurlyBraces == 0)
                {
                    lengths.Add(FunctionLength());
                    functionEnd = true;
                    functionBeingProcessed = false;
                }
            }
            else
            {
                previousLineNumber = token.Line;
                isEmptyFunction = false;
            }
        }

        private void CheckFunctionBeingDefined(string text)
        {
            if (functionBeingDefined && text != ";")
                return;

            functionBeingDefined = (text == ")") && (openCurlyBraces == 0);
        }

        private void CheckKeyword(string text)
        {
            if (((text == "namespace") || (text == "class")) && !previousWordWasUsing)
                openCurlyBraces--;

            if (text == "using")
                previousWordWasUsing = true;
            else
                previousWordWasUsing = false;
        }

        public List<List<Token>> FunctionRangeSet()
        {
            return functionRangeSet;
        }
    }
}
