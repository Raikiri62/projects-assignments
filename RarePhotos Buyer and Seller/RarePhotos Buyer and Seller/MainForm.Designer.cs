using System.Drawing;

namespace RarePhotos_Buyer_and_Seller
{
    partial class MainForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridViewMarket = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.labelMoney = new System.Windows.Forms.Label();
            this.buttonShowCollection = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.labelUserName = new System.Windows.Forms.Label();
            this.buttonUploadPhoto = new System.Windows.Forms.Button();
            this.FileDialogUploadPhoto = new System.Windows.Forms.OpenFileDialog();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarket)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewMarket
            // 
            this.dataGridViewMarket.AllowUserToAddRows = false;
            this.dataGridViewMarket.AllowUserToDeleteRows = false;
            this.dataGridViewMarket.AllowUserToResizeColumns = false;
            this.dataGridViewMarket.AllowUserToResizeRows = false;
            this.dataGridViewMarket.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewMarket.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewMarket.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewMarket.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewMarket.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewMarket.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.DarkGray;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial Rounded MT Bold", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewMarket.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewMarket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dataGridViewMarket.Location = new System.Drawing.Point(0, 403);
            this.dataGridViewMarket.MultiSelect = false;
            this.dataGridViewMarket.Name = "dataGridViewMarket";
            this.dataGridViewMarket.ReadOnly = true;
            this.dataGridViewMarket.RowHeadersWidth = 60;
            this.dataGridViewMarket.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewMarket.Size = new System.Drawing.Size(1505, 334);
            this.dataGridViewMarket.TabIndex = 0;
            this.dataGridViewMarket.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dataGridViewMarket_CellMouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(216, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "Amount of Money you have:";
            // 
            // labelMoney
            // 
            this.labelMoney.AutoSize = true;
            this.labelMoney.BackColor = System.Drawing.Color.Transparent;
            this.labelMoney.Font = new System.Drawing.Font("Calisto MT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMoney.ForeColor = System.Drawing.Color.White;
            this.labelMoney.Location = new System.Drawing.Point(12, 106);
            this.labelMoney.Name = "labelMoney";
            this.labelMoney.Size = new System.Drawing.Size(89, 31);
            this.labelMoney.TabIndex = 3;
            this.labelMoney.Text = "1500 $";
            // 
            // buttonShowCollection
            // 
            this.buttonShowCollection.BackColor = System.Drawing.Color.Black;
            this.buttonShowCollection.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonShowCollection.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonShowCollection.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonShowCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShowCollection.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonShowCollection.ForeColor = System.Drawing.Color.White;
            this.buttonShowCollection.Location = new System.Drawing.Point(70, 301);
            this.buttonShowCollection.Name = "buttonShowCollection";
            this.buttonShowCollection.Size = new System.Drawing.Size(198, 65);
            this.buttonShowCollection.TabIndex = 4;
            this.buttonShowCollection.Text = "Show My Photos Collection";
            this.buttonShowCollection.UseVisualStyleBackColor = false;
            this.buttonShowCollection.Click += new System.EventHandler(this.buttonShowCollection_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Calisto MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "logged in as:";
            // 
            // labelUserName
            // 
            this.labelUserName.AutoSize = true;
            this.labelUserName.BackColor = System.Drawing.Color.Transparent;
            this.labelUserName.Font = new System.Drawing.Font("Calisto MT", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUserName.ForeColor = System.Drawing.Color.White;
            this.labelUserName.Location = new System.Drawing.Point(12, 35);
            this.labelUserName.Name = "labelUserName";
            this.labelUserName.Size = new System.Drawing.Size(117, 28);
            this.labelUserName.TabIndex = 6;
            this.labelUserName.Text = "username";
            // 
            // buttonUploadPhoto
            // 
            this.buttonUploadPhoto.BackColor = System.Drawing.Color.Black;
            this.buttonUploadPhoto.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonUploadPhoto.FlatAppearance.MouseDownBackColor = System.Drawing.Color.DimGray;
            this.buttonUploadPhoto.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DimGray;
            this.buttonUploadPhoto.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUploadPhoto.Font = new System.Drawing.Font("Bell MT", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonUploadPhoto.ForeColor = System.Drawing.Color.White;
            this.buttonUploadPhoto.Location = new System.Drawing.Point(1214, 301);
            this.buttonUploadPhoto.Name = "buttonUploadPhoto";
            this.buttonUploadPhoto.Size = new System.Drawing.Size(198, 65);
            this.buttonUploadPhoto.TabIndex = 9;
            this.buttonUploadPhoto.Text = "Upload Photo";
            this.buttonUploadPhoto.UseVisualStyleBackColor = false;
            this.buttonUploadPhoto.Click += new System.EventHandler(this.buttonUploadPhoto_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::RarePhotos_Buyer_and_Seller.Properties.Resources.pinterest_profile_image;
            this.pictureBox1.Location = new System.Drawing.Point(585, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(330, 330);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Image = global::RarePhotos_Buyer_and_Seller.Properties.Resources.hiclipart_com;
            this.pictureBox2.Location = new System.Drawing.Point(1469, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 11;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = global::RarePhotos_Buyer_and_Seller.Properties.Resources.backColor;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1505, 737);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonUploadPhoto);
            this.Controls.Add(this.labelUserName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonShowCollection);
            this.Controls.Add(this.labelMoney);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewMarket);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewMarket)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewMarket;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelMoney;
        private System.Windows.Forms.Button buttonShowCollection;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labelUserName;
        private System.Windows.Forms.Button buttonUploadPhoto;
        private System.Windows.Forms.OpenFileDialog FileDialogUploadPhoto;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}