namespace C19_Ex05_WindowsUI
{
	internal partial class PinResult
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.m_ButtonPin1 = new System.Windows.Forms.Button();
			this.m_ButtonPin2 = new System.Windows.Forms.Button();
			this.m_ButtonPin3 = new System.Windows.Forms.Button();
			this.m_ButtonPin4 = new System.Windows.Forms.Button();
			this.m_ButtonArrow = new System.Windows.Forms.Button();
			this.m_ButtonResultTopLeft = new System.Windows.Forms.Button();
			this.m_ButtonResultBottomLeft = new System.Windows.Forms.Button();
			this.m_ButtonResultBottomRight = new System.Windows.Forms.Button();
			this.m_ButtonResultTopRight = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// m_ButtonPin1
			// 
			this.m_ButtonPin1.Location = new System.Drawing.Point(0,0);
			this.m_ButtonPin1.Name = "m_ButtonPin1";
			this.m_ButtonPin1.Size = new System.Drawing.Size(50,50);
			this.m_ButtonPin1.TabIndex = 0;
			this.m_ButtonPin1.UseVisualStyleBackColor = true;
			this.m_ButtonPin1.Click += new System.EventHandler(this.m_ButtonPin1_Click);
			// 
			// m_ButtonPin2
			// 
			this.m_ButtonPin2.Location = new System.Drawing.Point(56,0);
			this.m_ButtonPin2.Name = "m_ButtonPin2";
			this.m_ButtonPin2.Size = new System.Drawing.Size(50,50);
			this.m_ButtonPin2.TabIndex = 1;
			this.m_ButtonPin2.UseVisualStyleBackColor = true;
			this.m_ButtonPin2.Click += new System.EventHandler(this.m_ButtonPin2_Click);
			// 
			// m_ButtonPin3
			// 
			this.m_ButtonPin3.Location = new System.Drawing.Point(112,0);
			this.m_ButtonPin3.Name = "m_ButtonPin3";
			this.m_ButtonPin3.Size = new System.Drawing.Size(50,50);
			this.m_ButtonPin3.TabIndex = 2;
			this.m_ButtonPin3.UseVisualStyleBackColor = true;
			this.m_ButtonPin3.Click += new System.EventHandler(this.m_ButtonPin3_Click);
			// 
			// m_ButtonPin4
			// 
			this.m_ButtonPin4.Location = new System.Drawing.Point(168,0);
			this.m_ButtonPin4.Name = "m_ButtonPin4";
			this.m_ButtonPin4.Size = new System.Drawing.Size(50,50);
			this.m_ButtonPin4.TabIndex = 3;
			this.m_ButtonPin4.UseVisualStyleBackColor = true;
			this.m_ButtonPin4.Click += new System.EventHandler(this.m_ButtonPin4_Click);
			// 
			// m_ButtonArrow
			// 
			this.m_ButtonArrow.Enabled = false;
			this.m_ButtonArrow.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_ButtonArrow.Location = new System.Drawing.Point(220,16);
			this.m_ButtonArrow.Name = "m_ButtonArrow";
			this.m_ButtonArrow.Size = new System.Drawing.Size(30,20);
			this.m_ButtonArrow.TabIndex = 4;
			this.m_ButtonArrow.Text = "-->>";
			this.m_ButtonArrow.UseVisualStyleBackColor = true;
			this.m_ButtonArrow.Click += new System.EventHandler(this.m_ButtonArrow_Click);
			// 
			// m_ButtonResultTopLeft
			// 
			this.m_ButtonResultTopLeft.Enabled = false;
			this.m_ButtonResultTopLeft.Location = new System.Drawing.Point(257,8);
			this.m_ButtonResultTopLeft.Name = "m_ButtonResultTopLeft";
			this.m_ButtonResultTopLeft.Size = new System.Drawing.Size(15,15);
			this.m_ButtonResultTopLeft.TabIndex = 5;
			this.m_ButtonResultTopLeft.UseVisualStyleBackColor = true;
			// 
			// m_ButtonResultBottomLeft
			// 
			this.m_ButtonResultBottomLeft.Enabled = false;
			this.m_ButtonResultBottomLeft.Location = new System.Drawing.Point(257,29);
			this.m_ButtonResultBottomLeft.Name = "m_ButtonResultBottomLeft";
			this.m_ButtonResultBottomLeft.Size = new System.Drawing.Size(15,15);
			this.m_ButtonResultBottomLeft.TabIndex = 6;
			this.m_ButtonResultBottomLeft.UseVisualStyleBackColor = true;
			// 
			// m_ButtonResultBottomRight
			// 
			this.m_ButtonResultBottomRight.Enabled = false;
			this.m_ButtonResultBottomRight.Location = new System.Drawing.Point(278,29);
			this.m_ButtonResultBottomRight.Name = "m_ButtonResultBottomRight";
			this.m_ButtonResultBottomRight.Size = new System.Drawing.Size(15,15);
			this.m_ButtonResultBottomRight.TabIndex = 8;
			this.m_ButtonResultBottomRight.UseVisualStyleBackColor = true;
			// 
			// m_ButtonResultTopRight
			// 
			this.m_ButtonResultTopRight.Enabled = false;
			this.m_ButtonResultTopRight.Location = new System.Drawing.Point(278,8);
			this.m_ButtonResultTopRight.Name = "m_ButtonResultTopRight";
			this.m_ButtonResultTopRight.Size = new System.Drawing.Size(15,15);
			this.m_ButtonResultTopRight.TabIndex = 7;
			this.m_ButtonResultTopRight.UseVisualStyleBackColor = true;
			// 
			// PinResult
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F,13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.m_ButtonResultBottomRight);
			this.Controls.Add(this.m_ButtonResultTopRight);
			this.Controls.Add(this.m_ButtonResultBottomLeft);
			this.Controls.Add(this.m_ButtonResultTopLeft);
			this.Controls.Add(this.m_ButtonArrow);
			this.Controls.Add(this.m_ButtonPin4);
			this.Controls.Add(this.m_ButtonPin3);
			this.Controls.Add(this.m_ButtonPin2);
			this.Controls.Add(this.m_ButtonPin1);
			this.Enabled = false;
			this.Name = "PinResult";
			this.Size = new System.Drawing.Size(293,60);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button m_ButtonPin1;
		private System.Windows.Forms.Button m_ButtonPin2;
		private System.Windows.Forms.Button m_ButtonPin3;
		private System.Windows.Forms.Button m_ButtonPin4;
		private System.Windows.Forms.Button m_ButtonArrow;
		private System.Windows.Forms.Button m_ButtonResultTopLeft;
		private System.Windows.Forms.Button m_ButtonResultBottomLeft;
		private System.Windows.Forms.Button m_ButtonResultBottomRight;
		private System.Windows.Forms.Button m_ButtonResultTopRight;
	}
}