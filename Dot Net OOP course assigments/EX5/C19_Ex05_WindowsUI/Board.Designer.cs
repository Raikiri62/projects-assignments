namespace C19_Ex05_WindowsUI
{
	internal partial class Board
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
			if(disposing && (components != null))
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
		this.m_PasswordButton1 = new System.Windows.Forms.Button();
		this.m_PasswordButton2 = new System.Windows.Forms.Button();
		this.m_PasswordButton3 = new System.Windows.Forms.Button();
		this.m_PasswordButton4 = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// m_PasswordButton1
		// 
		this.m_PasswordButton1.BackColor = System.Drawing.Color.Black;
		this.m_PasswordButton1.Enabled = false;
		this.m_PasswordButton1.Location = new System.Drawing.Point(12,12);
		this.m_PasswordButton1.Name = "m_PasswordButton1";
		this.m_PasswordButton1.Size = new System.Drawing.Size(50,50);
		this.m_PasswordButton1.TabIndex = 0;
		this.m_PasswordButton1.UseVisualStyleBackColor = false;
		// 
		// m_PasswordButton2
		// 
		this.m_PasswordButton2.BackColor = System.Drawing.Color.Black;
		this.m_PasswordButton2.Enabled = false;
		this.m_PasswordButton2.Location = new System.Drawing.Point(68,12);
		this.m_PasswordButton2.Name = "m_PasswordButton2";
		this.m_PasswordButton2.Size = new System.Drawing.Size(50,50);
		this.m_PasswordButton2.TabIndex = 1;
		this.m_PasswordButton2.UseVisualStyleBackColor = false;
		// 
		// m_PasswordButton3
		// 
		this.m_PasswordButton3.BackColor = System.Drawing.Color.Black;
		this.m_PasswordButton3.Enabled = false;
		this.m_PasswordButton3.Location = new System.Drawing.Point(124,12);
		this.m_PasswordButton3.Name = "m_PasswordButton3";
		this.m_PasswordButton3.Size = new System.Drawing.Size(50,50);
		this.m_PasswordButton3.TabIndex = 2;
		this.m_PasswordButton3.UseVisualStyleBackColor = false;
		// 
		// m_PasswordButton4
		// 
		this.m_PasswordButton4.BackColor = System.Drawing.Color.Black;
		this.m_PasswordButton4.Enabled = false;
		this.m_PasswordButton4.Location = new System.Drawing.Point(180,12);
		this.m_PasswordButton4.Name = "m_PasswordButton4";
		this.m_PasswordButton4.Size = new System.Drawing.Size(50,50);
		this.m_PasswordButton4.TabIndex = 3;
		this.m_PasswordButton4.UseVisualStyleBackColor = false;
		// 
		// Board
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(309,71);
		this.Controls.Add(this.m_PasswordButton4);
		this.Controls.Add(this.m_PasswordButton3);
		this.Controls.Add(this.m_PasswordButton2);
		this.Controls.Add(this.m_PasswordButton1);
		this.DoubleBuffered = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "Board";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Bool Pgia";
		this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Board_FormClosing);
		this.Load += new System.EventHandler(this.Board_Load);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_PasswordButton1;
		private System.Windows.Forms.Button m_PasswordButton2;
		private System.Windows.Forms.Button m_PasswordButton3;
		private System.Windows.Forms.Button m_PasswordButton4;
	}
}