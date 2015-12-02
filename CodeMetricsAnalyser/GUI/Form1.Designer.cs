namespace GUI
{
    partial class Form1
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
            this.button1_Analyse = new System.Windows.Forms.Button();
            this.label_FnumberOfLines = new System.Windows.Forms.Label();
            this.label_LnumberOfLines = new System.Windows.Forms.Label();
            this.label_LcommentPercent = new System.Windows.Forms.Label();
            this.label_FcommentPercent = new System.Windows.Forms.Label();
            this.label_LlongestLineLength = new System.Windows.Forms.Label();
            this.label_FlongestLineLength = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label_LNumberOfFunctions = new System.Windows.Forms.Label();
            this.label_FNumberOfFunctions = new System.Windows.Forms.Label();
            this.label_LAvgLenOfFunctions = new System.Windows.Forms.Label();
            this.label_FAvgLenOfFunctions = new System.Windows.Forms.Label();
            this.label_LMaxLenOfFunctions = new System.Windows.Forms.Label();
            this.label_FMaxLenOfFunctions = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1_Analyse
            // 
            this.button1_Analyse.Location = new System.Drawing.Point(142, 45);
            this.button1_Analyse.Name = "button1_Analyse";
            this.button1_Analyse.Size = new System.Drawing.Size(75, 23);
            this.button1_Analyse.TabIndex = 0;
            this.button1_Analyse.Text = "Analyse File";
            this.button1_Analyse.UseVisualStyleBackColor = true;
            this.button1_Analyse.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_FnumberOfLines
            // 
            this.label_FnumberOfLines.AutoSize = true;
            this.label_FnumberOfLines.Location = new System.Drawing.Point(144, 22);
            this.label_FnumberOfLines.Name = "label_FnumberOfLines";
            this.label_FnumberOfLines.Size = new System.Drawing.Size(29, 13);
            this.label_FnumberOfLines.TabIndex = 1;
            this.label_FnumberOfLines.Text = "label";
            // 
            // label_LnumberOfLines
            // 
            this.label_LnumberOfLines.AutoSize = true;
            this.label_LnumberOfLines.Location = new System.Drawing.Point(6, 22);
            this.label_LnumberOfLines.Name = "label_LnumberOfLines";
            this.label_LnumberOfLines.Size = new System.Drawing.Size(87, 13);
            this.label_LnumberOfLines.TabIndex = 2;
            this.label_LnumberOfLines.Text = "Number of Lines:";
            // 
            // label_LcommentPercent
            // 
            this.label_LcommentPercent.AutoSize = true;
            this.label_LcommentPercent.Location = new System.Drawing.Point(6, 48);
            this.label_LcommentPercent.Name = "label_LcommentPercent";
            this.label_LcommentPercent.Size = new System.Drawing.Size(117, 13);
            this.label_LcommentPercent.TabIndex = 3;
            this.label_LcommentPercent.Text = "Percentage Comments:";
            // 
            // label_FcommentPercent
            // 
            this.label_FcommentPercent.AutoSize = true;
            this.label_FcommentPercent.Location = new System.Drawing.Point(144, 48);
            this.label_FcommentPercent.Name = "label_FcommentPercent";
            this.label_FcommentPercent.Size = new System.Drawing.Size(27, 13);
            this.label_FcommentPercent.TabIndex = 4;
            this.label_FcommentPercent.Text = "N/A";
            // 
            // label_LlongestLineLength
            // 
            this.label_LlongestLineLength.AutoSize = true;
            this.label_LlongestLineLength.Location = new System.Drawing.Point(6, 35);
            this.label_LlongestLineLength.Name = "label_LlongestLineLength";
            this.label_LlongestLineLength.Size = new System.Drawing.Size(107, 13);
            this.label_LlongestLineLength.TabIndex = 5;
            this.label_LlongestLineLength.Text = "Longest Line Length:";
            // 
            // label_FlongestLineLength
            // 
            this.label_FlongestLineLength.AutoSize = true;
            this.label_FlongestLineLength.Location = new System.Drawing.Point(144, 35);
            this.label_FlongestLineLength.Name = "label_FlongestLineLength";
            this.label_FlongestLineLength.Size = new System.Drawing.Size(35, 13);
            this.label_FlongestLineLength.TabIndex = 6;
            this.label_FlongestLineLength.Text = "label2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label_FMaxLenOfFunctions);
            this.groupBox1.Controls.Add(this.label_LMaxLenOfFunctions);
            this.groupBox1.Controls.Add(this.label_FAvgLenOfFunctions);
            this.groupBox1.Controls.Add(this.label_LAvgLenOfFunctions);
            this.groupBox1.Controls.Add(this.label_FNumberOfFunctions);
            this.groupBox1.Controls.Add(this.label_LNumberOfFunctions);
            this.groupBox1.Controls.Add(this.label_FlongestLineLength);
            this.groupBox1.Controls.Add(this.label_LlongestLineLength);
            this.groupBox1.Controls.Add(this.label_FcommentPercent);
            this.groupBox1.Controls.Add(this.label_LcommentPercent);
            this.groupBox1.Controls.Add(this.label_LnumberOfLines);
            this.groupBox1.Controls.Add(this.label_FnumberOfLines);
            this.groupBox1.Location = new System.Drawing.Point(72, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(220, 203);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // label_LNumberOfFunctions
            // 
            this.label_LNumberOfFunctions.AutoSize = true;
            this.label_LNumberOfFunctions.Location = new System.Drawing.Point(6, 61);
            this.label_LNumberOfFunctions.Name = "label_LNumberOfFunctions";
            this.label_LNumberOfFunctions.Size = new System.Drawing.Size(105, 13);
            this.label_LNumberOfFunctions.TabIndex = 7;
            this.label_LNumberOfFunctions.Text = "Number of Functions";
            // 
            // label_FNumberOfFunctions
            // 
            this.label_FNumberOfFunctions.AutoSize = true;
            this.label_FNumberOfFunctions.Location = new System.Drawing.Point(144, 61);
            this.label_FNumberOfFunctions.Name = "label_FNumberOfFunctions";
            this.label_FNumberOfFunctions.Size = new System.Drawing.Size(35, 13);
            this.label_FNumberOfFunctions.TabIndex = 8;
            this.label_FNumberOfFunctions.Text = "label2";
            // 
            // label_LAvgLenOfFunctions
            // 
            this.label_LAvgLenOfFunctions.AutoSize = true;
            this.label_LAvgLenOfFunctions.Location = new System.Drawing.Point(6, 74);
            this.label_LAvgLenOfFunctions.Name = "label_LAvgLenOfFunctions";
            this.label_LAvgLenOfFunctions.Size = new System.Drawing.Size(106, 13);
            this.label_LAvgLenOfFunctions.TabIndex = 9;
            this.label_LAvgLenOfFunctions.Text = "Avg Function Length";
            // 
            // label_FAvgLenOfFunctions
            // 
            this.label_FAvgLenOfFunctions.AutoSize = true;
            this.label_FAvgLenOfFunctions.Location = new System.Drawing.Point(144, 74);
            this.label_FAvgLenOfFunctions.Name = "label_FAvgLenOfFunctions";
            this.label_FAvgLenOfFunctions.Size = new System.Drawing.Size(35, 13);
            this.label_FAvgLenOfFunctions.TabIndex = 10;
            this.label_FAvgLenOfFunctions.Text = "label4";
            // 
            // label_LMaxLenOfFunctions
            // 
            this.label_LMaxLenOfFunctions.AutoSize = true;
            this.label_LMaxLenOfFunctions.Location = new System.Drawing.Point(6, 87);
            this.label_LMaxLenOfFunctions.Name = "label_LMaxLenOfFunctions";
            this.label_LMaxLenOfFunctions.Size = new System.Drawing.Size(107, 13);
            this.label_LMaxLenOfFunctions.TabIndex = 11;
            this.label_LMaxLenOfFunctions.Text = "Max Function Length";
            // 
            // label_FMaxLenOfFunctions
            // 
            this.label_FMaxLenOfFunctions.AutoSize = true;
            this.label_FMaxLenOfFunctions.Location = new System.Drawing.Point(144, 87);
            this.label_FMaxLenOfFunctions.Name = "label_FMaxLenOfFunctions";
            this.label_FMaxLenOfFunctions.Size = new System.Drawing.Size(35, 13);
            this.label_FMaxLenOfFunctions.TabIndex = 12;
            this.label_FMaxLenOfFunctions.Text = "label6";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(380, 369);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.button1_Analyse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1_Analyse;
        private System.Windows.Forms.Label label_FnumberOfLines;
        private System.Windows.Forms.Label label_LnumberOfLines;
        private System.Windows.Forms.Label label_LcommentPercent;
        private System.Windows.Forms.Label label_FcommentPercent;
        private System.Windows.Forms.Label label_LlongestLineLength;
        private System.Windows.Forms.Label label_FlongestLineLength;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label_FMaxLenOfFunctions;
        private System.Windows.Forms.Label label_LMaxLenOfFunctions;
        private System.Windows.Forms.Label label_FAvgLenOfFunctions;
        private System.Windows.Forms.Label label_LAvgLenOfFunctions;
        private System.Windows.Forms.Label label_FNumberOfFunctions;
        private System.Windows.Forms.Label label_LNumberOfFunctions;
    }
}

