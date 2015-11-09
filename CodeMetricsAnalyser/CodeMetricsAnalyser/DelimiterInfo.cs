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
        public IsDelimiter IsDelimiter;

        //public bool IsDelimiter(Token currentToken, IsDelimiter d)
        //{
        //    return false;
        //}

        public int TakeLastNCharsFromToken(Token currentToken)
        {
            return 0;
        }

        public bool isNextLexerMultiLine(Token currentToken)
        {
            return false;
        }

        public Dictionary<char, DelimiterInfo> NextLexer;

        public DelimiterInfo(string name, TokenType type, bool addToCurrent, Dictionary<char, DelimiterInfo> nextLexer)
        {
            Name = name;
            Type = type;
            AddToCurrentToken = addToCurrent;
            NextLexer = nextLexer;
        }
    }
}
