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
        public Dictionary<char, DelimiterInfo> NextLexer;

        public int TakeLastNCharsFromToken(Token currentToken)
        {
            return 0;
        }

        public bool isNextLexerMultiLine(Token currentToken)
        {
            return false;
        }


        public DelimiterInfo(string name, TokenType type, bool addToCurrent, IsDelimiterDelegate del, Dictionary<char, DelimiterInfo> nextLexer)
        {
            Name = name;
            Type = type;
            AddToCurrentToken = addToCurrent;
            IsDelimiter = del;
            NextLexer = nextLexer;
        }
    }
}
