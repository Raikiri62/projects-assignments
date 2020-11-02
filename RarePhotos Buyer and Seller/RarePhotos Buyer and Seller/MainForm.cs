using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace RarePhotos_Buyer_and_Seller
{
    public partial class MainForm : Form
    {
        public Market Market { get; set; }
        public User LoggedInUser { get; set; }
        public List<User> Users { get; set; }
        public PhotosCollectionForm CollectionForm { get; set; }
        public PhotoProfileForm PhotoProfileForm { get; set; }
        public CloudinaryProxy CloudinaryProxy { get; set; }
        public DataBaseProxy DataBaseProxy { get; set; }
        public Updater Updater;

        public LoginForm m_LoginForm;
        public MainForm()
        {
            InitializeComponent();
            InitProxies();
            fetchUsers();
            InitLoginToTheApp();
            InitCollectionForm();
            Market = new Market(DataBaseProxy);
            PhotoProfileForm = new PhotoProfileForm(DataBaseProxy);
        }
        private void InitCollectionForm()
        {
            CollectionForm = new PhotosCollectionForm(LoggedInUser, DataBaseProxy);
        }
        public void updateCollectionForm()
        {
            InitCollectionForm();
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            populateLabels();
            InitFileDialogSettings();
            Updater = new Updater(this);
        }
        private void MainForm_Shown(object sender, EventArgs e)
        {
            InitMarketOnMainForm();
        }
        public void updateMarket()
        {
            Market = new Market(DataBaseProxy);
            //dataGridViewMarket.Update();
            //dataGridViewMarket.Refresh();
            InitMarketOnMainForm();
        }
        private void InitMarketOnMainForm()
        {
            if (Market != null && Market.MarketPhotos != null)
            {
                dataGridViewMarket.DataSource = Market.MarketPhotos;
                dataGridViewMarket.Columns["userId"].Visible = false;
                dataGridViewMarket.Columns["photoId"].Visible = false;
                dataGridViewMarket.Columns["description"].DisplayIndex = 0;
                dataGridViewMarket.Columns["price"].HeaderText = "Price in $";
            }
        }

        public void populateLabels()
        {
            this.labelUserName.Text = LoggedInUser.Name + ", " + LoggedInUser.UserName;
            PopulateMoneyToLabel(LoggedInUser.BankAccount.money);
        }
        private void PopulateMoneyToLabel(int i_amount)
        {
            labelMoney.Text = i_amount + " $";
        }
       
        private void dataGridViewMarket_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            onClick();
        }
        public void onClick()
        {
            var selectedRow = dataGridViewMarket.SelectedRows[0].DataBoundItem as MarketPhoto;
            //PhotoProfileForm photoProfileForm = new PhotoProfileForm();
            if(selectedRow != null)
            {
                PhotoProfileForm.InitForm(selectedRow,Users,LoggedInUser);
                PhotoProfileForm.Show();
            }

        }
        private void buttonShowCollection_Click(object sender, EventArgs e)
        {
            //CollectionForm.InitPhotosCollection();
            CollectionForm.Show();
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

