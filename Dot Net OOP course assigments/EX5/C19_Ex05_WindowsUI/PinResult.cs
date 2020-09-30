using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using C19_Ex02_BoolPgia;

namespace C19_Ex05_WindowsUI
{
	// This is a user control class that the windows applications version of the Bool Pgia game uses to lets the player to make a guess and see the result of his or her guess.
	internal partial class PinResult : UserControl
	{
		// Every instance of this user control class uses the ColorPicker dialog class to let the player to choose a character as a color.
		private static readonly ColorPicker sr_ColorPicker = new ColorPicker();

		// A handle to a one dimensional array of this user control class. This field is initially null.
		// This one dimensional array is needed to enable the next instance of this user control class and make it interactive when the player is done with the current instance of this user control class and the current instance of this user control class becomes disabled and not interactive.
		private static PinResult[] s_PinsResults = null;

		// This static field remembers how many guesses the player guessed.
		private static byte s_NumberOfGuesses = 0;

		// This static field remembers how many chances the player chose before starting playing the Bool Pgia game.
		private static byte s_NumberOfChances = BoolPgia.k_MinimumNumberOfChances;

		// This static field should refer to all the black buttons of the Board instance that in the end of the game these buttons show the random password that the computer generated.
		private static Button[] s_PasswordButtons = null;

		// This static field says if the current Bool Pgia game is not over. This field is logically initially true.
		// This static field is used to not show to the player the BoardClosing dialog when the current Bool Pgia game is over and the current Board instance is closing.
		private static bool s_GameIsNotOver = true;

		// A static property that simply returns s_PinsResults.
		internal static PinResult[] PinsResults
		{
			get { return s_PinsResults; }
			set { s_PinsResults = value; }
		}

		// A static property that simply returns s_NumberOfGuesses.
		internal static byte NumberOfGuesses
		{
			get { return s_NumberOfGuesses; }
			set { s_NumberOfGuesses = value; }
		}

		// A static property that simply returns s_NumberOfChances.
		internal static byte NumberOfChances
		{
			get { return s_NumberOfChances; }
			set { s_NumberOfChances = value; }
		}

		// A property that returns all the handles of the Pin buttons of this user control class instance as a handle to a new one dimensional array.
		private Button[] pinButtons
		{
			get { return new Button[] { m_ButtonPin1, m_ButtonPin2, m_ButtonPin3, m_ButtonPin4 }; }
		}

		// A property that returns all the handles of the Result buttons of this user control class instance as a handle to a new one dimensional array.
		private Button[] resultButtons
		{
			get { return new Button[] { m_ButtonResultTopLeft, m_ButtonResultTopRight, m_ButtonResultBottomLeft, m_ButtonResultBottomRight }; }
		}

		// A property that returns the Parent of this user control class instance as Board.
		private Board Board
		{
			get { return Parent as Board; }
		}

		// A property that returns the Parent of this user control class instance as Form.
		private Form Form
		{
			get { return Parent as Form; }
		}

		// A static property that simply returns s_PasswordButtons.
		internal static Button[] PasswordButtons
		{
			private get { return s_PasswordButtons; }
			set { s_PasswordButtons = value; }
		}

		// A static property that simply returns s_GameIsNotOver.
		public static bool GameIsNotOver
		{
			get { return s_GameIsNotOver; }
		}

		// A static method that is invoked whenever a new game of Bool Pgia is starting. Logically sets s_GameIsNotOver to true.
		public static void StartingANewGame()
		{
			s_GameIsNotOver = true;
		}

		// This method is invoked when current game of Bool Pgia is over.
		private void gameOver()
		{
			s_GameIsNotOver = false;
			switch (MessageBox.Show(BoolPgia.k_StringYesNoQuestionAboutStartingANewGame, "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
			{
				case DialogResult.Yes:
					Board.Close();
				break;
				case DialogResult.No:
					MessageBox.Show(BoolPgia.k_StringGoodBye, "Exclamation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					Process.GetCurrentProcess().Kill();
				break;
				default:
					throw new UnreachableCodeReachedException();
			}
		}
		
		// A readonly field that remembers the names of all the colors that the player chose with the ColorPicker dialog.
		// Initially all values are null, because the player did not choose any color yet.
		private readonly ColorPicker.eColor?[] r_eColors = new ColorPicker.eColor?[BoolPgia.k_LengthOfPassword];

		// A constructor to create a new instance of this user control class.
		public PinResult()
		{
			InitializeComponent();
		}

		// A method to convert a name of color as enum (picked from ColorPicker dialog) to a name of character as another enum that the BoolPgia DLL uses.
		private BoolPgia.eCharacter toeCharacter(ColorPicker.eColor i_Color)
		{
			BoolPgia.eCharacter output;
			switch (i_Color)
			{
				case ColorPicker.eColor.Aqua:
					output = BoolPgia.eCharacter.A;
				break;
				case ColorPicker.eColor.Firebrick:
					output = BoolPgia.eCharacter.B;
				break;
				case ColorPicker.eColor.Lime:
					output = BoolPgia.eCharacter.C;
				break;
				case ColorPicker.eColor.MediumBlue:
					output = BoolPgia.eCharacter.D;
				break;
				case ColorPicker.eColor.MediumOrchid:
					output = BoolPgia.eCharacter.E;
				break;
				case ColorPicker.eColor.Red:
					output = BoolPgia.eCharacter.F;
				break;
				case ColorPicker.eColor.Snow:
					output = BoolPgia.eCharacter.G;
				break;
				case ColorPicker.eColor.Yellow:
					output = BoolPgia.eCharacter.H;
				break;
				default:
					throw new UnreachableCodeReachedException();
			}

			return output;
		}

		// A method to convert a name of character as enum that the BoolPgia DLL uses to 32 bit true color as four byte intensities RGBA.
		private Color toColor(BoolPgia.eCharacter i_eCharacter)
		{
			Color color;
			switch (i_eCharacter)
			{
				case BoolPgia.eCharacter.A:
					color = Color.Aqua;
				break;
				case BoolPgia.eCharacter.B:
					color = Color.Firebrick;
				break;
				case BoolPgia.eCharacter.C:
					color = Color.Lime;
				break;
				case BoolPgia.eCharacter.D:
					color = Color.MediumBlue;
				break;
				case BoolPgia.eCharacter.E:
					color = Color.MediumOrchid;
				break;
				case BoolPgia.eCharacter.F:
					color = Color.Red;
				break;
				case BoolPgia.eCharacter.G:
					color = Color.Snow;
				break;
				case BoolPgia.eCharacter.H:
					color = Color.Yellow;
				break;
				default:
					throw new UnreachableCodeReachedException();
			}

			return color;
		}

		// A method that turns all the black buttons of the Board instance to the random password that the computer generated.
		private void showPassword()
		{
			for (long i = 0; i < PasswordButtons.Length; i++)
			{
				PasswordButtons[i].BackColor = toColor(BoolPgia.Password[i]);
			}
		}

		// This method is invoked whenever the player clicks the left most pin button of this user control class instance.
		private void m_ButtonPin1_Click(object sender, EventArgs e)
		{
			if (sr_ColorPicker.ShowDialog(/*r_eColors*/) == DialogResult.OK)
			{
				int index = Array.IndexOf(r_eColors, sr_ColorPicker.NameOfPickedColor);
				if (index == -1)
				{
					m_ButtonPin1.BackColor = sr_ColorPicker.ActualPickedColor;
				}
				else
				{
					Algorithm<ColorPicker.eColor>.Swap(ref r_eColors[0], ref r_eColors[index]);
					Color temporary = pinButtons[0].BackColor;
					pinButtons[0].BackColor = pinButtons[index].BackColor;
					pinButtons[index].BackColor = temporary;
				}

				r_eColors[0] = sr_ColorPicker.NameOfPickedColor;
				m_ButtonArrow.Enabled = Enumerable<ColorPicker.eColor>.AllHasValue(r_eColors);
			}
		}

		// This method is invoked whenever the player clicks the middle left pin button of this user control class instance.
		private void m_ButtonPin2_Click(object sender, EventArgs e)
		{
			if (sr_ColorPicker.ShowDialog(/*r_eColors*/) == DialogResult.OK)
			{
				int index = Array.IndexOf(r_eColors, sr_ColorPicker.NameOfPickedColor);
				if (index == -1)
				{
					m_ButtonPin2.BackColor = sr_ColorPicker.ActualPickedColor;
				}
				else
				{
					Algorithm<ColorPicker.eColor>.Swap(ref r_eColors[1], ref r_eColors[index]);
					Color temporary = pinButtons[1].BackColor;
					pinButtons[1].BackColor = pinButtons[index].BackColor;
					pinButtons[index].BackColor = temporary;
				}

				r_eColors[1] = sr_ColorPicker.NameOfPickedColor;
				m_ButtonArrow.Enabled = Enumerable<ColorPicker.eColor>.AllHasValue(r_eColors);
			}
		}

		// This method is invoked whenever the player clicks the middle right pin button of this user control class instance.
		private void m_ButtonPin3_Click(object sender, EventArgs e)
		{
			if (sr_ColorPicker.ShowDialog(/*r_eColors*/) == DialogResult.OK)
			{
				int index = Array.IndexOf(r_eColors, sr_ColorPicker.NameOfPickedColor);
				if (index == -1)
				{
					m_ButtonPin3.BackColor = sr_ColorPicker.ActualPickedColor;
				}
				else
				{
					Algorithm<ColorPicker.eColor>.Swap(ref r_eColors[2], ref r_eColors[index]);
					Color temporary = pinButtons[2].BackColor;
					pinButtons[2].BackColor = pinButtons[index].BackColor;
					pinButtons[index].BackColor = temporary;
				}

				r_eColors[2] = sr_ColorPicker.NameOfPickedColor;
				m_ButtonArrow.Enabled = Enumerable<ColorPicker.eColor>.AllHasValue(r_eColors);
			}
		}

		// This method is invoked whenever the player clicks the right most button of this user control class instance.
		private void m_ButtonPin4_Click(object sender, EventArgs e)
		{
			if (sr_ColorPicker.ShowDialog(/*r_eColors*/) == DialogResult.OK)
			{
				int index = Array.IndexOf(r_eColors, sr_ColorPicker.NameOfPickedColor);
				if (index == -1)
				{
					m_ButtonPin4.BackColor = sr_ColorPicker.ActualPickedColor;
				}
				else
				{
					Algorithm<ColorPicker.eColor>.Swap(ref r_eColors[3], ref r_eColors[index]);
					Color temporary = pinButtons[3].BackColor;
					pinButtons[3].BackColor = pinButtons[index].BackColor;
					pinButtons[index].BackColor = temporary;
				}

				r_eColors[3] = sr_ColorPicker.NameOfPickedColor;
				m_ButtonArrow.Enabled = Enumerable<ColorPicker.eColor>.AllHasValue(r_eColors);
			}
		}

		// This method is invoked whenever the player clicks the arrow button of this user control class instance.
		private void m_ButtonArrow_Click(object sender, EventArgs e)
		{
			if (Enumerable<BoolPgia.eCharacter>.HasRepetitions(guess))
			{
				MessageBox.Show(BoolPgia.k_StringNoRepetitionsAllowed, "What's wrong with you?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else if (BoolPgia.AlreadyTried(guess))
			{
				MessageBox.Show(BoolPgia.k_StringThisGuessHasAlreadyBeenTried, "What's wrong with you?", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
			}
			else
			{
				this.Enabled = false;
				s_NumberOfGuesses++;
				if (s_NumberOfGuesses < s_PinsResults.Length)
				{
					s_PinsResults[s_NumberOfGuesses].Enabled = true;
				}

				byte numberOfBoolim, numberOfPgiot;
				BoolPgia.CalculateResult(guess, out numberOfBoolim, out numberOfPgiot);

				long indexOfResultButton = 0;
				for (byte i = 0; i < numberOfBoolim; i++)
				{
					resultButtons[indexOfResultButton].BackColor = Color.Black;
					indexOfResultButton++;
				}

				for (byte i = 0; i < numberOfPgiot; i++)
				{
					resultButtons[indexOfResultButton].BackColor = Color.Yellow;
					indexOfResultButton++;
				}

				if (numberOfBoolim == BoolPgia.k_LengthOfPassword)
				{
					showPassword();
					MessageBox.Show(BoolPgia.GetStringPlayerSuccessfullyGuessedPassword(s_NumberOfGuesses), "Congratulations!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					gameOver();
				}
				else if (s_NumberOfGuesses == s_NumberOfChances)
				{
					showPassword();
					MessageBox.Show(BoolPgia.k_StringLoss, "Loser!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					gameOver();
				}
			}
		}

		// A property that returns a handle to a new one dimensional array of the guess that the player made as names of characters of BoolPgia DLL.
		private BoolPgia.eCharacter[] guess
		{
			get
			{
				BoolPgia.eCharacter[] output = new BoolPgia.eCharacter[r_eColors.Length];
				for (long i = 0; i < output.Length; i++)
				{
					output[i] = toeCharacter(r_eColors[i].Value);
				}

				return output;
			}
		}
	}
}