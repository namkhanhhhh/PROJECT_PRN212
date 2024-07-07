using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsBarManager.DAL.DAO;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager
{
    public partial class bLogin : Form
    {
        public bLogin()
        {
            InitializeComponent();
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string userName=txtUserName.Text;
            string password=txtPassword.Text;
            if (isLogin(userName,password))
            {
            Account lAccount = AccountDAO.Instance.getAccountByUN(userName);
            tableManager f=new tableManager(lAccount);
            this.Hide();
            f.ShowDialog();
            this.Show();
            }
            else
            {
                MessageBox.Show("UserName or Password not valid. Please enter again !");
            }
            
        }

        private bool isLogin(string userName, string password)
        {
            return AccountDAO.Instance.isLogin(userName,password);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void bLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(MessageBox.Show("Are you want to exit program ?","Notification", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
    }
}
