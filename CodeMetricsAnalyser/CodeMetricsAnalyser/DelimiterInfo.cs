using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMetricsAnalyser
{
    public class DelimiterInfo
    {
        public string Name;
        public TokenType Type;
        public bool AddToCurrentToken;
        public IsDelimiterDelegate IsDelimiter;
        public TakeNCharsFromLastTokenDelegate TakeNCharsFromLastToken;
        public NextLexerMultiLineDelegate NextLexerMultiLine;
        public Dictionary<char, DelimiterInfo> NextLexer;

        public DelimiterInfo(string name, TokenType type, 
            bool addToCurrent, IsDelimiterDelegate del, 
            TakeNCharsFromLastTokenDelegate takeNChars,
            NextLexerMultiLineDelegate nextLexerMultiLine,
            Dictionary<char, DelimiterInfo> nextLexer)
        {
            Name = name;
            Type = type;
            AddToCurrentToken = addToCurrent;
            TakeNCharsFromLastToken = takeNChars;
            IsDelimiter = del;
            NextLexerMultiLine = nextLexerMultiLine;
            NextLexer = nextLexer;
        }
    }
}
