using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using C19_Ex02_BoolPgia;

namespace C19_Ex05_WindowsUI
{
	// A class that defines the user interface for the board of the bool pgia game.
	internal partial class Board : Form
	{
		// The constructor that must be invoked to create new instances of the class Board.
		public Board()
		{
			PinResult.StartingANewGame();
			InitializeComponent();
		}

		// This method is invoked whenever the Board instance loads.
		private void Board_Load(object sender, EventArgs e)
		{
			this.Icon = SystemIcons.Application;
			PinResult.PasswordButtons = new Button[] { m_PasswordButton1, m_PasswordButton2, m_PasswordButton3, m_PasswordButton4 };
			PinResult.PinsResults = new PinResult[PinResult.NumberOfChances];

			for (byte i = 0; i < PinResult.NumberOfChances; i++)
			{
				PinResult.PinsResults[i] = new PinResult();
				PinResult.PinsResults[i].Location = new Point(m_PasswordButton1.Left, m_PasswordButton1.Bottom + 20 + (i * PinResult.PinsResults[i].Height));
			}

			PinResult.PinsResults[0].Enabled = true;
			this.ClientSize = new Size(this.ClientSize.Width, m_PasswordButton1.Bottom + 20 + (PinResult.NumberOfChances * PinResult.PinsResults[0].Height));
			this.Top = (Screen.PrimaryScreen.Bounds.Height - this.Height) / 2;
			this.Controls.AddRange(PinResult.PinsResults);
		}

		// This method is invoked whenever the Board instance is closing.
		private void Board_FormClosing(object sender, FormClosingEventArgs e)
		{
			if (PinResult.GameIsNotOver)
			{
				switch (new BoardClosing().ShowDialog())
				{
					case DialogResult.Cancel:
						e.Cancel = true;
					break;
					case DialogResult.OK:
						e.Cancel = false;
					break;
					case DialogResult.Abort:
						MessageBox.Show(BoolPgia.k_StringGoodBye, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						Process.GetCurrentProcess().Kill();
					break;
					default:
						throw new UnreachableCodeReachedException();
				}
			}
			else
			{
				e.Cancel = false;
			}
		}
	}
}