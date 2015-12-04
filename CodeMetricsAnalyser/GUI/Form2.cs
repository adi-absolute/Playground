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
        private List<FileMetrics> metricsList;

        public event FileSelectHandler FilesSelected;

        public Form2()
        {
            InitializeComponent();
            _presenter = new Form2Presenter(this);
            InitialiseTable();
        }

        private void InitialiseTable()
        {
            dataGridView1.DataSource = metricsList;
        }

        public void SetVisibility(bool visible)
        {
            groupBox1.Visible = visible;
        }

        public void SetData(List<FileMetrics> fileMetrics)
        {
            metricsList = fileMetrics;
        }

        private void ClearTable()
        {

        }

        public void UpdateDisplay()
        {
            ClearTable();
            int n = dataGridView1.Rows.Add();

            dataGridView1.Rows[n].Cells[0].Value = metricsList[0].Filename;
            dataGridView1.Rows[n].Cells[1].Value = metricsList[0].NumberOfLines;
        }

        private void button_Analyse_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            openFileDialog1.Filter = "C/C++ Source Files |*.c; *cpp|All Files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;

            openFileDialog1.Multiselect = false;

            var userClickedOK = openFileDialog1.ShowDialog();

            if (userClickedOK != DialogResult.OK)
            {
                return;
            }

            Stream fileStream = openFileDialog1.OpenFile();
            FilesSelected(Path.GetFileName(openFileDialog1.FileName), fileStream);
            fileStream.Close();
        }
    }
}
