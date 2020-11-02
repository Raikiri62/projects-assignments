namespace RarePhotos_Buyer_and_Seller
{
    partial class PhotosCollectionForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PhotosCollectionForm));
            this.imageListView1 = new Manina.Windows.Forms.ImageListView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.labelPhotoID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.buttonSell = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.buttonDeletePhoto = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // imageListView1
            // 
            this.imageListView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imageListView1.BackColor = System.Drawing.Color.White;
            this.imageListView1.BackgroundImage = global::RarePhotos_Buyer_and_Seller.Properties.Resources.backColor;
            this.imageListView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.imageListView1.Colors = new Manina.Windows.Forms.ImageListViewColor(resources.GetString("imageListView1.Colors"));
            this.imageListView1.Location = new System.Drawing.Point(12, 12);
            this.imageListView1.Name = "imageListView1";
            this.imageListView1.PersistentCacheDirectory = "";
            this.imageListView1.PersistentCacheSize = ((long)(100));
            this.imageListView1.Size = new System.Drawing.Size(1187, 436);
            this.imageListView1.TabIndex = 0;
            this.imageListView1.UseWIC = true;
            this.imageListView1.View = Manina.Windows.Forms.View.Gallery;
            this.imageListView1.ItemClick += new Manina.Windows.Forms.ItemClickEventHandler(this.imageListView1_ItemClick);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.buttonDeletePhoto);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxDescription);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.labelPhotoID);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.textBoxPrice);
            this.panel1.Controls.Add(this.buttonSell);
            this.panel1.Location = new System.Drawing.Point(12, 466);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1216, 142);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(451, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 22);
            this.label3.TabIndex = 9;
            this.label3.Text = "Description:";
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.BackColor = System.Drawing.Color.Black;
            this.textBoxDescription.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDescription.ForeColor = System.Drawing.Color.White;
            this.textBoxDescription.Location = new System.Drawing.Point(455, 59);
            this.textBoxDescription.Multiline = true;
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(287, 41);
            this.textBoxDescription.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(33, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(166, 22);
            this.label2.TabIndex = 7;
            this.label2.Text = "Selected Photo Id:";
            // 
            // labelPhotoID
            // 
            this.labelPhotoID.AutoSize = true;
            this.labelPhotoID.BackColor = System.Drawing.Color.Transparent;
            this.labelPhotoID.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPhotoID.ForeColor = System.Drawing.Color.White;
            this.labelPhotoID.Location = new System.Drawing.Point(76, 78);
            this.labelPhotoID.Name = "labelPhotoID";
            this.labelPhotoID.Size = new System.Drawing.Size(89, 22);
            this.labelPhotoID.TabIndex = 6;
            this.labelPhotoID.Text = "Photo ID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(238, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 22);
            this.label1.TabIndex = 5;
            this.label1.Text = "Name Your Price:";
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.BackColor = System.Drawing.Color.Black;
            this.textBoxPrice.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPrice.ForeColor = System.Drawing.Color.White;
            this.textBoxPrice.Location = new System.Drawing.Point(242, 59);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(164, 25);
            this.textBoxPrice.TabIndex = 3;
            // 
            // buttonSell
            // 
            this.buttonSell.BackColor = System.Drawing.Color.Black;
            this.buttonSell.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSell.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSell.ForeColor = System.Drawing.Color.White;
            this.buttonSell.Location = new System.Drawing.Point(780, 43);
            this.buttonSell.Name = "buttonSell";
            this.buttonSell.Size = new System.Drawing.Size(175, 57);
            this.buttonSell.TabIndex = 2;
            this.buttonSell.Text = "Sell Selected photo";
            this.buttonSell.UseVisualStyleBackColor = false;
            this.buttonSell.Click += new System.EventHandler(this.buttonSell_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::RarePhotos_Buyer_and_Seller.Properties.Resources.hiclipart_com;
            this.pictureBox2.Location = new System.Drawing.Point(1224, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 12;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // buttonDeletePhoto
            // 
            this.buttonDeletePhoto.BackColor = System.Drawing.Color.Black;
            this.buttonDeletePhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDeletePhoto.Font = new System.Drawing.Font("Calisto MT", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonDeletePhoto.ForeColor = System.Drawing.Color.White;
            this.buttonDeletePhoto.Location = new System.Drawing.Point(997, 43);
            this.buttonDeletePhoto.Name = "buttonDeletePhoto";
            this.buttonDeletePhoto.Size = new System.Drawing.Size(175, 57);
            this.buttonDeletePhoto.TabIndex = 10;
            this.buttonDeletePhoto.Text = "Delete Selected photo";
            this.buttonDeletePhoto.UseVisualStyleBackColor = false;
            this.buttonDeletePhoto.Click += new System.EventHandler(this.buttonDeletePhoto_Click);
            // 
            // PhotosCollectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::RarePhotos_Buyer_and_Seller.Properties.Resources.backColor;
            this.ClientSize = new System.Drawing.Size(1266, 658);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.imageListView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "PhotosCollectionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PhotosCollectionForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PhotosCollectionForm_FormClosing);
            this.Load += new System.EventHandler(this.PhotosCollectionForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Manina.Windows.Forms.ImageListView imageListView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonSell;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelPhotoID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Button buttonDeletePhoto;
    }
}