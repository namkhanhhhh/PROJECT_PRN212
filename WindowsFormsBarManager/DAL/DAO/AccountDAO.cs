using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set => instance = value;
        }

        private AccountDAO() { }

        public bool isLogin(string userName, string password)
        {
/*            byte[] data = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] hashData=new MD5CryptoServiceProvider().ComputeHash(data);
            string hashPass = "";
            foreach(byte item in hashData)
            {
                hashPass+= item;
            }*/
            string query = "  select * from Accounts where userName='"+userName+"' and password='"+password+"'";
            DataTable result=DbContext.Instance.ExcuteQuery(query);
            return result.Rows.Count>0;
        }

        public Account getAccountByUN(string user)
        {
            DataTable data = DbContext.Instance.ExcuteQuery("select * from accounts where userName =  '" + user+"'");
            foreach (DataRow row in data.Rows)
            {
                return new Account(row);
            }
            return null;
        }

        public DataTable getAllAccount()
        {
            return DbContext.Instance.ExcuteQuery("Select userName, role from Accounts");
        }

        public bool UpdateAccount(string userName, string pass, string newPass)
        {
            int result = DbContext.Instance.ExecuteNonQuery("exec updateAccount @userName , @password , @newpass ", new object[] {userName,pass,newPass});
            return result > 0;
        }

        public bool addAccount(string userName, int role)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("insert accounts(userName , role) values ('{0}' , {1} )", userName, role));
            return res > 0;
        }

        public bool updateAcc(string userName, int role)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("update accounts set role = {0} where userName = '{1}'",role, userName));
            return res > 0;
        }

        public bool deleteAccount(string userName)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("Delete accounts where userName = '{0}'", userName));
            return res > 0;
        }

        public bool resetPass(string userName)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("update accounts set password = 0 where userName = '{0}'", userName));
            return res > 0;
        }
    }
}
