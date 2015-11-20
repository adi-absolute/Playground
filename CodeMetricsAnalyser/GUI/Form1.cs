using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using CodeMetricsAnalyser;

namespace GUI
{
    public partial class Form1 : Form
    {
        CommentStringLexer commentStringLexer;
        SecondPassLexer secondPassLexer;
        int lines = 0;
        long commentChars = 0;
        long totalChars = 0;
        long maxLength = 0;

        private void UpdateFields(string fileName)
        {
            groupBox1.Visible = true;
            groupBox1.Text = fileName;

            label_FnumberOfLines.Text = lines.ToString();
            label_FlongestLineLength.Text = maxLength.ToString() + " chars";
            if (totalChars == 0)
                return;
            long percentage = commentChars*100/totalChars;
            label_FcommentPercent.Text = percentage.ToString("F02") + " %";
        }

        public Form1()
        {
            InitializeComponent();

            commentStringLexer = new CommentStringLexer();
            secondPassLexer = new SecondPassLexer();
        }

        void CalculateCommentPercentage(List<Token> tokens)
        {
            //int tokenCounter = 0;            
            
            foreach (Token t in tokens)
            {
                long charCount = t.Text.Length;

                if (charCount > maxLength)
                    maxLength = charCount;

                totalChars += charCount;

                if (t.Type == TokenType.Comment)
                    commentChars += charCount;

                //cout << "*" << setw(2) << tokenCounter <<  "* " << token.text << endl;
                //tokenCounter++;  // Random comment \ with multiple slashes \
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "C/C++ Source Files |*.c; *cpp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            var userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK == DialogResult.OK)
            {
                System.IO.Stream fileStream = openFileDialog1.OpenFile();

                var c = commentStringLexer.GenerateTokens(fileStream);
                var s = secondPassLexer.SplitTokens(c);

                lines = commentStringLexer.NumberOfLines;

                CalculateCommentPercentage(c);
                UpdateFields(Path.GetFileName(openFileDialog1.FileName));
                
                fileStream.Close();
            }
        }
    }
}
