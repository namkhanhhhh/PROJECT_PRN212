using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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

        public bool UpdateAccount(string userName, string pass, string newPass)
        {
            int result = DbContext.Instance.ExecuteNonQuery("exec updateAccount @userName , @password , @newpass ", new object[] {userName,pass,newPass});
            return result > 0;
        }
    }
}
