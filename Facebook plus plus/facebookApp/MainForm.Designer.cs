namespace facebookApp
{
    public partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_username_logged = new System.Windows.Forms.Label();
            this.picture_smallPictureBox = new System.Windows.Forms.PictureBox();
            this.button_logout = new System.Windows.Forms.Button();
            this.friendListBox = new System.Windows.Forms.ListBox();
            this.friendListLabel = new System.Windows.Forms.Label();
            this.NewFriendsLabel = new System.Windows.Forms.Label();
            this.NoFriendLabel = new System.Windows.Forms.Label();
            this.NewFriendListBox = new System.Windows.Forms.ListBox();
            this.NoFriendListBox = new System.Windows.Forms.ListBox();
            this.PostsListBox = new System.Windows.Forms.ListBox();
            this.postsLabel = new System.Windows.Forms.Label();
            this.LikedPagesListBox = new System.Windows.Forms.ListBox();
            this.LikedPagesLabel = new System.Windows.Forms.Label();
            this.FindDatebutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::facebookApp.Properties.Resources.logo1;
            this.pictureBox1.Location = new System.Drawing.Point(447, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(402, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label_username_logged
            // 
            this.label_username_logged.AutoSize = true;
            this.label_username_logged.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label_username_logged.ForeColor = System.Drawing.Color.Red;
            this.label_username_logged.Location = new System.Drawing.Point(15, 119);
            this.label_username_logged.Name = "label_username_logged";
            this.label_username_logged.Size = new System.Drawing.Size(93, 20);
            this.label_username_logged.TabIndex = 4;
            this.label_username_logged.Text = "undefined :(";
            // 
            // picture_smallPictureBox
            // 
            this.picture_smallPictureBox.Location = new System.Drawing.Point(16, 15);
            this.picture_smallPictureBox.Name = "picture_smallPictureBox";
            this.picture_smallPictureBox.Size = new System.Drawing.Size(100, 50);
            this.picture_smallPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picture_smallPictureBox.TabIndex = 5;
            this.picture_smallPictureBox.TabStop = false;
            // 
            // button_logout
            // 
            this.button_logout.BackColor = System.Drawing.Color.Red;
            this.button_logout.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_logout.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.button_logout.ForeColor = System.Drawing.Color.White;
            this.button_logout.Location = new System.Drawing.Point(23, 150);
            this.button_logout.Name = "button_logout";
            this.button_logout.Size = new System.Drawing.Size(78, 31);
            this.button_logout.TabIndex = 6;
            this.button_logout.Text = "Logout";
            this.button_logout.UseVisualStyleBackColor = false;
            this.button_logout.Click += new System.EventHandler(this.button_logout_Click);
            // 
            // friendListBox
            // 
            this.friendListBox.BackColor = System.Drawing.Color.LightCyan;
            this.friendListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.friendListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.friendListBox.Font = new System.Drawing.Font("Bodoni MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendListBox.ForeColor = System.Drawing.Color.Black;
            this.friendListBox.FormattingEnabled = true;
            this.friendListBox.ItemHeight = 24;
            this.friendListBox.Location = new System.Drawing.Point(1093, 32);
            this.friendListBox.Name = "friendListBox";
            this.friendListBox.ScrollAlwaysVisible = true;
            this.friendListBox.Size = new System.Drawing.Size(204, 264);
            this.friendListBox.TabIndex = 7;
            this.friendListBox.SelectedIndexChanged += new System.EventHandler(this.friendListBox_SelectedIndexChanged);
            // 
            // friendListLabel
            // 
            this.friendListLabel.AutoSize = true;
            this.friendListLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.friendListLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.friendListLabel.Location = new System.Drawing.Point(1154, 6);
            this.friendListLabel.Name = "friendListLabel";
            this.friendListLabel.Size = new System.Drawing.Size(75, 25);
            this.friendListLabel.TabIndex = 8;
            this.friendListLabel.Text = "Friends:";
            // 
            // NewFriendsLabel
            // 
            this.NewFriendsLabel.AutoSize = true;
            this.NewFriendsLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFriendsLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.NewFriendsLabel.Location = new System.Drawing.Point(1100, 320);
            this.NewFriendsLabel.Name = "NewFriendsLabel";
            this.NewFriendsLabel.Size = new System.Drawing.Size(181, 25);
            this.NewFriendsLabel.TabIndex = 9;
            this.NewFriendsLabel.Text = "Newly Added Friends:";
            // 
            // NoFriendLabel
            // 
            this.NoFriendLabel.AutoSize = true;
            this.NoFriendLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoFriendLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.NoFriendLabel.Location = new System.Drawing.Point(1112, 525);
            this.NoFriendLabel.Name = "NoFriendLabel";
            this.NoFriendLabel.Size = new System.Drawing.Size(160, 25);
            this.NoFriendLabel.TabIndex = 10;
            this.NoFriendLabel.Text = "No Longer Friends:";
            // 
            // NewFriendListBox
            // 
            this.NewFriendListBox.BackColor = System.Drawing.Color.LightCyan;
            this.NewFriendListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NewFriendListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NewFriendListBox.Font = new System.Drawing.Font("Bodoni MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NewFriendListBox.ForeColor = System.Drawing.Color.Black;
            this.NewFriendListBox.FormattingEnabled = true;
            this.NewFriendListBox.ItemHeight = 24;
            this.NewFriendListBox.Location = new System.Drawing.Point(1093, 348);
            this.NewFriendListBox.Name = "NewFriendListBox";
            this.NewFriendListBox.ScrollAlwaysVisible = true;
            this.NewFriendListBox.Size = new System.Drawing.Size(204, 144);
            this.NewFriendListBox.TabIndex = 11;
            // 
            // NoFriendListBox
            // 
            this.NoFriendListBox.BackColor = System.Drawing.Color.LightCyan;
            this.NoFriendListBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.NoFriendListBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.NoFriendListBox.Font = new System.Drawing.Font("Bodoni MT Condensed", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoFriendListBox.ForeColor = System.Drawing.Color.Black;
            this.NoFriendListBox.FormattingEnabled = true;
            this.NoFriendListBox.ItemHeight = 24;
            this.NoFriendListBox.Location = new System.Drawing.Point(1093, 554);
            this.NoFriendListBox.Name = "NoFriendListBox";
            this.NoFriendListBox.ScrollAlwaysVisible = true;
            this.NoFriendListBox.Size = new System.Drawing.Size(204, 144);
            this.NoFriendListBox.TabIndex = 12;
            // 
            // PostsListBox
            // 
            this.PostsListBox.BackColor = System.Drawing.Color.LightCyan;
            this.PostsListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.PostsListBox.FormattingEnabled = true;
            this.PostsListBox.ItemHeight = 16;
            this.PostsListBox.Location = new System.Drawing.Point(447, 114);
            this.PostsListBox.Name = "PostsListBox";
            this.PostsListBox.Size = new System.Drawing.Size(402, 228);
            this.PostsListBox.TabIndex = 13;
            this.PostsListBox.SelectedIndexChanged += new System.EventHandler(this.PostsListBox_SelectedIndexChanged);
            // 
            // postsLabel
            // 
            this.postsLabel.AutoSize = true;
            this.postsLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.postsLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.postsLabel.Location = new System.Drawing.Point(311, 114);
            this.postsLabel.Name = "postsLabel";
            this.postsLabel.Size = new System.Drawing.Size(112, 25);
            this.postsLabel.TabIndex = 14;
            this.postsLabel.Text = "recent posts:";
            // 
            // LikedPagesListBox
            // 
            this.LikedPagesListBox.BackColor = System.Drawing.Color.LightCyan;
            this.LikedPagesListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.LikedPagesListBox.FormattingEnabled = true;
            this.LikedPagesListBox.ItemHeight = 16;
            this.LikedPagesListBox.Location = new System.Drawing.Point(447, 379);
            this.LikedPagesListBox.Name = "LikedPagesListBox";
            this.LikedPagesListBox.Size = new System.Drawing.Size(402, 228);
            this.LikedPagesListBox.TabIndex = 15;
            // 
            // LikedPagesLabel
            // 
            this.LikedPagesLabel.AutoSize = true;
            this.LikedPagesLabel.Font = new System.Drawing.Font("Bernard MT Condensed", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LikedPagesLabel.ForeColor = System.Drawing.Color.RoyalBlue;
            this.LikedPagesLabel.Location = new System.Drawing.Point(311, 363);
            this.LikedPagesLabel.Name = "LikedPagesLabel";
            this.LikedPagesLabel.Size = new System.Drawing.Size(114, 25);
            this.LikedPagesLabel.TabIndex = 16;
            this.LikedPagesLabel.Text = "Liked Pages:";
            // 
            // FindDatebutton
            // 
            this.FindDatebutton.Location = new System.Drawing.Point(952, 32);
            this.FindDatebutton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FindDatebutton.Name = "FindDatebutton";
            this.FindDatebutton.Size = new System.Drawing.Size(120, 35);
            this.FindDatebutton.TabIndex = 17;
            this.FindDatebutton.Text = "Find Date Match";
            this.FindDatebutton.UseVisualStyleBackColor = true;
            this.FindDatebutton.Click += new System.EventHandler(this.FindDatebutton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(952, 106);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 33);
            this.button1.TabIndex = 18;
            this.button1.Text = "User Events";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1295, 725);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FindDatebutton);
            this.Controls.Add(this.LikedPagesLabel);
            this.Controls.Add(this.LikedPagesListBox);
            this.Controls.Add(this.postsLabel);
            this.Controls.Add(this.PostsListBox);
            this.Controls.Add(this.NoFriendListBox);
            this.Controls.Add(this.NewFriendListBox);
            this.Controls.Add(this.NoFriendLabel);
            this.Controls.Add(this.NewFriendsLabel);
            this.Controls.Add(this.friendListLabel);
            this.Controls.Add(this.friendListBox);
            this.Controls.Add(this.button_logout);
            this.Controls.Add(this.picture_smallPictureBox);
            this.Controls.Add(this.label_username_logged);
            this.Controls.Add(this.pictureBox1);
            this.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facebook++";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picture_smallPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_username_logged;
        private System.Windows.Forms.PictureBox picture_smallPictureBox;
        private System.Windows.Forms.Button button_logout;
        private System.Windows.Forms.ListBox friendListBox;
        private System.Windows.Forms.Label friendListLabel;
        private System.Windows.Forms.Label NewFriendsLabel;
        private System.Windows.Forms.Label NoFriendLabel;
        private System.Windows.Forms.ListBox NewFriendListBox;
        private System.Windows.Forms.ListBox NoFriendListBox;
        private System.Windows.Forms.ListBox PostsListBox;
        private System.Windows.Forms.Label postsLabel;
        private System.Windows.Forms.ListBox LikedPagesListBox;
        private System.Windows.Forms.Label LikedPagesLabel;
        private System.Windows.Forms.Button FindDatebutton;
        private System.Windows.Forms.Button button1;
    }
}