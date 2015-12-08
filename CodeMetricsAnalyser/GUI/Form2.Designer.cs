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
            this.button_clearWindow = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Filename = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfLines = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CommentPerecent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxWidth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NoOfFunctions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxFuncLen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgFuncLen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxFuncDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgFuncDepth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaxComplexity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AvgComplexity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fileMetricsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileMetricsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Analyse
            // 
            this.button_Analyse.Location = new System.Drawing.Point(401, 22);
            this.button_Analyse.Name = "button_Analyse";
            this.button_Analyse.Size = new System.Drawing.Size(89, 33);
            this.button_Analyse.TabIndex = 0;
            this.button_Analyse.Text = "Analyse";
            this.button_Analyse.UseVisualStyleBackColor = true;
            this.button_Analyse.Click += new System.EventHandler(this.button_Analyse_Click);
            // 
            // button_clearWindow
            // 
            this.button_clearWindow.Location = new System.Drawing.Point(799, 22);
            this.button_clearWindow.Name = "button_clearWindow";
            this.button_clearWindow.Size = new System.Drawing.Size(122, 33);
            this.button_clearWindow.TabIndex = 2;
            this.button_clearWindow.Text = "Clear Window";
            this.button_clearWindow.UseVisualStyleBackColor = true;
            this.button_clearWindow.Visible = false;
            this.button_clearWindow.Click += new System.EventHandler(this.button_clearWindow_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Indigo;
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
            this.NoOfLines,
            this.CommentPerecent,
            this.MaxWidth,
            this.NoOfFunctions,
            this.MaxFuncLen,
            this.AvgFuncLen,
            this.MaxFuncDepth,
            this.AvgFuncDepth,
            this.MaxComplexity,
            this.AvgComplexity});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.Location = new System.Drawing.Point(23, 73);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.Size = new System.Drawing.Size(898, 354);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.Visible = false;
            // 
            // Filename
            // 
            this.Filename.HeaderText = "File Name";
            this.Filename.Name = "Filename";
            this.Filename.ReadOnly = true;
            this.Filename.Width = 230;
            // 
            // NoOfLines
            // 
            this.NoOfLines.HeaderText = "Number of Lines";
            this.NoOfLines.Name = "NoOfLines";
            this.NoOfLines.ReadOnly = true;
            this.NoOfLines.Width = 65;
            // 
            // CommentPerecent
            // 
            this.CommentPerecent.HeaderText = "Comment Percentage";
            this.CommentPerecent.Name = "CommentPerecent";
            this.CommentPerecent.ReadOnly = true;
            this.CommentPerecent.Width = 65;
            // 
            // MaxWidth
            // 
            this.MaxWidth.HeaderText = "Widest Line Width";
            this.MaxWidth.Name = "MaxWidth";
            this.MaxWidth.ReadOnly = true;
            this.MaxWidth.Width = 65;
            // 
            // NoOfFunctions
            // 
            this.NoOfFunctions.HeaderText = "Number Of Functions";
            this.NoOfFunctions.Name = "NoOfFunctions";
            this.NoOfFunctions.ReadOnly = true;
            this.NoOfFunctions.Width = 65;
            // 
            // MaxFuncLen
            // 
            this.MaxFuncLen.HeaderText = "Max Function Length";
            this.MaxFuncLen.Name = "MaxFuncLen";
            this.MaxFuncLen.ReadOnly = true;
            this.MaxFuncLen.Width = 65;
            // 
            // AvgFuncLen
            // 
            this.AvgFuncLen.HeaderText = "Average Function Length";
            this.AvgFuncLen.Name = "AvgFuncLen";
            this.AvgFuncLen.ReadOnly = true;
            this.AvgFuncLen.Width = 65;
            // 
            // MaxFuncDepth
            // 
            this.MaxFuncDepth.HeaderText = "Max Function Depth";
            this.MaxFuncDepth.Name = "MaxFuncDepth";
            this.MaxFuncDepth.ReadOnly = true;
            this.MaxFuncDepth.Width = 65;
            // 
            // AvgFuncDepth
            // 
            this.AvgFuncDepth.HeaderText = "Average Function Depth";
            this.AvgFuncDepth.Name = "AvgFuncDepth";
            this.AvgFuncDepth.ReadOnly = true;
            this.AvgFuncDepth.Width = 65;
            // 
            // MaxComplexity
            // 
            this.MaxComplexity.HeaderText = "Max Complexity";
            this.MaxComplexity.Name = "MaxComplexity";
            this.MaxComplexity.ReadOnly = true;
            this.MaxComplexity.Width = 65;
            // 
            // AvgComplexity
            // 
            this.AvgComplexity.HeaderText = "Average Complexity";
            this.AvgComplexity.Name = "AvgComplexity";
            this.AvgComplexity.ReadOnly = true;
            this.AvgComplexity.Width = 65;
            // 
            // fileMetricsBindingSource
            // 
            this.fileMetricsBindingSource.DataSource = typeof(GUI.FileMetrics);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Indigo;
            this.ClientSize = new System.Drawing.Size(957, 469);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button_clearWindow);
            this.Controls.Add(this.button_Analyse);
            this.Name = "Form2";
            this.Text = "Code Metrics Analyser";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileMetricsBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_Analyse;
        private System.Windows.Forms.BindingSource fileMetricsBindingSource;
        private System.Windows.Forms.Button button_clearWindow;
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Filename;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfLines;
        private System.Windows.Forms.DataGridViewTextBoxColumn CommentPerecent;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxWidth;
        private System.Windows.Forms.DataGridViewTextBoxColumn NoOfFunctions;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxFuncLen;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgFuncLen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxFuncDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgFuncDepth;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxComplexity;
        private System.Windows.Forms.DataGridViewTextBoxColumn AvgComplexity;
    }
}