using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
