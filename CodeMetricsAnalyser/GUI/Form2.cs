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
        enum Headers
        {
            FileName,
            NoOfLines,
            CommentPercent,
            MaxWidth,
            NoOfFunctions,
            MaxFuncLen,
            AvgFuncLen,
            MaxFuncDepth,
            AvgFuncDepth,
            MaxComplexity,
            AvgComplexity
        }

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
            dataGridView1.DataSource = _metricsList;
            dataGridView1.Columns["Filename"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }

        public void SetVisibility(bool visible)
        {
            groupBox1.Visible = visible;
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

        public void UpdateDisplay()
        {
            foreach (FileMetrics file in _metricsList)
            {
                int n = dataGridView1.Rows.Add();

                dataGridView1.Rows[n].Cells[(int)Headers.FileName].Value = file.Name;
                dataGridView1.Rows[n].Cells[(int)Headers.NoOfLines].Value = file.NumberOfLines;
                dataGridView1.Rows[n].Cells[(int)Headers.CommentPercent].Value = file.CommentPercentage.ToString("F02") + " %";
                dataGridView1.Rows[n].Cells[(int)Headers.MaxWidth].Value = file.MaxWidth;
                dataGridView1.Rows[n].Cells[(int)Headers.NoOfFunctions].Value = file.NumberOfFunctions;
                dataGridView1.Rows[n].Cells[(int)Headers.MaxFuncLen].Value = file.MaxFunctionLength;
                dataGridView1.Rows[n].Cells[(int)Headers.AvgFuncLen].Value = file.AvgFunctionLength.ToString("F02");
                dataGridView1.Rows[n].Cells[(int)Headers.MaxFuncDepth].Value = file.MaxFunctionDepth;
                dataGridView1.Rows[n].Cells[(int)Headers.AvgFuncDepth].Value = file.AvgFunctionDepth.ToString("F02");
                dataGridView1.Rows[n].Cells[(int)Headers.MaxComplexity].Value = file.MaxFunctionComplexity;
                dataGridView1.Rows[n].Cells[(int)Headers.AvgComplexity].Value = file.AvgFunctionComplexity.ToString("F02");
            }

            button_clearWindow.Visible = true;
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
    }
}
