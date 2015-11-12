using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeMetricsAnalyser
{
    public static class IsDelimiter
    {
        public static bool Always(Token token)
        {
            return true;
        }

        public static bool IfPreviousCharASlash(Token currentToken)
        {
            return currentToken.Text.EndsWith("/");
        }

        public static bool DoubleQuotes(Token token)
        {
            if (token.Text.StartsWith("R"))
            {
                var openBracketPosition = token.Text.IndexOf('(');
                if (openBracketPosition == -1)
                    return false;

                string bookend = ")" + token.Text.Substring(2, openBracketPosition - 2);

                return token.Text.EndsWith(bookend);
            }

            return !token.Text.EndsWith("\\");
        }

        public static bool Slash(Token token)
        {
            return token.Text.EndsWith("*");
        }
    }

    public static class TakeCharsFromLastToken
    {
        public static int Zero(Token token)
        {
            return 0;
        }

        public static int DoubleQuotes(Token token)
        {
            return token.Text.EndsWith("R") ? 1 : 0;
        }

        public static int Comments(Token token)
        {
            return IsDelimiter.IfPreviousCharASlash(token) ? 1 : 0;
        }
    }

    public static class IsMultiline
    {
        public static bool No(Token token)
        {
            return false;
        }

        public static bool VerbatimString(Token token)
        {
            return !token.Text.EndsWith("R");
        }

        public static bool BlockComment(Token token)
        {
            return ((token.Text.Length > 1) && (token.Text.ElementAt(1) == '*'));
        }
    }
}