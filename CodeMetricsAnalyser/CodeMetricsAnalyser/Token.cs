using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeMetricsAnalyser
{
    public enum TokenType
    {
        None,
        Keyword,
        Comment,
        StringToken,
    };

    public class Token
    {
        public int Line;
        public int Column;
        public TokenType Type;
        public String Text;

        public Token(int line, int column, TokenType type = TokenType.None)
        {
            Line = line;
            Column = column;
            Type = type;
        }
    }
}