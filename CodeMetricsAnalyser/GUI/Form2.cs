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

namespace GUI
{
    public partial class Form2 : Form, IView
    {
        private Form2Presenter _presenter;
        private List<FileMetrics> _metricsList;

        private int _numberOfRows = 1;
        private const int c_maxRows = 10;

        public event FileSelectHandler FilesSelected;

        public Form2()
        {
            InitializeComponent();
            _presenter = new Form2Presenter(this);
            InitialiseTable();
        }

        private void InitialiseTable()
        {
            dataGridView1.Columns["Filename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public void SetVisibility(bool visible)
        {
            dataGridView1.Visible = visible;
        }

        public void SetData(List<FileMetrics> fileMetrics)
        {
            _metricsList = fileMetrics;
        }

        private void ClearTable()
        {
            dataGridView1.Rows.Clear();            

            _metricsList = new List<FileMetrics>();
            
        }

        private string FormatCellText(Metric metric, decimal value)
        {
            string formattedText; 
            switch (metric)
            {
                case Metric.CommentPercent:
                    formattedText = value.ToString("F02") + " %";
                    break;
                case Metric.AvgFuncLen:
                case Metric.AvgFuncDepth:
                case Metric.AvgComplexity:
                    formattedText = value.ToString("F02");
                    break;
                case Metric.NoOfMetrics:
                    throw new Exception();
                default:
                    formattedText = value.ToString();
                    break;
            }
            return formattedText;
        }

        public void UpdateDisplay()
        {
            foreach (FileMetrics file in _metricsList)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[0].Value = file.Name;

                foreach (Metric foo in Enum.GetValues(typeof(Metric)))
                {
                    if (foo == Metric.NoOfMetrics)
                        break;

                    decimal value = file.MetricValue[(int)foo];
                    var cell = dataGridView1.Rows[n].Cells[(int)foo + 1];

                    cell.Value = FormatCellText(foo, value);

                    if (file.GetMetricLevel(foo) == Level.Warning)
                    {
                        cell.Style.BackColor = Color.Orange;
                        cell.ToolTipText = "Greater than " + FormatCellText(foo, file.WarningLevel(foo));
                    }
                    else if (file.GetMetricLevel(foo) == Level.Danger)
                    {
                        cell.Style.BackColor = Color.Red;
                        cell.ToolTipText = "Greater than " + FormatCellText(foo, file.DangerLevel(foo));
                    }
                }
            }

            button_clearWindow.Visible = true;
            panel1.Visible = true;
        }

        private void button_Analyse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "C/C++ Source Files |*.c; *cpp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = true;

            var userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK != DialogResult.OK)
            {
                return;
            }

            var fileNames = openFileDialog1.FileNames;
            _numberOfRows = fileNames.Length;

            if (_numberOfRows == 0)
                return;

            List<FileInfo> files = new List<FileInfo>();

            foreach (string path in fileNames)
            {
                var reader = new StreamReader(path);
                var fileStream = reader.BaseStream;

                var fileInfo = new FileInfo(Path.GetFileName(path), fileStream);
                files.Add(fileInfo);
            }

            FilesSelected(files);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button_clearWindow_Click(object sender, EventArgs e)
        {
            ClearTable();
            button_clearWindow.Visible = false;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
