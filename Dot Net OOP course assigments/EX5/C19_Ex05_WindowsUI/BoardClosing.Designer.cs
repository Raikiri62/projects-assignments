namespace C19_Ex05_WindowsUI
{
	internal partial class BoardClosing
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
		this.m_ButtonReturnToTheCurrentGame = new System.Windows.Forms.Button();
		this.m_ButtonStartANewGame = new System.Windows.Forms.Button();
		this.m_ButtonExitApplication = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// m_ButtonReturnToTheCurrentGame
		// 
		this.m_ButtonReturnToTheCurrentGame.Location = new System.Drawing.Point(13,13);
		this.m_ButtonReturnToTheCurrentGame.Name = "m_ButtonReturnToTheCurrentGame";
		this.m_ButtonReturnToTheCurrentGame.Size = new System.Drawing.Size(150,23);
		this.m_ButtonReturnToTheCurrentGame.TabIndex = 0;
		this.m_ButtonReturnToTheCurrentGame.Text = "Return to the current game";
		this.m_ButtonReturnToTheCurrentGame.UseVisualStyleBackColor = true;
		this.m_ButtonReturnToTheCurrentGame.Click += new System.EventHandler(this.m_ButtonReturnToTheCurrentGame_Click);
		// 
		// m_ButtonStartANewGame
		// 
		this.m_ButtonStartANewGame.Location = new System.Drawing.Point(12,42);
		this.m_ButtonStartANewGame.Name = "m_ButtonStartANewGame";
		this.m_ButtonStartANewGame.Size = new System.Drawing.Size(150,23);
		this.m_ButtonStartANewGame.TabIndex = 1;
		this.m_ButtonStartANewGame.Text = "Start a new game";
		this.m_ButtonStartANewGame.UseVisualStyleBackColor = true;
		this.m_ButtonStartANewGame.Click += new System.EventHandler(this.m_ButtonStartANewGame_Click);
		// 
		// m_ButtonExitApplication
		// 
		this.m_ButtonExitApplication.Location = new System.Drawing.Point(13,72);
		this.m_ButtonExitApplication.Name = "m_ButtonExitApplication";
		this.m_ButtonExitApplication.Size = new System.Drawing.Size(150,23);
		this.m_ButtonExitApplication.TabIndex = 2;
		this.m_ButtonExitApplication.Text = "Exit Game";
		this.m_ButtonExitApplication.UseVisualStyleBackColor = true;
		this.m_ButtonExitApplication.Click += new System.EventHandler(this.m_ButtonExitApplication_Click);
		// 
		// BoardClosing
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(170,102);
		this.ControlBox = false;
		this.Controls.Add(this.m_ButtonExitApplication);
		this.Controls.Add(this.m_ButtonStartANewGame);
		this.Controls.Add(this.m_ButtonReturnToTheCurrentGame);
		this.DoubleBuffered = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "BoardClosing";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "What would you like to do?";
		this.Load += new System.EventHandler(this.BoardClosing_Load);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_ButtonReturnToTheCurrentGame;
		private System.Windows.Forms.Button m_ButtonStartANewGame;
		private System.Windows.Forms.Button m_ButtonExitApplication;
	}
}