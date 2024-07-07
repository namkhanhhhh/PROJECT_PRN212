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
    public partial class userInformation : Form
    {

        private Account loginAccount;

        public Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;
                ChangeAccount(loginAccount);
            }
        }
        public userInformation(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
        }

        void ChangeAccount(Account acc) 
        {
            txtUserName.Text = LoginAccount.UserName;
            
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }

        void updateAccount()
        {
            string userName=txtUserName.Text;
            string password = txtPassword.Text;
            string newPass=txtNewPassword.Text;
            string rePass=txtConfirmPassword.Text;
            if(!newPass.Equals(rePass))
            {
                MessageBox.Show("The password you entered does not match the new password. Please re-enter!");
            }
            else
            {
                if(AccountDAO.Instance.UpdateAccount(userName, password, rePass))
                {
                    MessageBox.Show("Update Successfully");
                }
                else
                {
                    MessageBox.Show("Please enter valid password!");
                }
            }
        }
    }
}
