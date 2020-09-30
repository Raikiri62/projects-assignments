using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using C19_Ex02_BoolPgia;

namespace C19_Ex05_WindowsUI
{
	// A class that defines a window that let's the player to choose how many chances he or she wants to have in the Bool Pgia game.
	internal partial class NumberOfChances : Form
	{
		// A constructor to create a new instance of NumberOfChances class.
		public NumberOfChances()
		{
			InitializeComponent();
		}

		// This method is invoked whenever the player clicks the "Number of chances: N" button where N is an integer between 4 to 10 (including both 4 and 10)
		private void ButtonNumberOfChances_Click(object sender, EventArgs e)
		{
			PinResult.NumberOfChances = (byte)(BoolPgia.k_MinimumNumberOfChances + ((PinResult.NumberOfChances - BoolPgia.k_MinimumNumberOfChances + 1) % (BoolPgia.k_MaximumNumberOfChances - 4 + 1)));
			m_ButtonNumberOfChances.Text = "Number of chances: " + PinResult.NumberOfChances;
		}

		// This method is invoked whenever the player clicks the "Start" button.
		private void ButtonStart_Click(object sender, EventArgs e)
		{
			BoolPgia.GenerateRandomPassword();
			this.Hide();
			PinResult.NumberOfGuesses = 0;
			new Board().ShowDialog();
			this.Show();
		}

		// This method is invoked whenever any instance of NumberOfChances class loads.
		private void NumberOfChances_Load(object sender, EventArgs e)
		{
			this.Icon = SystemIcons.Application;
		}

		// This method is invoked whenever any instance of NumberOfChances class is closing.
		private void NumberOfChances_FormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = MessageBox.Show("Are you sure?", "Closing", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No;
		}

		// This method is invoked whenever any instance of NumberOfChances class has been closed.
		private void NumberOfChances_FormClosed(object sender, FormClosedEventArgs e)
		{
			MessageBox.Show(BoolPgia.k_StringGoodBye, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            Application.Exit();
		}
	}
}
