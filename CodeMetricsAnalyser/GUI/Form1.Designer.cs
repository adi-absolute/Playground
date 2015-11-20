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
            this.SuspendLayout();
            // 
            // button1_Analyse
            // 
            this.button1_Analyse.Location = new System.Drawing.Point(102, 89);
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
            this.label_FnumberOfLines.Location = new System.Drawing.Point(148, 150);
            this.label_FnumberOfLines.Name = "label_FnumberOfLines";
            this.label_FnumberOfLines.Size = new System.Drawing.Size(29, 13);
            this.label_FnumberOfLines.TabIndex = 1;
            this.label_FnumberOfLines.Text = "label";
            // 
            // label_LnumberOfLines
            // 
            this.label_LnumberOfLines.AutoSize = true;
            this.label_LnumberOfLines.Location = new System.Drawing.Point(24, 150);
            this.label_LnumberOfLines.Name = "label_LnumberOfLines";
            this.label_LnumberOfLines.Size = new System.Drawing.Size(87, 13);
            this.label_LnumberOfLines.TabIndex = 2;
            this.label_LnumberOfLines.Text = "Number of Lines:";
            // 
            // label_LcommentPercent
            // 
            this.label_LcommentPercent.AutoSize = true;
            this.label_LcommentPercent.Location = new System.Drawing.Point(24, 176);
            this.label_LcommentPercent.Name = "label_LcommentPercent";
            this.label_LcommentPercent.Size = new System.Drawing.Size(117, 13);
            this.label_LcommentPercent.TabIndex = 3;
            this.label_LcommentPercent.Text = "Percentage Comments:";
            // 
            // label_FcommentPercent
            // 
            this.label_FcommentPercent.AutoSize = true;
            this.label_FcommentPercent.Location = new System.Drawing.Point(148, 176);
            this.label_FcommentPercent.Name = "label_FcommentPercent";
            this.label_FcommentPercent.Size = new System.Drawing.Size(27, 13);
            this.label_FcommentPercent.TabIndex = 4;
            this.label_FcommentPercent.Text = "N/A";
            // 
            // label_LlongestLineLength
            // 
            this.label_LlongestLineLength.AutoSize = true;
            this.label_LlongestLineLength.Location = new System.Drawing.Point(24, 163);
            this.label_LlongestLineLength.Name = "label_LlongestLineLength";
            this.label_LlongestLineLength.Size = new System.Drawing.Size(107, 13);
            this.label_LlongestLineLength.TabIndex = 5;
            this.label_LlongestLineLength.Text = "Longest Line Length:";
            // 
            // label_FlongestLineLength
            // 
            this.label_FlongestLineLength.AutoSize = true;
            this.label_FlongestLineLength.Location = new System.Drawing.Point(148, 163);
            this.label_FlongestLineLength.Name = "label_FlongestLineLength";
            this.label_FlongestLineLength.Size = new System.Drawing.Size(35, 13);
            this.label_FlongestLineLength.TabIndex = 6;
            this.label_FlongestLineLength.Text = "label2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label_FlongestLineLength);
            this.Controls.Add(this.label_LlongestLineLength);
            this.Controls.Add(this.label_FcommentPercent);
            this.Controls.Add(this.label_LcommentPercent);
            this.Controls.Add(this.label_LnumberOfLines);
            this.Controls.Add(this.label_FnumberOfLines);
            this.Controls.Add(this.button1_Analyse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_Analyse;
        private System.Windows.Forms.Label label_FnumberOfLines;
        private System.Windows.Forms.Label label_LnumberOfLines;
        private System.Windows.Forms.Label label_LcommentPercent;
        private System.Windows.Forms.Label label_FcommentPercent;
        private System.Windows.Forms.Label label_LlongestLineLength;
        private System.Windows.Forms.Label label_FlongestLineLength;
    }
}

