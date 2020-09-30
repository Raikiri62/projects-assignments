namespace C19_Ex05_WindowsUI
{
	internal partial class NumberOfChances
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
		this.m_ButtonNumberOfChances = new System.Windows.Forms.Button();
		this.ButtonStart = new System.Windows.Forms.Button();
		this.SuspendLayout();
		// 
		// m_ButtonNumberOfChances
		// 
		this.m_ButtonNumberOfChances.Location = new System.Drawing.Point(13,13);
		this.m_ButtonNumberOfChances.Name = "m_ButtonNumberOfChances";
		this.m_ButtonNumberOfChances.Size = new System.Drawing.Size(259,23);
		this.m_ButtonNumberOfChances.TabIndex = 0;
		this.m_ButtonNumberOfChances.Text = "Number of chances: 4";
		this.m_ButtonNumberOfChances.UseVisualStyleBackColor = true;
		this.m_ButtonNumberOfChances.Click += new System.EventHandler(this.ButtonNumberOfChances_Click);
		// 
		// ButtonStart
		// 
		this.ButtonStart.Location = new System.Drawing.Point(197,76);
		this.ButtonStart.Name = "ButtonStart";
		this.ButtonStart.Size = new System.Drawing.Size(75,23);
		this.ButtonStart.TabIndex = 1;
		this.ButtonStart.Text = "Start";
		this.ButtonStart.UseVisualStyleBackColor = true;
		this.ButtonStart.Click += new System.EventHandler(this.ButtonStart_Click);
		// 
		// NumberOfChances
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(284,111);
		this.Controls.Add(this.ButtonStart);
		this.Controls.Add(this.m_ButtonNumberOfChances);
		this.DoubleBuffered = true;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
		this.MaximizeBox = false;
		this.Name = "NumberOfChances";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Bool Pgia";
		this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NumberOfChances_FormClosing);
		this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NumberOfChances_FormClosed);
		this.Load += new System.EventHandler(this.NumberOfChances_Load);
		this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_ButtonNumberOfChances;
		private System.Windows.Forms.Button ButtonStart;
	}
}