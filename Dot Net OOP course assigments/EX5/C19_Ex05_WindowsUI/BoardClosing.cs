using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace C19_Ex05_WindowsUI
{
	// This defines the dialog that is shown to the player when he or she is about to close the Board window.
	internal partial class BoardClosing : Form
	{
		// The constructor that must be invoked to create new instances of the class BoardClosing.
		public BoardClosing()
		{
			InitializeComponent();
		}

		// This method is invoked whenever the BoardClosing instance loads.
		private void BoardClosing_Load(object sender, EventArgs e)
		{
			this.Icon = SystemIcons.Application;
		}

		// This method is invoked whenever the player clicks the "Return to the current game" button.
		private void m_ButtonReturnToTheCurrentGame_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
		}

		// This method is invoked whenever the player clicks the "Start a new game" button.
		private void m_ButtonStartANewGame_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the player clicks the "Exit Game" button.
		private void m_ButtonExitApplication_Click(object sender, EventArgs e)
		{
			DialogResult = DialogResult.Abort;
		}
	}
}