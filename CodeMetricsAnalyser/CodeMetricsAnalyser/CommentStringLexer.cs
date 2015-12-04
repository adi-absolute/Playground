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

        int lineNumber = 0;
        int columnNumber = 0;
        Token currentToken;
        bool multiLineLexer = false;

        public int NumberOfLines = 0;

        public int MaxWidth = 0;

        void SetupGeneralDelimiters()
        {
            generalScopeDelimiters.Add('\"', 
                new DelimiterInfo(TokenType.StringToken, 
                    false, IsDelimiter.Always,
                    TakeCharsFromLastToken.DoubleQuotes,
                    IsMultiline.VerbatimString,
                    stringDelimiters));
            generalScopeDelimiters.Add('*', 
                new DelimiterInfo(TokenType.Comment, 
                    false, IsDelimiter.IfPreviousCharASlash,
                    TakeCharsFromLastToken.Comments,
                    IsMultiline.BlockComment,
                    blockCommentDelimiters));
            generalScopeDelimiters.Add('/',
                new DelimiterInfo(TokenType.Comment,
                    false, IsDelimiter.IfPreviousCharASlash,
                    TakeCharsFromLastToken.Comments,
                    IsMultiline.No,
                    lineCommentDelimiters));
        }

        void SetupStringDelimiters()
        {
            stringDelimiters.Add('\"', 
                new DelimiterInfo(TokenType.None, 
                    true, IsDelimiter.DoubleQuotes,
                    TakeCharsFromLastToken.Zero,
                    IsMultiline.No,
                    generalScopeDelimiters));
        }

        void SetupBlockCommentDelimiters()
        {
            blockCommentDelimiters.Add('/',
                new DelimiterInfo(TokenType.None,
                    true, IsDelimiter.Slash,
                    TakeCharsFromLastToken.Zero,
                    IsMultiline.No,
                    generalScopeDelimiters));
        }

        void SetupLineCommentDelimiters()
        {
            lineCommentDelimiters.Add('\\',
                new DelimiterInfo(TokenType.None,
                    true, IsDelimiter.Slash,
                    TakeCharsFromLastToken.Zero,
                    IsMultiline.No,
                    generalScopeDelimiters));
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
            SetupBlockCommentDelimiters();
            SetupLineCommentDelimiters();
        }
        
        bool IsPreviousCharABackslash()
        {
            return currentToken.Text.EndsWith("\\");
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
                if (line.Length > MaxWidth)
                    MaxWidth = line.Length;

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

                if ((multiLineLexer) || (IsPreviousCharABackslash()))
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

            NumberOfLines = lineNumber;

            return tokens;
        }
    }
}
