using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        private void UpdateFields()
        {
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

            UpdateFields();

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
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "C/C++ Source Files |*.c; *cpp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            // Call the ShowDialog method to show the dialog box.
            var userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (userClickedOK == DialogResult.OK)
            {
                // Open the selected file to read.
                System.IO.Stream fileStream = openFileDialog1.OpenFile();

                var c = commentStringLexer.GenerateTokens(fileStream);
                var s = secondPassLexer.SplitTokens(c);

                lines = commentStringLexer.NumberOfLines;

                CalculateCommentPercentage(c);
                UpdateFields();
                
                fileStream.Close();
            }
        }
    }
}
