using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeMetricsAnalyser;
using System.IO;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class CommentStringLexerTests
    {
        CommentStringLexer lexer;

        public CommentStringLexerTests()
        {
            lexer = new CommentStringLexer();
        }

        [TestMethod]
        public void Lexing_a_global_variable_definition()
        {
            Stream stream = Generate.StringStream("int a;");

            var tokens = lexer.GenerateTokens(stream);

            Assert.AreEqual(1, tokens.Count);

            Token expected = new Token(0, 0);
            expected.Text = "int a;";

            Compare.TokensEqual(expected, tokens[0]); 
        }

        [TestMethod]
        public void Lexing_two_global_variable_definitions()
        {           
            Stream stream = Generate.StringStream("int a;\n    float b;");
            var tokens = lexer.GenerateTokens(stream);

            Assert.AreEqual(2, tokens.Count);

            Token expected1 = new Token(0, 0);
            expected1.Text = "int a;";
            Compare.TokensEqual(expected1, tokens[0]);

            Token expected2 = new Token(1, 0);
            expected2.Text = "    float b;";
            Compare.TokensEqual(expected2, tokens[1]);
        }

        [TestMethod]
        public void Lexing_a_global_string_variable_definition()
        {
            Stream ss = Generate.StringStream("string s = \"Hello World\";");
            
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(3, tokens.Count);

            Token expected0 = new Token(0, 0);
            expected0.Text = "string s = ";
            Compare.TokensEqual(expected0, tokens[0]);

            Token expected1 = new Token(0, 11, TokenType.StringToken);
            expected1.Text = "\"Hello World\"";
            Compare.TokensEqual(expected1, tokens[1]);

            Token expected2 = new Token(0, 24);
            expected2.Text = ";";
            Compare.TokensEqual(expected2, tokens[2]);
        }

        [TestMethod]
        public void Lexing_a_line_after_a_global_string_variable_definition()
        {
           
           Stream ss = Generate.StringStream("string s = \"Hello World\";\nint a = 10;");

           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(4, tokens.Count);

           Token expectedToken = new Token(1, 0);
           expectedToken.Text = "int a = 10;";
           Compare.TokensEqual(expectedToken, tokens[3]);
        }
        
        [TestMethod]
        public void Lexing_a_global_string_variable_definition_with_a_escaped_double_quote()
        {
           string expectedText = @"""Hello \"" World!""";
           Stream ss = Generate.StringStream("string s = " + expectedText + ";");

           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expectedText;
           Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_global_cpp11_string_variable_definition()
        {
           const string expected = @"R""bookend(""world"")bookend""";
           Stream ss = Generate.StringStream("string s = " + expected + ";");
           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expected;
           Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_global_multi_line_cpp11_string_variable_definition()
        {
           string expected = @"R""bookend(""Hello
world"")bookend""";
           Stream ss = Generate.StringStream("string s = " + expected + ";");

           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expected;
           Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_single_line_global_block_comment()
        {
            string expected ="/* Hello World */";
            Stream ss = Generate.StringStream(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);
            Token expectedToken = new Token(0, 0, TokenType.Comment);
            expectedToken.Text = expected;
            Compare.TokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Lex_valid_code_line_after_block_comment()
        {
            string expectedText = "int a = 10;";
            
            Stream ss = Generate.StringStream("/*comment*/\n" + expectedText);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(2, tokens.Count);

            Token expectedToken = new Token(1, 0);
            expectedToken.Text = expectedText;
            Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_multi_line_global_block_comment()
        {
            string expected = @"/* Hello 
        world */";
            Stream ss = Generate.StringStream(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expectedToken = new Token(0, 0, TokenType.Comment);
            expectedToken.Text = expected;
            Compare.TokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Asterisk_as_multiplier_not_part_of_comment()
        {
            string expected = "int a = 5*6;";
            Stream ss = Generate.StringStream(expected);
           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(1, tokens.Count);

           Token expectedToken = new Token(0, 0);
           expectedToken.Text = expected;
           Compare.TokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Slash_as_divider_not_part_of_comment()
        {
            string expected = "int a = 53/6;";
            Stream ss = Generate.StringStream(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expectedToken = new Token(0, 0);
            expectedToken.Text = expected;
            Compare.TokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Lexing_line_comments()
        {
            string expected = @"//string s = ""blah""";
            Stream ss = Generate.StringStream(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expectedToken = new Token(0, 0, TokenType.Comment);
            expectedToken.Text = expected;
            Compare.TokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Lexing_line_comment_after_valid_code()
        {
            string expected = @"//string s = ""blah""";
            Stream ss = Generate.StringStream("int a = 5; " + expected);

            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(2, tokens.Count);

            Token expectedToken = new Token(0, 11, TokenType.Comment);
            expectedToken.Text = expected;
            Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Slash_asterisk_comment_in_the_middle_of_valid_code()
        {
            Stream ss = Generate.StringStream("int a = /*comment*/ 53/6;");
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(3, tokens.Count);

            Token expectedToken = new Token(0, 8, TokenType.Comment);
            expectedToken.Text = "/*comment*/";
            Compare.TokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_valid_code_after_double_slash_comment()
        {
            Stream ss = Generate.StringStream(@"//string s = ""blah""
string a = ""text"";");

            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(4, tokens.Count);

            Token expected = new Token(1, 0);
            expected.Text = "string a = ";

            Compare.TokensEqual(expected, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_block_comment_after_valid_code()
        {
           
            string expected = @"/*something went wrong*/";
            Stream ss = Generate.StringStream(@"cout << ""Can't open file!"" << endl;" + expected);

            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(4, tokens.Count);

            Token expectedToken3 = new Token(0, 26);
            expectedToken3.Text = " << endl;";
            Compare.TokensEqual(expectedToken3, tokens[2]);

            Token expectedToken4 = new Token(0, 35, TokenType.Comment);
            expectedToken4.Text = expected;
            Compare.TokensEqual(expectedToken4, tokens[3]);
        }

        [TestMethod]
        public void  Lexing_multiline_line_comment()
        {
            string expectedText = @"//string s = ""blah"" \
        and some more blah";
            Stream ss = Generate.StringStream(expectedText);

            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expected = new Token(0, 0, TokenType.Comment);
            expected.Text = expectedText;

            Compare.TokensEqual(expected, tokens[0]);
        }
        
        [TestMethod]
        public void  Number_of_lines_in_single_line_file()
        {
            Stream ss = Generate.StringStream(@"cout << ""Just one line"" << endl;");
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, lexer.NumberOfLines);
        }
        
        [TestMethod]
        public void  Number_of_lines_in_multi_line_file()
        {
            string expectedText = @"//string s = ""blah"" \
        and some more blah";
            Stream ss = Generate.StringStream(expectedText);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(2, lexer.NumberOfLines);
        }
    }
}
