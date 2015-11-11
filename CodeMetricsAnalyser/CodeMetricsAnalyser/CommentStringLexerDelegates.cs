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
            return ((currentToken.Text.Length != 0) && (currentToken.Text.EndsWith("/")));
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
            if ((token.Text.Length != 0) && (token.Text.EndsWith("R")))
                return 1;

            return 0;
        }

        public static int Comments(Token token)
        {
            if (IsDelimiter.IfPreviousCharASlash(token))
                return 1;

            return 0;
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
            if ((token.Text.Length != 0) && !token.Text.EndsWith("R"))
                return true;

            return false;
        }

        public static bool BlockComment(Token token)
        {
            if ((token.Text.Length > 1) && (token.Text.ElementAt(1) == '*'))
                return true;

            return false;
        }
    }
}