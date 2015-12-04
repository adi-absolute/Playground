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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.button_Analyse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button_clearWindow = new System.Windows.Forms.Button();
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
            this.button_Analyse.Location = new System.Drawing.Point(434, 22);
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
            this.groupBox1.Location = new System.Drawing.Point(12, 61);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(972, 387);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 16);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(1, 1, 3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.dataGridView1.Size = new System.Drawing.Size(966, 368);
            this.dataGridView1.TabIndex = 1;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Filename
            // 
            this.Filename.DataPropertyName = "NumberOfLines";
            this.Filename.HeaderText = "File";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Width = 250;
            // 
            // button_clearWindow
            // 
            this.button_clearWindow.Location = new System.Drawing.Point(859, 22);
            this.button_clearWindow.Name = "button_clearWindow";
            this.button_clearWindow.Size = new System.Drawing.Size(122, 33);
            this.button_clearWindow.TabIndex = 2;
            this.button_clearWindow.Text = "Clear Window";
            this.button_clearWindow.UseVisualStyleBackColor = true;
            this.button_clearWindow.Visible = false;
            this.button_clearWindow.Click += new System.EventHandler(this.button_clearWindow_Click);
            // 
            // numberOfLinesDataGridViewTextBoxColumn
            // 
            this.numberOfLinesDataGridViewTextBoxColumn.DataPropertyName = "NumberOfLines";
            this.numberOfLinesDataGridViewTextBoxColumn.HeaderText = "Number Of Lines";
            this.numberOfLinesDataGridViewTextBoxColumn.Name = "numberOfLinesDataGridViewTextBoxColumn";
            this.numberOfLinesDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfLinesDataGridViewTextBoxColumn.Width = 65;
            // 
            // commentPercentageDataGridViewTextBoxColumn
            // 
            this.commentPercentageDataGridViewTextBoxColumn.DataPropertyName = "CommentPercentage";
            this.commentPercentageDataGridViewTextBoxColumn.HeaderText = "Comment Percentage";
            this.commentPercentageDataGridViewTextBoxColumn.Name = "commentPercentageDataGridViewTextBoxColumn";
            this.commentPercentageDataGridViewTextBoxColumn.ReadOnly = true;
            this.commentPercentageDataGridViewTextBoxColumn.Width = 65;
            // 
            // maxWidthDataGridViewTextBoxColumn
            // 
            this.maxWidthDataGridViewTextBoxColumn.DataPropertyName = "MaxWidth";
            this.maxWidthDataGridViewTextBoxColumn.HeaderText = "Max Width";
            this.maxWidthDataGridViewTextBoxColumn.Name = "maxWidthDataGridViewTextBoxColumn";
            this.maxWidthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxWidthDataGridViewTextBoxColumn.Width = 65;
            // 
            // numberOfFunctionsDataGridViewTextBoxColumn
            // 
            this.numberOfFunctionsDataGridViewTextBoxColumn.DataPropertyName = "NumberOfFunctions";
            this.numberOfFunctionsDataGridViewTextBoxColumn.HeaderText = "Number Of Functions";
            this.numberOfFunctionsDataGridViewTextBoxColumn.Name = "numberOfFunctionsDataGridViewTextBoxColumn";
            this.numberOfFunctionsDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberOfFunctionsDataGridViewTextBoxColumn.Width = 65;
            // 
            // maxFunctionLengthDataGridViewTextBoxColumn
            // 
            this.maxFunctionLengthDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionLength";
            this.maxFunctionLengthDataGridViewTextBoxColumn.HeaderText = "Max Function Length";
            this.maxFunctionLengthDataGridViewTextBoxColumn.Name = "maxFunctionLengthDataGridViewTextBoxColumn";
            this.maxFunctionLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionLengthDataGridViewTextBoxColumn.Width = 65;
            // 
            // avgFunctionLengthDataGridViewTextBoxColumn
            // 
            this.avgFunctionLengthDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionLength";
            this.avgFunctionLengthDataGridViewTextBoxColumn.HeaderText = "Avg Function Length";
            this.avgFunctionLengthDataGridViewTextBoxColumn.Name = "avgFunctionLengthDataGridViewTextBoxColumn";
            this.avgFunctionLengthDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionLengthDataGridViewTextBoxColumn.Width = 65;
            // 
            // maxFunctionDepthDataGridViewTextBoxColumn
            // 
            this.maxFunctionDepthDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionDepth";
            this.maxFunctionDepthDataGridViewTextBoxColumn.HeaderText = "Max Function Depth";
            this.maxFunctionDepthDataGridViewTextBoxColumn.Name = "maxFunctionDepthDataGridViewTextBoxColumn";
            this.maxFunctionDepthDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionDepthDataGridViewTextBoxColumn.Width = 65;
            // 
            // avgFunctionDepthDataGridViewTextBoxColumn
            // 
            this.avgFunctionDepthDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionDepth";
            this.avgFunctionDepthDataGridViewTextBoxColumn.HeaderText = "Avg Function Depth";
            this.avgFunctionDepthDataGridViewTextBoxColumn.Name = "avgFunctionDepthDataGridViewTextBoxColumn";
            this.avgFunctionDepthDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionDepthDataGridViewTextBoxColumn.Width = 65;
            // 
            // maxFunctionComplexityDataGridViewTextBoxColumn
            // 
            this.maxFunctionComplexityDataGridViewTextBoxColumn.DataPropertyName = "MaxFunctionComplexity";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.HeaderText = "Max Complexity";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.Name = "maxFunctionComplexityDataGridViewTextBoxColumn";
            this.maxFunctionComplexityDataGridViewTextBoxColumn.ReadOnly = true;
            this.maxFunctionComplexityDataGridViewTextBoxColumn.Width = 65;
            // 
            // avgFunctionComplexityDataGridViewTextBoxColumn
            // 
            this.avgFunctionComplexityDataGridViewTextBoxColumn.DataPropertyName = "AvgFunctionComplexity";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.HeaderText = "Avg Complexity";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.Name = "avgFunctionComplexityDataGridViewTextBoxColumn";
            this.avgFunctionComplexityDataGridViewTextBoxColumn.ReadOnly = true;
            this.avgFunctionComplexityDataGridViewTextBoxColumn.Width = 65;
            // 
            // fileMetricsBindingSource
            // 
            this.fileMetricsBindingSource.DataSource = typeof(GUI.FileMetrics);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 469);
            this.Controls.Add(this.button_clearWindow);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button_Analyse);
            this.Name = "Form2";
            this.Text = "Code Metrics Analyser";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileMetricsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Analyse;
        private System.Windows.Forms.GroupBox groupBox1;
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
        private System.Windows.Forms.Button button_clearWindow;
    }
}