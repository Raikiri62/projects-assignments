using System;
using FacebookWrapper.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace facebookApp
{
    public partial class MatchingForm : Form
    {
        public User UserLoggedIn { get; set; }

        public List<Person> m_Persons = new List<Person>();

        public MenMatch MenMatch = new MenMatch();

        public FemaleMatch FemaleMatch = new FemaleMatch();

        public MatchingForm(User m_LoggedInUser)
        {
            UserLoggedIn = m_LoggedInUser;
            InitializeComponent();
        }

        public void FillListBox(ListBox io_Listbox, List<Person> io_People)
        {
            io_Listbox.Items.Clear();

            foreach (Person person in io_People)
            {
                io_Listbox.Items.Add(person.Name);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string i_GenderChoice = "Unknown";
            string i_LocationChoice = "unknown";
            string i_AgeRangeChoice;
            int io_AgeRange = 120;
            List<Person> m_BestMatchList = new List<Person>();
            List<Person> m_SecondBestMatchList = new List<Person>();

            if (listBoxGender.SelectedItem != null) 
            {
                i_GenderChoice = listBoxGender.SelectedItem.ToString();
            }

            if (listBoxAgeRange.SelectedIndex != -1)
            {
                i_AgeRangeChoice = listBoxAgeRange.SelectedItem.ToString().Remove(2, 3);
                int.TryParse(i_AgeRangeChoice, out io_AgeRange);
            }

            if (textBoxLocationSearch.Text != null)
            {
                i_LocationChoice = textBoxLocationSearch.Text;
            }

            if(i_GenderChoice == "male")
            {
                MenMatch.FindMatch(UserLoggedIn, io_AgeRange, i_LocationChoice, m_Persons, m_BestMatchList, m_SecondBestMatchList);
            }
            else
            {
                FemaleMatch.FindMatch(UserLoggedIn, io_AgeRange, i_LocationChoice, m_Persons, m_BestMatchList, m_SecondBestMatchList);
            }

            FillListBox(listBoxBestMatch, m_BestMatchList);
            FillListBox(listBoxSecondBestMatch, m_SecondBestMatchList);
        }

        private void MatchingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}
