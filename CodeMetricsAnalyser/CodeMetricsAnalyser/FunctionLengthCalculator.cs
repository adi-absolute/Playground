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

        List<int> lengths;

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

            foreach (Token t in tokens)
            {
                Analyse(t);
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
                    //saveFirstIterator = true;
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
                    //saveSecondIterator = true;
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
    }
}
