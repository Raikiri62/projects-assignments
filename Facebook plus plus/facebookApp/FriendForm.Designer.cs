namespace facebookApp
{
    public partial class FriendForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.FriendNameLabel = new System.Windows.Forms.Label();
            this.FriendBirthdayLabel = new System.Windows.Forms.Label();
            this.FriendHometownLabel = new System.Windows.Forms.Label();
            this.FriendPostsListBox = new System.Windows.Forms.ListBox();
            this.friendpictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.friendpictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label3.Location = new System.Drawing.Point(39, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Birthday:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(39, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Hometown:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(39, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 14;
            this.label1.Text = "Name:";
            // 
            // FriendNameLabel
            // 
            this.FriendNameLabel.AutoSize = true;
            this.FriendNameLabel.Location = new System.Drawing.Point(110, 43);
            this.FriendNameLabel.Name = "FriendNameLabel";
            this.FriendNameLabel.Size = new System.Drawing.Size(35, 13);
            this.FriendNameLabel.TabIndex = 13;
            this.FriendNameLabel.Text = "Name";
            // 
            // FriendBirthdayLabel
            // 
            this.FriendBirthdayLabel.AutoSize = true;
            this.FriendBirthdayLabel.Location = new System.Drawing.Point(110, 104);
            this.FriendBirthdayLabel.Name = "FriendBirthdayLabel";
            this.FriendBirthdayLabel.Size = new System.Drawing.Size(45, 13);
            this.FriendBirthdayLabel.TabIndex = 12;
            this.FriendBirthdayLabel.Text = "Birthday";
            // 
            // FriendHometownLabel
            // 
            this.FriendHometownLabel.AutoSize = true;
            this.FriendHometownLabel.Location = new System.Drawing.Point(110, 72);
            this.FriendHometownLabel.Name = "FriendHometownLabel";
            this.FriendHometownLabel.Size = new System.Drawing.Size(58, 13);
            this.FriendHometownLabel.TabIndex = 10;
            this.FriendHometownLabel.Text = "Hometown";
            // 
            // FriendPostsListBox
            // 
            this.FriendPostsListBox.BackColor = System.Drawing.SystemColors.InactiveBorder;
            this.FriendPostsListBox.FormattingEnabled = true;
            this.FriendPostsListBox.Location = new System.Drawing.Point(38, 222);
            this.FriendPostsListBox.Name = "FriendPostsListBox";
            this.FriendPostsListBox.ScrollAlwaysVisible = true;
            this.FriendPostsListBox.Size = new System.Drawing.Size(338, 134);
            this.FriendPostsListBox.TabIndex = 18;
            // 
            // friendpictureBox1
            // 
            this.friendpictureBox1.Location = new System.Drawing.Point(245, 42);
            this.friendpictureBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.friendpictureBox1.Name = "friendpictureBox1";
            this.friendpictureBox1.Size = new System.Drawing.Size(130, 118);
            this.friendpictureBox1.TabIndex = 19;
            this.friendpictureBox1.TabStop = false;
            // 
            // FriendForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(600, 366);
            this.Controls.Add(this.friendpictureBox1);
            this.Controls.Add(this.FriendPostsListBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.FriendNameLabel);
            this.Controls.Add(this.FriendBirthdayLabel);
            this.Controls.Add(this.FriendHometownLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FriendForm";
            this.Text = "FriendForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FriendForm_FormClosing);
            this.Load += new System.EventHandler(this.FriendForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.friendpictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label FriendNameLabel;
        private System.Windows.Forms.Label FriendBirthdayLabel;
        private System.Windows.Forms.Label FriendHometownLabel;
        private System.Windows.Forms.ListBox FriendPostsListBox;
        private System.Windows.Forms.PictureBox friendpictureBox1;
    }
}