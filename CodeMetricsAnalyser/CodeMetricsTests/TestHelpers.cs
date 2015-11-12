using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeMetricsAnalyser;
using System.Collections.Generic;

namespace TestsForCodeMetricsAnalyser
{
    public static class Compare
    {
        public static void TokensEqual(Token t1, Token t2)
        {
            Assert.AreEqual(t1.Column, t2.Column);
            Assert.AreEqual(t1.Line, t2.Line);
            t1.Text = t1.Text.Replace("\r", "");
            Assert.AreEqual(t1.Text, t2.Text);
            Assert.AreEqual(t1.Type, t2.Type);
        }

        public static void TokenListsEqual(List<Token> l1, List<Token> l2)
        {
            Assert.AreEqual(l1.Count, l2.Count);

            for (int i = 0; i < l1.Count; i++)
            {
                TokensEqual(l1[i], l2[i]);
            }
        }
    }

    public static class Generate
    {
        public static Stream StringStream(string s)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(s);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static List<Token> TokenListFromString(string s)
        {
            var commentStringLexer = new CommentStringLexer();

            return commentStringLexer.GenerateTokens(StringStream(s));
        }
    }
}