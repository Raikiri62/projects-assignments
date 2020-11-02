using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class User
    {
        public int ID { get; private set; }
        public string UserName { get; private set; }
        public string Name { get; private set; }
        public string Password { get; set; }
        public Bank BankAccount { get; private set; }
        public PhotosCollection PhotosCollection { get; private set; }
        public User(int i_ID, string i_UserName, string i_Name, string i_Password,Bank i_BankAccount)
        {
            ID = i_ID;
            UserName = i_UserName;
            Name = i_Name;
            Password = i_Password;
            BankAccount = i_BankAccount;
        }
        public void InitPhotosCollection(DataBaseProxy i_DataBaseProxy)
        {
            PhotosCollection = new PhotosCollection();
            PhotosCollection.InitializeCollection(this, i_DataBaseProxy);
        }
        public void updateBank(int i_Money, DataBaseProxy i_DataBaseProxy)
        {
            BankAccount.money = i_Money;
            i_DataBaseProxy.updateBank(BankAccount);
        }
    }
}
