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
        
        public Token(int line, int column, TokenType type = TokenType.None)
        {
            Line = line;
            Column = column;
            Type = type;
        }

        public String Text;

    }

    public delegate bool IsDelimiter(Token t);

    public class CommentStringLexer
    {
        List<Token> tokens;
        Dictionary<char, DelimiterInfo> lexer;
        Dictionary<char, DelimiterInfo> generalScopeDelimiters;
        Dictionary<char, DelimiterInfo> stringDelimiters;
        Dictionary<char, DelimiterInfo> blockCommentDelimiters;
        Dictionary<char, DelimiterInfo> lineCommentDelimiters;

        void SetupGeneralDelimiters()
        {
            var d = new DelimiterInfo("general", TokenType.StringToken, false, stringDelimiters);
            d.IsDelimiter = AlwaysDelimiter;
            generalScopeDelimiters.Add('\"', d);
        }

        void SetupStringDelimiters()
        {
            var d = new DelimiterInfo("string", TokenType.None, true, generalScopeDelimiters);
            d.IsDelimiter = DoubleQuotesInStringDelimiter;
            stringDelimiters.Add('\"', d);
        }

        public bool AlwaysDelimiter(Token t)
        {
            return true;
        }

        public bool DoubleQuotesInStringDelimiter(Token t)
        {
            return !t.Text.EndsWith("\\");
        }

        public CommentStringLexer()
        {
            tokens = new List<Token>();
            generalScopeDelimiters = new Dictionary<char, DelimiterInfo>();
            stringDelimiters = new Dictionary<char, DelimiterInfo>();
            blockCommentDelimiters = new Dictionary<char, DelimiterInfo>();
            lineCommentDelimiters = new Dictionary<char, DelimiterInfo>();

            SetupGeneralDelimiters();
            SetupStringDelimiters();
        }

        int lineNumber = 0;
        int columnNumber = 0;
        Token currentToken;
        int numberOfLines = 0;
        bool multiLineLexer = false;
        
        bool IsPreviousCharABackslash(Token currentToken)
        {
            return ((currentToken.Text.Length != 0) && (currentToken.Text.EndsWith("\\")));
        }

        void LexDelimiter(char character)
        {
           var delimiter = lexer[character];
           var nextTokenText = String.Empty;
           int nextTokenColNumber = columnNumber;

           int charsFromLastToken = delimiter.TakeLastNCharsFromToken(currentToken);
           if (charsFromLastToken != 0)
           {
               currentToken.Text.Remove(charsFromLastToken);
           }

           if (delimiter.AddToCurrentToken)
           {
              currentToken.Text += character;
              nextTokenColNumber++;
           }
   
           if (currentToken.Text.Length != 0)
           {
              tokens.Add(currentToken);
           }

           currentToken = new Token(lineNumber, nextTokenColNumber - nextTokenText.Length, delimiter.Type);
           currentToken.Text += nextTokenText;
      
           if (!delimiter.AddToCurrentToken)
              currentToken.Text += character;
   
           lexer = delimiter.NextLexer;
           multiLineLexer = delimiter.isNextLexerMultiLine(currentToken);
        }

        public List<Token> GenerateTokens(Stream stream)
        {
            tokens.Clear();
            String line;
            lineNumber = 0;
            currentToken = new Token(0, 0);

            var reader = new StreamReader(stream);

            lexer = generalScopeDelimiters;

            while (!reader.EndOfStream)
            {
                line = reader.ReadLine();
                columnNumber = 0;

                foreach (char character in line)
                {
                    if (lexer.ContainsKey(character) && lexer[character].IsDelimiter(currentToken))
                    {
                        LexDelimiter(character);
                    }
                    else
                    {
                        currentToken.Text += character;
                    }
         
                    columnNumber++;
                }

                lineNumber++;

                if ((multiLineLexer) || (IsPreviousCharABackslash(currentToken)))
                {
                    currentToken.Text += '\n';
                }
                else 
                {
                    if (currentToken.Text.Length != 0)
                    {
                        lexer = generalScopeDelimiters;
                        tokens.Add(currentToken);
                    }

                    currentToken = new Token(lineNumber, 0);
                }
            }

        numberOfLines = lineNumber;

        return tokens;
        }
    }
}
