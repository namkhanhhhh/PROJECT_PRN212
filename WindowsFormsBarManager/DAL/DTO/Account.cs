using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DAO;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class Account
    {
        private string userName;
        private string password;
        private int role;

        public Account(string userName,int role, string password=null)
        {
            this.UserName = userName;
            this.password = password;
            this.Role = role;
        }

        public Account(DataRow row)
        {
            this.UserName = row["userName"].ToString();
            this.password = row["password"].ToString();
            this.Role = (int)row["role"];
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public int Role { get => role; set => role = value; }

    }
}
