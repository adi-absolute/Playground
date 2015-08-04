namespace CricketSharp
{
    partial class GameWindow
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
            this.listBox_battingFirstSide = new System.Windows.Forms.ListBox();
            this.textBox_selectSideBattingFirst = new System.Windows.Forms.TextBox();
            this.textBox_selectNumberOfOvers = new System.Windows.Forms.TextBox();
            this.numericUpDown_oversSelector = new System.Windows.Forms.NumericUpDown();
            this.textBox_selectTossWinner = new System.Windows.Forms.TextBox();
            this.listBox_selectTossWinner = new System.Windows.Forms.ListBox();
            this.button_startGame = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_oversSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // listBox_battingFirstSide
            // 
            this.listBox_battingFirstSide.FormattingEnabled = true;
            this.listBox_battingFirstSide.Location = new System.Drawing.Point(169, 74);
            this.listBox_battingFirstSide.Name = "listBox_battingFirstSide";
            this.listBox_battingFirstSide.Size = new System.Drawing.Size(120, 30);
            this.listBox_battingFirstSide.TabIndex = 0;
            this.listBox_battingFirstSide.SelectedIndexChanged += new System.EventHandler(this.listBox_battingFirstSide_SelectedIndexChanged);
            // 
            // textBox_selectSideBattingFirst
            // 
            this.textBox_selectSideBattingFirst.Location = new System.Drawing.Point(167, 51);
            this.textBox_selectSideBattingFirst.Multiline = true;
            this.textBox_selectSideBattingFirst.Name = "textBox_selectSideBattingFirst";
            this.textBox_selectSideBattingFirst.ReadOnly = true;
            this.textBox_selectSideBattingFirst.Size = new System.Drawing.Size(122, 17);
            this.textBox_selectSideBattingFirst.TabIndex = 1;
            this.textBox_selectSideBattingFirst.Text = "Select Side Batting First";
            // 
            // textBox_selectNumberOfOvers
            // 
            this.textBox_selectNumberOfOvers.Location = new System.Drawing.Point(297, 51);
            this.textBox_selectNumberOfOvers.Multiline = true;
            this.textBox_selectNumberOfOvers.Name = "textBox_selectNumberOfOvers";
            this.textBox_selectNumberOfOvers.ReadOnly = true;
            this.textBox_selectNumberOfOvers.Size = new System.Drawing.Size(122, 17);
            this.textBox_selectNumberOfOvers.TabIndex = 2;
            this.textBox_selectNumberOfOvers.Text = "Select Number Of Overs";
            // 
            // numericUpDown_oversSelector
            // 
            this.numericUpDown_oversSelector.Location = new System.Drawing.Point(333, 74);
            this.numericUpDown_oversSelector.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numericUpDown_oversSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown_oversSelector.Name = "numericUpDown_oversSelector";
            this.numericUpDown_oversSelector.Size = new System.Drawing.Size(38, 20);
            this.numericUpDown_oversSelector.TabIndex = 3;
            this.numericUpDown_oversSelector.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.numericUpDown_oversSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // textBox_selectTossWinner
            // 
            this.textBox_selectTossWinner.Location = new System.Drawing.Point(41, 51);
            this.textBox_selectTossWinner.Multiline = true;
            this.textBox_selectTossWinner.Name = "textBox_selectTossWinner";
            this.textBox_selectTossWinner.ReadOnly = true;
            this.textBox_selectTossWinner.Size = new System.Drawing.Size(122, 17);
            this.textBox_selectTossWinner.TabIndex = 5;
            this.textBox_selectTossWinner.Text = "Select Toss Winner";
            // 
            // listBox_selectTossWinner
            // 
            this.listBox_selectTossWinner.FormattingEnabled = true;
            this.listBox_selectTossWinner.Location = new System.Drawing.Point(43, 74);
            this.listBox_selectTossWinner.Name = "listBox_selectTossWinner";
            this.listBox_selectTossWinner.Size = new System.Drawing.Size(120, 30);
            this.listBox_selectTossWinner.TabIndex = 4;
            this.listBox_selectTossWinner.SelectedIndexChanged += new System.EventHandler(this.listBox_selectTossWinner_SelectedIndexChanged);
            // 
            // button_startGame
            // 
            this.button_startGame.Location = new System.Drawing.Point(169, 125);
            this.button_startGame.Name = "button_startGame";
            this.button_startGame.Size = new System.Drawing.Size(120, 23);
            this.button_startGame.TabIndex = 6;
            this.button_startGame.Text = "Start Game";
            this.button_startGame.UseVisualStyleBackColor = true;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 261);
            this.Controls.Add(this.button_startGame);
            this.Controls.Add(this.textBox_selectTossWinner);
            this.Controls.Add(this.listBox_selectTossWinner);
            this.Controls.Add(this.numericUpDown_oversSelector);
            this.Controls.Add(this.textBox_selectNumberOfOvers);
            this.Controls.Add(this.textBox_selectSideBattingFirst);
            this.Controls.Add(this.listBox_battingFirstSide);
            this.Name = "GameWindow";
            this.Text = "GameWindow";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_oversSelector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_battingFirstSide;
        private System.Windows.Forms.TextBox textBox_selectSideBattingFirst;
        private System.Windows.Forms.TextBox textBox_selectNumberOfOvers;
        private System.Windows.Forms.NumericUpDown numericUpDown_oversSelector;
        private System.Windows.Forms.TextBox textBox_selectTossWinner;
        private System.Windows.Forms.ListBox listBox_selectTossWinner;
        private System.Windows.Forms.Button button_startGame;
    }
}