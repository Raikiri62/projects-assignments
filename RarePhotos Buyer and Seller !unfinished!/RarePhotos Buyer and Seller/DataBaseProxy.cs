using CloudinaryDotNet.Actions;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RarePhotos_Buyer_and_Seller
{
    public class DataBaseProxy
    {
        private string ConnectionString;
        private MySqlConnection m_MySqlConnection;
        public DataBaseProxy()
        {
        }
        private void Connect()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DabaCNN"].ConnectionString;
            m_MySqlConnection = new MySqlConnection(ConnectionString);
            m_MySqlConnection.Open();
        }
        private void CloseConnection()
        {
            if(m_MySqlConnection != null)
            {
                m_MySqlConnection.Close();
            }
        }
        public void InsertUsers(List<User> i_Users)
        {
            Connect();
            List<SQL_User> SqlUsers = SQL_User.GetSqlObjects(i_Users);
            m_MySqlConnection.Execute("call insertUsers (@id, @username,@name,@password)", SqlUsers);
            CloseConnection();
        }
        public void InsertUsers(List<SQL_User> i_Users)
        {
            Connect();
            m_MySqlConnection.Execute("call insertUsers (@id, @username,@name,@password)", i_Users);
            CloseConnection();
        }
        public List<User> GetAllUsers()
        {
            Connect();
            var Users = new List<User>();
            var SQL_users = (List<SQL_User>)m_MySqlConnection.Query<SQL_User>("select * from users;");
            CloseConnection();
            
            foreach (SQL_User Sql_User in SQL_users)
            {
                Users.Add(new User(Sql_User.id, Sql_User.username, Sql_User.name, Sql_User.password, GetBankOfUser(Sql_User.id)));
            }
            return Users;
        }
        public Bank GetBankOfUser(int i_ID)
        {
            Connect();
            var banks = (List<Bank>)m_MySqlConnection.Query<Bank>($"select * from bank where userId = '{ i_ID}';");
            if (banks == null)
            {
                return new Bank() {userId = i_ID,money = 0 };
            }
            CloseConnection();
            return banks[0];
        }
        public void InsertBank(SQL_User i_SQL_User, int InitialMoney)
        {
            Connect();
            m_MySqlConnection.Execute($"insert into bank values('{i_SQL_User.id}','{InitialMoney}');");
            CloseConnection();
        }
        public User CreateNewUser(SQL_User i_SQL_User)
        {
            //inserting to the users table:
            var list = new List<SQL_User>();
            list.Add(i_SQL_User);
            InsertUsers(list);
            //inserting to bank table:
            int InitialMoney = 40000;
            InsertBank(i_SQL_User,InitialMoney);
            Bank bank = new Bank();
            bank.userId = i_SQL_User.id;
            bank.money = InitialMoney;
            return new User(i_SQL_User.id, i_SQL_User.username, i_SQL_User.name, i_SQL_User.password,bank);
        }
        public int InsertNewPhoto(string i_PhotoTag, string i_URL) // returnig photo ID
        {
            Random rnd = new Random();
            int PhotoID = rnd.Next(1, 1000000);
            Connect();
            m_MySqlConnection.Execute($"insert into photos values('{PhotoID}','{i_PhotoTag}','{i_URL }');");
            CloseConnection();
            return PhotoID;
        }
        public void InsertPhotoToCollection(int i_UserID,int i_PhotoID)
        {
            Connect();
            m_MySqlConnection.Execute($"insert into collection values('{i_UserID}','{i_PhotoID}');");
            CloseConnection();
        }
    }

    public class SQL_User
    {
        public int id { get; set; }
        public string username { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public static List<SQL_User> GetSqlObjects(List<User> i_Users)
        {
            List<SQL_User> SqlUsers = new List<SQL_User>();
            foreach(User usr in i_Users)
            {
                SqlUsers.Add(new SQL_User() { id = usr.ID, name = usr.Name, username = usr.UserName, password = usr.Password });
            }
            return SqlUsers;
        }
    }
}
