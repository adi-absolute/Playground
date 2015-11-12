using System.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CodeMetricsAnalyser;

namespace TestsForCodeMetricsAnalyser
{
    public static class Compare
    {
        public static void Tokens(Token t1, Token t2)
        {
            Assert.AreEqual(t1.Column, t2.Column);
            Assert.AreEqual(t1.Line, t2.Line);
            t1.Text = t1.Text.Replace("\r", "");
            Assert.AreEqual(t1.Text, t2.Text);
            Assert.AreEqual(t1.Type, t2.Type);
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
    }
}