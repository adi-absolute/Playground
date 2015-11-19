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
            this.label_numberOfLines = new System.Windows.Forms.Label();
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
            // label_numberOfLines
            // 
            this.label_numberOfLines.AutoSize = true;
            this.label_numberOfLines.Location = new System.Drawing.Point(109, 161);
            this.label_numberOfLines.Name = "label_numberOfLines";
            this.label_numberOfLines.Size = new System.Drawing.Size(29, 13);
            this.label_numberOfLines.TabIndex = 1;
            this.label_numberOfLines.Text = "label";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.label_numberOfLines);
            this.Controls.Add(this.button1_Analyse);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1_Analyse;
        private System.Windows.Forms.Label label_numberOfLines;
    }
}

