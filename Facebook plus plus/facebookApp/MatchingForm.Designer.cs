namespace facebookApp
{
    public partial class MatchingForm
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
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.listBoxSecondBestMatch = new System.Windows.Forms.ListBox();
            this.listBoxBestMatch = new System.Windows.Forms.ListBox();
            this.listBoxGender = new System.Windows.Forms.ListBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.textBoxLocationSearch = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.listBoxAgeRange = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(342, 30);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(78, 17);
            this.label16.TabIndex = 20;
            this.label16.Text = "Best Match";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(551, 30);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(130, 17);
            this.label15.TabIndex = 19;
            this.label15.Text = "Second Best Match";
            // 
            // listBoxSecondBestMatch
            // 
            this.listBoxSecondBestMatch.FormattingEnabled = true;
            this.listBoxSecondBestMatch.ItemHeight = 16;
            this.listBoxSecondBestMatch.Location = new System.Drawing.Point(554, 64);
            this.listBoxSecondBestMatch.Name = "listBoxSecondBestMatch";
            this.listBoxSecondBestMatch.Size = new System.Drawing.Size(136, 132);
            this.listBoxSecondBestMatch.TabIndex = 18;
            // 
            // listBoxBestMatch
            // 
            this.listBoxBestMatch.FormattingEnabled = true;
            this.listBoxBestMatch.ItemHeight = 16;
            this.listBoxBestMatch.Location = new System.Drawing.Point(345, 64);
            this.listBoxBestMatch.Name = "listBoxBestMatch";
            this.listBoxBestMatch.Size = new System.Drawing.Size(136, 132);
            this.listBoxBestMatch.TabIndex = 17;
            // 
            // listBoxGender
            // 
            this.listBoxGender.FormattingEnabled = true;
            this.listBoxGender.ItemHeight = 16;
            this.listBoxGender.Items.AddRange(new object[] {
            "male",
            "female"});
            this.listBoxGender.Location = new System.Drawing.Point(29, 50);
            this.listBoxGender.Name = "listBoxGender";
            this.listBoxGender.Size = new System.Drawing.Size(118, 36);
            this.listBoxGender.TabIndex = 16;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(29, 30);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(99, 17);
            this.label14.TabIndex = 15;
            this.label14.Text = "Select Gender";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 201);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(98, 17);
            this.label13.TabIndex = 14;
            this.label13.Text = "Type Location";
            // 
            // textBoxLocationSearch
            // 
            this.textBoxLocationSearch.Location = new System.Drawing.Point(26, 221);
            this.textBoxLocationSearch.Name = "textBoxLocationSearch";
            this.textBoxLocationSearch.Size = new System.Drawing.Size(173, 22);
            this.textBoxLocationSearch.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(29, 98);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(122, 17);
            this.label12.TabIndex = 12;
            this.label12.Text = "Select Age Range";
            // 
            // listBoxAgeRange
            // 
            this.listBoxAgeRange.FormattingEnabled = true;
            this.listBoxAgeRange.ItemHeight = 16;
            this.listBoxAgeRange.Items.AddRange(new object[] {
            "20-40",
            "40-60",
            "60-80"});
            this.listBoxAgeRange.Location = new System.Drawing.Point(29, 118);
            this.listBoxAgeRange.Name = "listBoxAgeRange";
            this.listBoxAgeRange.Size = new System.Drawing.Size(75, 52);
            this.listBoxAgeRange.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(26, 283);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "Search";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // MatchingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.listBoxSecondBestMatch);
            this.Controls.Add(this.listBoxBestMatch);
            this.Controls.Add(this.listBoxGender);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.textBoxLocationSearch);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.listBoxAgeRange);
            this.Name = "MatchingForm";
            this.Text = "MatchingForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MatchingForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.ListBox listBoxSecondBestMatch;
        private System.Windows.Forms.ListBox listBoxBestMatch;
        private System.Windows.Forms.ListBox listBoxGender;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox textBoxLocationSearch;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ListBox listBoxAgeRange;
        private System.Windows.Forms.Button button1;
    }
}