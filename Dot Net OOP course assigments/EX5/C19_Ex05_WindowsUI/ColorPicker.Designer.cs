namespace C19_Ex05_WindowsUI
{
	internal partial class ColorPicker
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
		private void InitializeComponent() {
		this.m_MediumOrchidButton = new System.Windows.Forms.Button();
		this.m_RedButton = new System.Windows.Forms.Button();
		this.m_LimeButton = new System.Windows.Forms.Button();
		this.m_AquaButton = new System.Windows.Forms.Button();
		this.m_MediumBlueButton = new System.Windows.Forms.Button();
		this.m_YellowButton = new System.Windows.Forms.Button();
		this.m_FirebrickButton = new System.Windows.Forms.Button();
		this.m_SnowButton = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// m_MediumOrchidButton
		// 
		this.m_MediumOrchidButton.BackColor = System.Drawing.Color.MediumOrchid;
		this.m_MediumOrchidButton.Location = new System.Drawing.Point(13,13);
		this.m_MediumOrchidButton.Name = "m_MediumOrchidButton";
		this.m_MediumOrchidButton.Size = new System.Drawing.Size(50,50);
		this.m_MediumOrchidButton.TabIndex = 0;
		this.m_MediumOrchidButton.UseVisualStyleBackColor = false;
		this.m_MediumOrchidButton.Click += new System.EventHandler(this.m_MediumOrchidButton_Click);
		// 
		// m_RedButton
		// 
		this.m_RedButton.BackColor = System.Drawing.Color.Red;
		this.m_RedButton.Location = new System.Drawing.Point(69,13);
		this.m_RedButton.Name = "m_RedButton";
		this.m_RedButton.Size = new System.Drawing.Size(50,50);
		this.m_RedButton.TabIndex = 1;
		this.m_RedButton.UseVisualStyleBackColor = false;
		this.m_RedButton.Click += new System.EventHandler(this.m_RedButton_Click);
		// 
		// m_LimeButton
		// 
		this.m_LimeButton.BackColor = System.Drawing.Color.Lime;
		this.m_LimeButton.Location = new System.Drawing.Point(125,13);
		this.m_LimeButton.Name = "m_LimeButton";
		this.m_LimeButton.Size = new System.Drawing.Size(50,50);
		this.m_LimeButton.TabIndex = 2;
		this.m_LimeButton.UseVisualStyleBackColor = false;
		this.m_LimeButton.Click += new System.EventHandler(this.m_LimeButton_Click);
		// 
		// m_AquaButton
		// 
		this.m_AquaButton.BackColor = System.Drawing.Color.Aqua;
		this.m_AquaButton.Location = new System.Drawing.Point(181,13);
		this.m_AquaButton.Name = "m_AquaButton";
		this.m_AquaButton.Size = new System.Drawing.Size(50,50);
		this.m_AquaButton.TabIndex = 3;
		this.m_AquaButton.UseVisualStyleBackColor = false;
		this.m_AquaButton.Click += new System.EventHandler(this.m_AquaButton_Click);
		// 
		// m_MediumBlueButton
		// 
		this.m_MediumBlueButton.BackColor = System.Drawing.Color.MediumBlue;
		this.m_MediumBlueButton.Location = new System.Drawing.Point(13,69);
		this.m_MediumBlueButton.Name = "m_MediumBlueButton";
		this.m_MediumBlueButton.Size = new System.Drawing.Size(50,50);
		this.m_MediumBlueButton.TabIndex = 4;
		this.m_MediumBlueButton.UseVisualStyleBackColor = false;
		this.m_MediumBlueButton.Click += new System.EventHandler(this.m_MediumBlueButton_Click);
		// 
		// m_YellowButton
		// 
		this.m_YellowButton.BackColor = System.Drawing.Color.Yellow;
		this.m_YellowButton.Location = new System.Drawing.Point(69,69);
		this.m_YellowButton.Name = "m_YellowButton";
		this.m_YellowButton.Size = new System.Drawing.Size(50,50);
		this.m_YellowButton.TabIndex = 5;
		this.m_YellowButton.UseVisualStyleBackColor = false;
		this.m_YellowButton.Click += new System.EventHandler(this.m_YellowButton_Click);
		// 
		// m_FirebrickButton
		// 
		this.m_FirebrickButton.BackColor = System.Drawing.Color.Firebrick;
		this.m_FirebrickButton.Location = new System.Drawing.Point(125,69);
		this.m_FirebrickButton.Name = "m_FirebrickButton";
		this.m_FirebrickButton.Size = new System.Drawing.Size(50,50);
		this.m_FirebrickButton.TabIndex = 6;
		this.m_FirebrickButton.UseVisualStyleBackColor = false;
		this.m_FirebrickButton.Click += new System.EventHandler(this.m_FirebrickButton_Click);
		// 
		// m_SnowButton
		// 
		this.m_SnowButton.BackColor = System.Drawing.Color.Snow;
		this.m_SnowButton.Location = new System.Drawing.Point(181,69);
		this.m_SnowButton.Name = "m_SnowButton";
		this.m_SnowButton.Size = new System.Drawing.Size(50,50);
		this.m_SnowButton.TabIndex = 7;
		this.m_SnowButton.UseVisualStyleBackColor = false;
		this.m_SnowButton.Click += new System.EventHandler(this.m_SnowButton_Click);
		// 
		// ColorPicker
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(244,131);
		this.Controls.Add(this.m_SnowButton);
		this.Controls.Add(this.m_FirebrickButton);
		this.Controls.Add(this.m_YellowButton);
		this.Controls.Add(this.m_MediumBlueButton);
		this.Controls.Add(this.m_AquaButton);
		this.Controls.Add(this.m_LimeButton);
		this.Controls.Add(this.m_RedButton);
		this.Controls.Add(this.m_MediumOrchidButton);
		this.DoubleBuffered = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "ColorPicker";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Pick A Color:";
		this.Load += new System.EventHandler(this.ColorPicker_Load);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_MediumOrchidButton;
		private System.Windows.Forms.Button m_RedButton;
		private System.Windows.Forms.Button m_LimeButton;
		private System.Windows.Forms.Button m_AquaButton;
		private System.Windows.Forms.Button m_MediumBlueButton;
		private System.Windows.Forms.Button m_YellowButton;
		private System.Windows.Forms.Button m_FirebrickButton;
		private System.Windows.Forms.Button m_SnowButton;
	}
}