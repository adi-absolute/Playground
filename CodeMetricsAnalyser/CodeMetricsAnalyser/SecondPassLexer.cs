using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeMetricsAnalyser
{
    public class SecondPassLexer
    {
        List<Token> tokenList;
        Dictionary<char, bool> delimiterInfo;

        int column = 0;
        int line = 0;
        Token currentToken;

        public SecondPassLexer()
        {
            tokenList = new List<Token>();
            delimiterInfo = new Dictionary<char, bool>();
            delimiterInfo.Add(' ', false);
            delimiterInfo.Add('\t', false);
            delimiterInfo.Add(';', true);
            delimiterInfo.Add('{', true);
            delimiterInfo.Add('}', true);
            delimiterInfo.Add('(', true);
            delimiterInfo.Add(')', true);
        }

        void LexDelimiter(char character)
        {
            if (currentToken.Text.Length != 0)
                tokenList.Add(currentToken);

            if (delimiterInfo[character])
            {
                currentToken = new Token(line, column);
                currentToken.Text += character;
                tokenList.Add(currentToken);
            }

            currentToken = new Token(line, column + 1);
        }

        public List<Token> SplitTokens(List<Token> tokens)
        {
            tokenList.Clear();

            foreach (Token token in tokens)
            {
                if ((token.Type == TokenType.Comment) || (token.Type == TokenType.Hash))
                {
                    continue;
                }
                else if (token.Type == TokenType.StringToken)
                {
                    tokenList.Add(token);
                    continue;
                }

                string tokenText = token.Text;
                column = token.Column;
                line = token.Line;
                currentToken = new Token(line, column);

                foreach (char character in tokenText)
                {
                    if (delimiterInfo.ContainsKey(character))
                    {
                        LexDelimiter(character);
                    }
                    else
                    {
                        currentToken.Text += character;
                    }

                    column++;
                }

                if (currentToken.Text.Length != 0)
                    tokenList.Add(currentToken);
            }

            return tokenList;
        }
    }
}
