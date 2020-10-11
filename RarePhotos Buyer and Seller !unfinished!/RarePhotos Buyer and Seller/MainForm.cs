using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RarePhotos_Buyer_and_Seller
{
    public partial class MainForm : Form
    {
        public List<TomTom> m_TamTams { get; set;}
        public User LoggedInUser { get; set; }
        public List<User> Users { get; set; }
        public CloudinaryProxy CloudinaryProxy { get; set; }
        public DataBaseProxy DataBaseProxy { get; set; }
        public List<TomTom> getTomToms()
        {
            var list = new List<TomTom>();
            list.Add(new TomTom() { ID = "1", Name = "Hamona Liza", Description = "the most rare in the world", Price = 100000, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "2", Name = "paint 2", Description = "very good", Price = 5000, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });
            list.Add(new TomTom() { ID = "3", Name = "paint 3", Description = "not bad", Price = 30, Date = DateTime.Now.ToString() });

            return list;

        }
        public LoginForm m_LoginForm;
        public MainForm()
        {
            InitializeComponent();
            InitProxies();
            fetchUsers();
            InitLoginToTheApp();
            //LoggedInUser.InitPhotosCollection(CloudinaryProxy, DataBaseProxy);
            //m_TamTams = getTomToms();
        }



        private void MainForm_Load(object sender, EventArgs e)
        {
            populateLabels();
            //demo:
            //dataGridViewMarket.DataSource = m_TamTams;
            //dataGridViewMarket.Columns["ID"].Visible = false;
            InitFileDialogSettings();
        }

        private void populateLabels()
        {
            this.labelUserName.Text = LoggedInUser.Name + ", " + LoggedInUser.UserName;
            PopulateMoneyToLabel(LoggedInUser.BankAccount.money);
        }
        private void PopulateMoneyToLabel(int i_amount)
        {
            labelMoney.Text = i_amount + " $";
        }
        public void onClick()
        {
            try
            {
                var selectedRow = dataGridViewMarket.SelectedRows[0].DataBoundItem as TomTom;
                PhotoProfileForm photoProfileForm = new PhotoProfileForm();
                photoProfileForm.FilePath = @"C:/city.jpg";
                photoProfileForm.Show();
                // do something..
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void dataGridViewMarket_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            onClick();
        }
        private void buttonShowCollection_Click(object sender, EventArgs e)
        {
            var form = new PhotosCollectionForm(LoggedInUser);
            form.Show();
        }
        private void buttonUploadPhoto_Click(object sender, EventArgs e)
        {
            UploadPhoto();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

