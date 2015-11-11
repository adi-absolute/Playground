using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodeMetricsAnalyser
{
    public delegate bool IsDelimiterDelegate(Token token);
    public delegate int TakeNCharsFromLastTokenDelegate(Token token);
    public delegate bool NextLexerMultiLineDelegate(Token token);

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
            generalScopeDelimiters.Add('\"', 
                new DelimiterInfo("general", TokenType.StringToken, 
                    false, AlwaysDelimiter,
                    DoubleQuotesCharsFromLastToken,
                    IsNextStringLexerMultiLine,
                    stringDelimiters));
        }

        void SetupStringDelimiters()
        {
            stringDelimiters.Add('\"', 
                new DelimiterInfo("string", TokenType.None, 
                    true, DoubleQuotesInStringDelimiter,
                    TakeZeroCharsFromLastToken,
                    NextLexerNotMultiLine,
                    generalScopeDelimiters));
        }

        public bool AlwaysDelimiter(Token t)
        {
            return true;
        }

        public bool DoubleQuotesInStringDelimiter(Token token)
        {
            if (currentToken.Text.StartsWith("R"))
            {
                var openBracketPosition = currentToken.Text.IndexOf('(');
                if (openBracketPosition == -1)
                    return false;

                string bookend = ")" + currentToken.Text.Substring(2, openBracketPosition - 2);

                return currentToken.Text.EndsWith(bookend);
            }

            return !token.Text.EndsWith("\\");
        }

        public int TakeZeroCharsFromLastToken(Token t)
        {
            return 0;
        }

        public int DoubleQuotesCharsFromLastToken(Token token)
        {
            if ((token.Text.Length != 0) && (token.Text.EndsWith("R")))
                return 1;

            return 0;
        }

        bool NextLexerNotMultiLine(Token t)
        {
            return false;
        }

       bool IsNextStringLexerMultiLine(Token token)
       {
           if ((token.Text.Length != 0) && !token.Text.EndsWith("R"))
               return true;

           return false;
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

           int charsFromLastToken = delimiter.TakeNCharsFromLastToken(currentToken);
           if (charsFromLastToken != 0)
           {
               nextTokenText = currentToken.Text.Substring(currentToken.Text.Length - charsFromLastToken);
               currentToken.Text = currentToken.Text.Remove(currentToken.Text.Length - charsFromLastToken);
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
           multiLineLexer = delimiter.NextLexerMultiLine(currentToken);
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
