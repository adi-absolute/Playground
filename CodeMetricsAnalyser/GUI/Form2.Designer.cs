namespace GUI
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button_Analyse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tableMetrics = new System.Windows.Forms.TableLayoutPanel();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfLinesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentPercentageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxWidthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberOfFunctionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxFunctionLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgFunctionLengthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxFunctionDepthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgFunctionDepthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.maxFunctionComplexityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.avgFunctionComplexityDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileMetricsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileMetricsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Analyse
            // 
            this.button_Analyse.Location = new System.Drawing.Point(425, 12);
            this.button_Analyse.Name = "button_Analyse";
            this.button_Analyse.Size = new System.Drawing.Size(89, 33);
            this.button_Analyse.TabIndex = 0;
            this.button_Analyse.Text = "Analyse";
            this.button_Analyse.UseVisualStyleBackColor = true;
            this.button_Analyse.Click += new System.EventHandler(this.button_Analyse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dataGridView1);
            this.groupBox1.Controls.Add(this.tableMetrics);
            this.groupBox1.Location = new System.Drawing.Point(25, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(906, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Filename,
            this.numberOfLinesDataGridViewTextBoxColumn,
            this.commentPercentageDataGridViewTextBoxColumn,
            this.maxWidthDataGridViewTextBoxColumn,
            this.numberOfFunctionsDataGridViewTextBoxColumn,
            this.maxFunctionLengthDataGridViewTextBoxColumn,
            this.avgFunctionLengthDataGridViewTextBoxColumn,
            this.maxFunctionDepthDataGridViewTextBoxColumn,
            this.avgFunctionDepthDataGridViewTextBoxColumn,
            this.maxFunctionComplexityDataGridViewTextBoxColumn,
            this.avgFunctionComplexityDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.fileMetricsBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(39, 138);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(846, 182);
            this.dataGridView1.TabIndex = 1;
            // 
            // tableMetrics
            // 
            this.tableMetrics.ColumnCount = 11;
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableMetrics.Location = new System.Drawing.Point(31, 32);
            this.tableMetrics.Name = "tableMetrics";
            this.tableMetrics.RowCount = 2;
            this.tableMetrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMetrics.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableMetrics.Size = new System.Drawing.Size(474, 100);
            this.tableMetrics.TabIndex = 0;
            // 
            // Filename
            // 
            this.Filename.DataPropertyName = "NumberOfLines";
            this.Filename.HeaderText = "File";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            // 
            // numberOfLinesDataGridViewTextBoxColumn
            // 
            this.numberOfLinesDataGridViewTextBoxColumn.DataPropertyName = "NumberOfLines";
            this.numberOfLinesDataGridViewTextBoxColumn.HeaderText = "Number Of Lines";
            this.numberOfLinesDataGridViewTextBoxColumn.Name = "numberOfLinesDataGridViewTextBoxColumn";
            this.numberOfLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfLinesDataGridViewTextBoxColumn.Width = 70;
            // 
            // commentPercentageDataGridViewTextBoxColumn
            // 
            this.commentPercentageDataGridViewTextBoxColumn.DataPropertyName = "CommentPercentage";
            this.commentPercentageDataGridViewTextBoxColumn.HeaderText = "Comment Percentage";
            this.commentPercentageDataGridViewTextBoxColumn.Name = "commentPercentageDataGridViewTextBoxColumn";
            this.commentPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentPercentageDataGridViewTextBoxColumn.Width = 70;
            // 
            // maxWidthDataGridViewTextBoxColumn
            // 
            this.maxWidthDataGridViewTextBoxColumn.DataPropertyName = "MaxWidth";
            this.maxWidthDataGridViewTextBoxColumn.HeaderText = "Max Width";
            this.maxWidthDataGridViewTextBoxColumn.Name = "maxWidthDataGridViewTextBoxColumn";
            this.maxWidthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxWidthDataGridViewTextBoxColumn.Width = 70;
            // 
            // numberOfFunctionsDataGridViewTextBoxColumn
            // 
            this.numberOfFunctionsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfFunctions";
            this.numberOfFunctionsDataGridViewTextBoxColumn.HeaderText = "Number Of Functions";
            this.numberOfFunctionsDataGridViewTextBoxColumn.Name = "numberOfFunctionsDataGridViewTextBoxColumn";
            this.numberOfFunctionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfFunctionsDataGridViewTextBoxColumn.Width = 70;
            // 
            // maxFunctionLengthDataGridViewTextBoxColumn
            // 
            this.maxFunctionLengthDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionLength";
            this.maxFunctionLengthDataGridViewTextBoxColumn.HeaderText = "Max Function Length";
            this.maxFunctionLengthDataGridViewTextBoxColumn.Name = "maxFunctionLengthDataGridViewTextBoxColumn";
            this.maxFunctionLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionLengthDataGridViewTextBoxColumn.Width = 70;
            // 
            // avgFunctionLengthDataGridViewTextBoxColumn
            // 
            this.avgFunctionLengthDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionLength";
            this.avgFunctionLengthDataGridViewTextBoxColumn.HeaderText = "Avg Function Length";
            this.avgFunctionLengthDataGridViewTextBoxColumn.Name = "avgFunctionLengthDataGridViewTextBoxColumn";
            this.avgFunctionLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionLengthDataGridViewTextBoxColumn.Width = 70;
            // 
            // maxFunctionDepthDataGridViewTextBoxColumn
            // 
            this.maxFunctionDepthDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionDepth";
            this.maxFunctionDepthDataGridViewTextBoxColumn.HeaderText = "Max Function Depth";
            this.maxFunctionDepthDataGridViewTextBoxColumn.Name = "maxFunctionDepthDataGridViewTextBoxColumn";
            this.maxFunctionDepthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionDepthDataGridViewTextBoxColumn.Width = 70;
            // 
            // avgFunctionDepthDataGridViewTextBoxColumn
            // 
            this.avgFunctionDepthDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionDepth";
            this.avgFunctionDepthDataGridViewTextBoxColumn.HeaderText = "Avg Function Depth";
            this.avgFunctionDepthDataGridViewTextBoxColumn.Name = "avgFunctionDepthDataGridViewTextBoxColumn";
            this.avgFunctionDepthDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionDepthDataGridViewTextBoxColumn.Width = 70;
            // 
            // maxFunctionComplexityDataGridViewTextBoxColumn
            // 
            this.maxFunctionComplexityDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionComplexity";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.HeaderText = "Max Complexity";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.Name = "maxFunctionComplexityDataGridViewTextBoxColumn";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionComplexityDataGridViewTextBoxColumn.Width = 70;
            // 
            // avgFunctionComplexityDataGridViewTextBoxColumn
            // 
            this.avgFunctionComplexityDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionComplexity";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.HeaderText = "Avg Complexity";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.Name = "avgFunctionComplexityDataGridViewTextBoxColumn";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionComplexityDataGridViewTextBoxColumn.Width = 70;
            // 
            // fileMetricsBindingSource
            // 
            this.fileMetricsBindingSource.DataSource = typeof(GUI.FileMetrics);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(954, 469);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Analyse);
            this.Name = "Form2";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileMetricsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Analyse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TableLayoutPanel tableMetrics;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource fileMetricsBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfLinesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentPercentageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxWidthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberOfFunctionsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxFunctionLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgFunctionLengthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxFunctionDepthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgFunctionDepthDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn maxFunctionComplexityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn avgFunctionComplexityDataGridViewTextBoxColumn;
    }
}