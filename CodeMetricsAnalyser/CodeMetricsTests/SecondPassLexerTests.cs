using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeMetricsAnalyser;
using System.IO;
using System.Collections.Generic;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class SecondPassLexerTests
    {
        struct TD
        {
            public int line;
            public int column;
            public string text;
            public TokenType type;

            public TD(int l, int c, string tx, TokenType ty = TokenType.None)
            {
                line = l; column = c; text = tx; type = ty;
            }
        };

        List<Token> PackageTokens(List<TD> tokens)
        {
           List<Token> output = new List<Token>();

           foreach (var token in tokens)
           {
              Token newToken = new Token(token.line, token.column, token.type);
              newToken.Text = token.text;
              output.Add(newToken);
           }

           return output;
        }



        SecondPassLexer lexer = new SecondPassLexer();

        [TestMethod]
        public void Lex_simple_hash_include_token()
        {            
            string expectedText = "#include";
            var ss = Generate.StringStream(expectedText);

            Token expected = new Token(0, 0);
            expected.Text = expectedText;
            var input = new List<Token>();
            input.Add(expected);

            var output = lexer.SplitTokens(input);

            Compare.TokenListsEqual(input, output);
        }

        [TestMethod]
        public void Lex_global_variable_declaration()
        {
            var input = new List<Token>();
            Token expected = new Token(0, 0);
            expected.Text = "int a = 10;";
            input.Add(expected);
            int[] a = new int[2] { 1, 2 };

            List <TD> expectedTokens = new List<TD>
            {
                new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
            };

            var expectedOutput = PackageTokens(expectedTokens);

            var actualOutput = lexer.SplitTokens(input);

            Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lex_code_with_tabs_instead_of_spaces()
        {
            List<Token> input = new List<Token>();
            Token expected = new Token(0, 0);
            expected.Text = "int\ta\t=\t10;";
            input.Add(expected);

            List <TD> expectedTokens = new List<TD>
            {
                new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
            };

            List<Token> expectedOutput = PackageTokens(expectedTokens);

            List<Token> actualOutput = lexer.SplitTokens(input);

            Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lex_two_global_variable_declarations_on_same_line()
        {
            List<Token> input = new List<Token>();
           Token expected = new Token(0, 0);
           expected.Text = "int a = 10;int b = 20;";
           input.Add(expected);

           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
              new TD(0, 11, "int"), new TD(0, 15, "b"), new TD(0, 17, "="), new TD(0, 19, "20"), new TD(0, 21, ";"),
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lex_two_global_variable_declarations_on_separate_lines()
        {
            List<Token> input = Generate.TokenListFromString("int a = 10;\nint b = 20;");

            List <TD> expectedTokens = new List<TD>
            {
                new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
                new TD(1, 0, "int"), new TD(1, 4, "b"), new TD(1, 6, "="), new TD(1, 8, "20"), new TD(1, 10, ";"),
            };

            List<Token> expectedOutput = PackageTokens(expectedTokens);

            List<Token> actualOutput = lexer.SplitTokens(input);

            Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lexer_ignores_comment_tokens()
        {
           
            string ss = @"int a = 10;
/*comment*/
int b = 20;";

            List<Token> input = Generate.TokenListFromString(ss);

            List <TD> expectedTokens = new List<TD>
            {
                new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
                new TD(2, 0, "int"), new TD(2, 4, "b"), new TD(2, 6, "="), new TD(2, 8, "20"), new TD(2, 10, ";"),
            };

            List<Token> expectedOutput = PackageTokens(expectedTokens);

            List<Token> actualOutput = lexer.SplitTokens(input);

            Compare.TokenListsEqual(expectedOutput, actualOutput);
        }
        
        [TestMethod]
        public void Lexing_strings()
        {
           string ss = @"int a = 10;
string s = R""(20)"";";

           List<Token> input = Generate.TokenListFromString(ss);

           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
              new TD(1, 0, "string"), new TD(1, 7, "s"), new TD(1, 9, "="), new TD(1, 11, @"R""(20)""", TokenType.StringToken), new TD(1, 18, ";"),
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lexing_strings_with_curly_brace_in_them()
        {
            string ss = @"int a = 10;
string s = R""({)"";";

            List<Token> input = Generate.TokenListFromString(ss);

            List <TD> expectedTokens = new List<TD>
            {
                new TD(0, 0, "int"), new TD(0, 4, "a"), new TD(0, 6, "="), new TD(0, 8, "10"), new TD(0, 10, ";"),
                new TD(1, 0, "string"), new TD(1, 7, "s"), new TD(1, 9, "="), new TD(1, 11, @"R""({)""", TokenType.StringToken), new TD(1, 17, ";"),
            };

            List<Token> expectedOutput = PackageTokens(expectedTokens);

            List<Token> actualOutput = lexer.SplitTokens(input);

            Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lex_open_brace_on_same_line()
        {
           string ss = "void f(){";
           List<Token> input = Generate.TokenListFromString(ss);

           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "void"), new TD(0, 5, "f"), new TD(0, 6, "("), new TD(0, 7, ")"), new TD(0, 8, "{")
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lex_closing_brace_with_code_following_brace()
        {
           
           string ss = "void f(){}blah();";

           List<Token> input = Generate.TokenListFromString(ss);
   
           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "void"), new TD(0, 5, "f"), new TD(0, 6, "("), new TD(0, 7, ")"), 
              new TD(0, 8, "{"), new TD(0, 9, "}"), new TD(0, 10, "blah"), new TD(0, 14, "("), new TD(0, 15, ")"), new TD(0, 16, ";")
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lexer_block_of_code()
        {
           string ss = @"void f()
{
   int b = 20;
// comment
}";

           List<Token> input = Generate.TokenListFromString(ss);

           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "void"), new TD(0, 5, "f"), new TD(0, 6, "("), new TD(0, 7, ")"),
              new TD(1, 0, "{"),
              new TD(2, 3, "int"), new TD(2, 7, "b"), new TD(2, 9, "="), new TD(2, 11, "20"), new TD(2, 13, ";"),
              new TD(4, 0, "}"),
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void Lexer_block_of_code_with_multiple_braces()
        {
           string ss = @"void f()
{
   int b = 20;
   if (b == 35)
   {
      break;
   }
// comment
}";

           List<Token> input = Generate.TokenListFromString(ss);

           List <TD> expectedTokens = new List<TD>
           {
              new TD(0, 0, "void"), new TD(0, 5, "f"), new TD(0, 6, "("), new TD(0, 7, ")"),
              new TD(1, 0, "{"),
              new TD(2, 3, "int"), new TD(2, 7, "b"), new TD(2, 9, "="), new TD(2, 11, "20"), new TD(2, 13, ";"),
              new TD(3, 3, "if"), new TD(3, 6, "("), new TD(3, 7, "b"), new TD(3, 9, "=="), new TD(3, 12, "35"), new TD(3, 14, ")"),
              new TD(4, 3, "{"),
              new TD(5, 6, "break"), new TD(5, 11, ";"),
              new TD(6, 3, "}"),
              new TD(8, 0, "}"),
           };

           List<Token> expectedOutput = PackageTokens(expectedTokens);

           List<Token> actualOutput = lexer.SplitTokens(input);

           Compare.TokenListsEqual(expectedOutput, actualOutput);
        }
    }
}
