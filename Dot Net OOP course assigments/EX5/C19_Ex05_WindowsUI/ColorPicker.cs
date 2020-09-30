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
    // $G$ CSS-016 (-3) Bad class name - The name of classes derived from Form should end with Form.
	// A class that defines a color picker dialog
	internal partial class ColorPicker : Form
	{
		// A field that stores the name of the picked color as an enum instead of string.
		private ColorPicker.eColor m_NameOfPickedColor;

		// A property that returns the name of the picked color as an enum instead of string.
		public ColorPicker.eColor NameOfPickedColor
		{
			get { return m_NameOfPickedColor; }
		}

		// A property that returns the intensities of the picked color.
		public Color ActualPickedColor
		{
			get
			{
				Color color;
				switch (m_NameOfPickedColor)
				{
					case ColorPicker.eColor.Aqua:
						color = Color.Aqua;
					break;
					case ColorPicker.eColor.Firebrick:
						color = Color.Firebrick;
					break;
					case ColorPicker.eColor.Lime:
						color = Color.Lime;
					break;
					case ColorPicker.eColor.MediumBlue:
						color = Color.MediumBlue;
					break;
					case ColorPicker.eColor.MediumOrchid:
						color = Color.MediumOrchid;
					break;
					case ColorPicker.eColor.Red:
						color = Color.Red;
					break;
					case ColorPicker.eColor.Snow:
						color = Color.Snow;
					break;
					case ColorPicker.eColor.Yellow:
						color = Color.Yellow;
					break;
					default:
						throw new UnreachableCodeReachedException();
				}

				return color;
			}
		}

		// A property that returns all the colored button of this color picker dialog as a one dimensional array.
		private Button[] Buttons
		{
			get { return new Button[] { m_AquaButton, m_FirebrickButton, m_LimeButton, m_MediumBlueButton, m_MediumOrchidButton, m_RedButton, m_SnowButton, m_YellowButton }; }
		}

		// A constructor to create a new instance of ColorPicker class.
		public ColorPicker()
		{
			InitializeComponent();
		}

		// This method is invoked whenever the medium orchid button is clicked,
		private void m_MediumOrchidButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.MediumOrchid;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the red button is clicked.
		private void m_RedButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Red;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the lime button is clicked.
		private void m_LimeButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Lime;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the aqua button is clicked.
		private void m_AquaButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Aqua;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the medium blue is clicked.
		private void m_MediumBlueButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.MediumBlue;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the yellow button is clicked.
		private void m_YellowButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Yellow;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the firebrick button is clicked.
		private void m_FirebrickButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Firebrick;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the snow button is clicked.
		private void m_SnowButton_Click(object sender, EventArgs e)
		{
			m_NameOfPickedColor = ColorPicker.eColor.Snow;
			DialogResult = DialogResult.OK;
		}

		// This method is invoked whenever the ColorPicker instance loads.
		private void ColorPicker_Load(object sender, EventArgs e)
		{
			this.Icon = SystemIcons.Application;
		}

		// This method shows the color picker dialog and the invoker can choose which colored buttons are disabled and thus unclickable in the shown dialog.
		private DialogResult ShowDialog(IEnumerable<ColorPicker.eColor> i_ButtonsToDisable, bool i_EnableAllButtons = true)
		{
			if (i_EnableAllButtons)
			{
				EnableAllButtons();
			}

			DisableButtons(i_ButtonsToDisable);

			return base.ShowDialog();
		}

		// Same as above, but the invoker does not have to give a handle to an object that say all the buttons to be disabled, but can conveniently in the code list all these buttons and implicitly create a new one dimensional array.
		private DialogResult ShowDialog(params ColorPicker.eColor[] i_ButtonsToDisable)
		{
			return ShowDialog(i_ButtonsToDisable as IEnumerable<ColorPicker.eColor>);
		}

		// Same as above, but null values can be given and only all of them are ignored.
		private DialogResult ShowDialog(IEnumerable<ColorPicker.eColor?> i_ButtonsToDisable, bool i_EnableAllButtons = true)
		{
			return ShowDialog(Enumerable<ColorPicker.eColor>.ToNotNullable(i_ButtonsToDisable));
		}

		// Same as above, but null values can be given and only all of them are ignored.
		internal DialogResult ShowDialog(params ColorPicker.eColor?[] i_ButtonsToDisable)
		{
			return ShowDialog(i_ButtonsToDisable as IEnumerable<ColorPicker.eColor?>);
		}

		// Another overload of ShowDialog method that shows the color picker dialog to the user but in this overload of the method the invoker lists true and false values that each say if the corresponding colored button should be disabled or not in the shown dialog.
		private DialogResult ShowDialog(params bool[] i_Enabled)
		{
			if (i_Enabled == null)
			{
				throw new ArgumentNullException("i_Enabled", "i_Enabled must not be null.");
			}

			if (i_Enabled.Length != Buttons.Length)
			{
				throw new ArgumentOutOfRangeException("i_Enabled.Length", i_Enabled.Length, string.Format("i_Enabled.Length must be equal to Buttons.Length ({0})", Buttons.Length));
			}

			for (long i = 0; i < i_Enabled.Length; i++)
			{
				Buttons[i].Enabled = i_Enabled[i];
			}

			return base.ShowDialog();
		}

		// Same as above, but only all the null values are ignored.
		private DialogResult ShowDialog(params bool?[] i_Enabled)
		{
			if (i_Enabled == null)
			{
				throw new ArgumentNullException("i_Enabled", "i_Enabled must not be null.");
			}

			if (i_Enabled.Length != Buttons.Length)
			{
				throw new ArgumentOutOfRangeException("i_Enabled.Length", i_Enabled.Length, string.Format("i_Enabled.Length must be equal to Buttons.Length ({0})", Buttons.Length));
			}

			for (long i = 0; i < i_Enabled.Length; i++)
			{
				if (i_Enabled[i].HasValue)
				{
					Buttons[i].Enabled = i_Enabled[i].Value;
				}
			}

			return base.ShowDialog();
		}

		// Give a name of a color as enum and get a handle to the colored button of the color picker dialog.
		private Button GetButton(ColorPicker.eColor i_eColor)
		{
			Button button;
			switch (i_eColor)
			{
				case ColorPicker.eColor.Aqua:
					button = m_AquaButton;
				break;
				case ColorPicker.eColor.Firebrick:
					button = m_FirebrickButton;
				break;
				case ColorPicker.eColor.Lime:
					button = m_LimeButton;
				break;
				case ColorPicker.eColor.MediumBlue:
					button = m_MediumBlueButton;
				break;
				case ColorPicker.eColor.MediumOrchid:
					button = m_MediumOrchidButton;
				break;
				case ColorPicker.eColor.Red:
					button = m_RedButton;
				break;
				case ColorPicker.eColor.Snow:
					button = m_SnowButton;
				break;
				case ColorPicker.eColor.Yellow:
					button = m_YellowButton;
				break;
				default:
					throw new UnreachableCodeReachedException();
			}

			return button;
		}

		// Enables a colored button and makes it clickable by the name of his color as enum.
		private void EnableButton(ColorPicker.eColor i_eColor)
		{
			GetButton(i_eColor).Enabled = true;
		}

		// Disables a colored button and makes it unclickable by the name of his color as enum.
		private void DisableButton(ColorPicker.eColor i_eColor)
		{
			GetButton(i_eColor).Enabled = false;
		}

		// Enable some colored buttons and make them clickable by the names of their color as enums.
		private void EnableButtons(IEnumerable<ColorPicker.eColor> i_ButtonsToEnable)
		{
			foreach (ColorPicker.eColor currentButtonToEnable in i_ButtonsToEnable)
			{
				EnableButton(currentButtonToEnable);
			}
		}

		// Same as above, but a handle to the names of the colors is not needed, but the invoker can list these names in the code and implicitly create a new one dimensional array.
		private void EnableButtons(params ColorPicker.eColor[] i_ButtonsToEnable)
		{
			EnableButtons(i_ButtonsToEnable as IEnumerable<ColorPicker.eColor>);
		}

		// Same as above, but null values can be given and only all of them are ignored.
		private void EnableButtons(IEnumerable<ColorPicker.eColor?> i_ButtonsToEnable)
		{
			EnableButtons(Enumerable<ColorPicker.eColor>.ToNotNullable(i_ButtonsToEnable));
		}

		// Same as above, but null values can be given and only all of them are ignored.
		private void EnableButtons(params ColorPicker.eColor?[] i_ButtonsToEnable)
		{
			EnableButtons(i_ButtonsToEnable as IEnumerable<ColorPicker.eColor?>);
		}

		// Disable some colored buttons and make them unclickable by the names of their color as enums.
		private void DisableButtons(IEnumerable<ColorPicker.eColor> i_ButtonsToDisable)
		{
			foreach (ColorPicker.eColor currentButtonToDisable in i_ButtonsToDisable)
			{
				DisableButton(currentButtonToDisable);
			}
		}

		// Same as above, but a handle to the names of the colors is not needed, but the invoker can list these names in the code and implicitly create a new one dimensional array.
		private void DisableButtons(params ColorPicker.eColor[] i_ButtonsToDisable)
		{
			DisableButtons(i_ButtonsToDisable as IEnumerable<ColorPicker.eColor>);
		}

		// Same as above, but null values can be given and only all of them are ignored.
		private void DisableButtons(IEnumerable<ColorPicker.eColor?> i_ButtonsToDisable)
		{
			DisableButtons(Enumerable<ColorPicker.eColor>.ToNotNullable(i_ButtonsToDisable));
		}

		// Same as above, but null values can be given and only all of them are ignored.
		private void DisableButtons(params ColorPicker.eColor?[] i_ButtonsToDisable)
		{
			DisableButtons(i_ButtonsToDisable as IEnumerable<ColorPicker.eColor?>);
		}

		// Enables all the colored buttons and make them clickable.
		private void EnableAllButtons()
		{
			foreach (Button currentButton in Buttons)
			{
				currentButton.Enabled = true;
			}
		}

		// Disables all the colored buttons and make them unclickable.
		private void DisableAllButtons()
		{
			foreach (Button currentButton in Buttons)
			{
				currentButton.Enabled = false;
			}
		}
	}
}