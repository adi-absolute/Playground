using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeMetricsAnalyser;
using System.IO;

namespace TestsForCodeMetricsAnalyser
{
    [TestClass]
    public class CommentStringLexerTests
    {
        void AssertTokensEqual(Token t1, Token t2)
        {
            Assert.AreEqual(t1.Column, t2.Column);
            Assert.AreEqual(t1.Line, t2.Line);
            t1.Text = t1.Text.Replace("\r", "");
            Assert.AreEqual(t1.Text, t2.Text); 
            Assert.AreEqual(t1.Type, t2.Type);
        }

        Stream GenerateStreamFromString(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        CommentStringLexer lexer;

        public CommentStringLexerTests()
        {
            lexer = new CommentStringLexer();
        }

        [TestMethod]
        public void Lexing_a_global_variable_definition()
        {
            Stream stream = GenerateStreamFromString("int a;");

            var tokens = lexer.GenerateTokens(stream);

            Assert.AreEqual(1, tokens.Count);

            Token expected = new Token(0, 0);
            expected.Text = "int a;";

            AssertTokensEqual(expected, tokens[0]); 
        }

        [TestMethod]
        public void Lexing_two_global_variable_definitions()
        {           
            Stream stream = GenerateStreamFromString("int a;\n    float b;");
            var tokens = lexer.GenerateTokens(stream);

            Assert.AreEqual(2, tokens.Count);

            Token expected1 = new Token(0, 0);
            expected1.Text = "int a;";
            AssertTokensEqual(expected1, tokens[0]);

            Token expected2 = new Token(1, 0);
            expected2.Text = "    float b;";
            AssertTokensEqual(expected2, tokens[1]);
        }

        [TestMethod]
        public void Lexing_a_global_string_variable_definition()
        {
            Stream ss = GenerateStreamFromString("string s = \"Hello World\";");
            
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(3, tokens.Count);

            Token expected0 = new Token(0, 0);
            expected0.Text = "string s = ";
            AssertTokensEqual(expected0, tokens[0]);

            Token expected1 = new Token(0, 11, TokenType.StringToken);
            expected1.Text = "\"Hello World\"";
            AssertTokensEqual(expected1, tokens[1]);

            Token expected2 = new Token(0, 24);
            expected2.Text = ";";
            AssertTokensEqual(expected2, tokens[2]);
        }

        [TestMethod]
        public void Lexing_a_line_after_a_global_string_variable_definition()
        {
           
           Stream ss = GenerateStreamFromString("string s = \"Hello World\";\nint a = 10;");

           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(4, tokens.Count);

           Token expectedToken = new Token(1, 0);
           expectedToken.Text = "int a = 10;";
           AssertTokensEqual(expectedToken, tokens[3]);
        }
        
        [TestMethod]
        public void Lexing_a_global_string_variable_definition_with_a_escaped_double_quote()
        {
           string expectedText = @"""Hello \"" World!""";
           Stream ss = GenerateStreamFromString("string s = " + expectedText + ";");

           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expectedText;
           AssertTokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_global_cpp11_string_variable_definition()
        {
           const string expected = @"R""bookend(""world"")bookend""";
           Stream ss = GenerateStreamFromString("string s = " + expected + ";");
           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expected;
           AssertTokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_global_multi_line_cpp11_string_variable_definition()
        {
           string expected = @"R""bookend(""Hello
world"")bookend""";
           Stream ss = GenerateStreamFromString("string s = " + expected + ";");

           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(3, tokens.Count);

           Token expectedToken = new Token(0, 11, TokenType.StringToken);
           expectedToken.Text = expected;
           AssertTokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_single_line_global_block_comment()
        {
            string expected ="/* Hello World */";
            Stream ss = GenerateStreamFromString(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);
            Token expectedToken = new Token(0, 0, TokenType.Comment);
            expectedToken.Text = expected;
            AssertTokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Lex_valid_code_line_after_block_comment()
        {
            string expectedText = "int a = 10;";
            
            Stream ss = GenerateStreamFromString("/*comment*/\n" + expectedText);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(2, tokens.Count);

            Token expectedToken = new Token(1, 0);
            expectedToken.Text = expectedText;
            AssertTokensEqual(expectedToken, tokens[1]);
        }

        [TestMethod]
        public void  Lexing_a_multi_line_global_block_comment()
        {
            string expected = @"/* Hello 
        world */";
            Stream ss = GenerateStreamFromString(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expectedToken = new Token(0, 0, TokenType.Comment);
            expectedToken.Text = expected;
            AssertTokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Asterisk_as_multiplier_not_part_of_comment()
        {
            string expected = "int a = 5*6;";
            Stream ss = GenerateStreamFromString(expected);
           
           var tokens = lexer.GenerateTokens(ss);

           Assert.AreEqual(1, tokens.Count);

           Token expectedToken = new Token(0, 0);
           expectedToken.Text = expected;
           AssertTokensEqual(expectedToken, tokens[0]);
        }

        [TestMethod]
        public void  Slash_as_divider_not_part_of_comment()
        {
            string expected = "int a = 53/6;";
            Stream ss = GenerateStreamFromString(expected);
           
            var tokens = lexer.GenerateTokens(ss);

            Assert.AreEqual(1, tokens.Count);

            Token expectedToken = new Token(0, 0);
            expectedToken.Text = expected;
            AssertTokensEqual(expectedToken, tokens[0]);
        }

        //public void  Lexing_line_comments)
        //{
        //   
        //   string expected = @"//string s = "blah")";
        //   ss << expected;

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(1, tokens.Count);

        //   Token expectedToken = new Token(0, 0, TokenType.Comment);
        //   expectedToken.Text = expected;
        //   AssertTokensEqual(expectedToken, tokens[0]);
        //}

        //public void  Lexing_line_comment_after_valid_code)
        //{
        //   
        //   string expected = @"//string s = "blah")";
        //   Stream ss = GenerateStreamFromString(int a = 5; " << expected;

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(2, tokens.Count);

        //   Token expectedToken = new Token(0, 11, TokenType.Comment);
        //   expectedToken.Text = expected;
        //   AssertTokensEqual(expectedToken, tokens[1]);
        //}

        //public void  Slash_asterisk_comment_in_the_middle_of_valid_code)
        //{
        //   
        //   Stream ss = GenerateStreamFromString(int a = /*comment*/ 53/6;";

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(3, tokens.Count);

        //   Token expectedToken = new Token(0, 8, TokenType.Comment);
        //   expectedToken.Text = "/*comment*/";
        //   AssertTokensEqual(expectedToken, tokens[1]);
        //}

        //public void  Lexing_valid_code_after_double_slash_comment)
        //{
        //   
        //   ss << @"//string s = "blah"
        //string a = "text";)";

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(4, tokens.Count);

        //   Token expected = new Token(1, 0);
        //   expected.Text = "string a = ";

        //   AssertTokensEqual(expected, tokens[1]);
        //}

        //public void  Lexing_block_comment_after_valid_code)
        //{
        //   
        //   string expected = @"/*something went wrong*/)";
        //   ss << @"cout << "Can't open file!" << endl; )" << expected;

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(4, tokens.Count);

        //   Token expectedToken3(0, 26);
        //   expectedToken3.Text = " << endl; ";
        //   AssertTokensEqual(expectedToken3, tokens[2]);

        //   Token expectedToken4(0, 36, TokenType.Comment);
        //   expectedToken4.Text = expected;
        //   AssertTokensEqual(expectedToken4, tokens[3]);
        //}

        //public void  Lexing_multiline_line_comment)
        //{
        //   
        //   string expectedText = @"//string s = "blah" \
        //and some more blah)";
        //   ss << expectedText;

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(1, tokens.Count);

        //   Token expected = new Token(0, 0, TokenType.Comment);
        //   expected.Text = expectedText;

        //   AssertTokensEqual(expected, tokens[0]);
        //}

        //public void  Number_of_lines_in_single_line_file)
        //{
        //   
        //   ss << @"cout << "Just one line" << endl; )";

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(1, lexer.NumberOfLines());
        //}

        //public void  Number_of_lines_in_multi_line_file)
        //{
        //   
        //   string expectedText = @"//string s = "blah" \
        //and some more blah)";
        //   ss << expectedText;

        //   
        //   var tokens = lexer.GenerateTokens(ss);

        //   AssertTokensEqual(2, lexer.NumberOfLines());
        //}
    }
}
