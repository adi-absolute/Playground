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
        public int lines = 0;

        private void UpdateNumberOfLines()
        {
            label_numberOfLines.Text = lines.ToString();
        }

        public Form1()
        {
            InitializeComponent();

            UpdateNumberOfLines();

            commentStringLexer = new CommentStringLexer();
            secondPassLexer = new SecondPassLexer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            // Set filter options and filter index.
            openFileDialog1.Filter = "Text Files (.txt)|*.txt|All Files (*.*)|*.*";
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

                UpdateNumberOfLines();
                
                fileStream.Close();
            }
        }
    }
}
