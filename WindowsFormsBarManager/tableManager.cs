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
    public partial class tableManager : Form
    {

        private Account loginAccount;

        public Account LoginAccount { 
        get { return loginAccount; }
            set { loginAccount = value; 
                changeAccount(loginAccount.Role); }
        }

        public tableManager(Account acc)
        {
            InitializeComponent();
            this.LoginAccount = acc;
            LoadTable();
            LoadCategories();
            LoadCbTable(cbxSwitchTable);
        }

        void changeAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type ==1;
        }

        void LoadCategories()
        {
            List<Category> cList = CategoryDAO.Instance.getAllCategories();
            cbxCategory.DataSource = cList;
            cbxCategory.DisplayMember = "Name";
        }

        void LoadDrinksByCategories(int id)
        {
            List<Drinks> dList=DrinkDAO.Instance.getAllFoodByCategories(id);
            cbxDrinks.DataSource = dList;
            cbxDrinks.DisplayMember= "Name";
                }

        void LoadTable()
        {

            flpTable.Controls.Clear();
            List<Table>tList=TableDAO.Instance.LoadAllTable();
            foreach(Table item in tList)
            {
                Button btn=new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name+Environment.NewLine+item.Status;
                btn.Click += btn_Click;
                btn.Tag = item;
                if (item.Status.Equals("Empty"))
                {
                    btn.BackColor = Color.Green;
                    btn.ForeColor = Color.White;
                }else if (item.Status.Equals("Full"))
                {
                    btn.BackColor= Color.Red;
                    btn.ForeColor = Color.White;
                }
                flpTable.Controls.Add(btn);
            }
        }

        void ShowInvoice(int tableID)
        {
            ViewOrder.Items.Clear();
            List<Menuu> IDlist = MenuDAO.Instance.GetMenuByT(tableID);
            float totalPrice = 0;
            foreach(Menuu item in IDlist)
            {
                ListViewItem lItem = new ListViewItem(item.DrinkName.ToString());
                lItem.SubItems.Add(item.Count.ToString());
                lItem.SubItems.Add(item.Price.ToString());
                lItem.SubItems.Add(item.TotalPrice.ToString());
                totalPrice += item.TotalPrice;
                ViewOrder.Items.Add(lItem);
            }
            txtTotalPrice.Text = totalPrice.ToString();
        }

        private void btn_Click(object sender, EventArgs e)
        {
            int tableID=((sender as Button).Tag as Table).Id;
            ViewOrder.Tag = (sender as Button).Tag;
            ShowInvoice(tableID);

        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            admin a=new admin();
            a.lAccount = LoginAccount;
            a.AddDrinks += aAdd;
            a.UpdateDrinks += aUpdate;
            a.DeleteDrinks += aDelete;
            a.AddCate += aAdd;
            a.UpdateCate += aUpdate;
            a.DeleteCate += aDelete;
            a.ShowDialog();
        }

        private void aDelete(object sender, EventArgs e)
        {
            LoadDrinksByCategories((cbxCategory.SelectedItem as Category).Id);
            if (ViewOrder.Tag != null)
            ShowInvoice((ViewOrder.Tag as Table).Id);
            LoadTable();
            LoadCategories();
            LoadTable();
        }

        private void aUpdate(object sender, EventArgs e)
        {
            LoadDrinksByCategories((cbxCategory.SelectedItem as Category).Id);
            if (ViewOrder.Tag != null)
            ShowInvoice((ViewOrder.Tag as Table).Id);
            LoadCategories();
            LoadTable();
        }

        private void aAdd(object sender, EventArgs e)
        {
            LoadDrinksByCategories((cbxCategory.SelectedItem as Category).Id);
            if(ViewOrder.Tag != null)
            ShowInvoice((ViewOrder.Tag as Table).Id);
            LoadCategories();
            LoadTable();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInformation userInfo = new userInformation(LoginAccount);
            userInfo.ShowDialog();
        }

        private void cbxCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id= 0;
            ComboBox cb=sender as ComboBox;
            if (cb.SelectedItem == null)
            {
                return;
            }
            Category selected=cb.SelectedItem as Category;
            id=selected.Id;
            LoadDrinksByCategories(id);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Table table=ViewOrder.Tag as Table;
            if (table==null)
            {
                MessageBox.Show("Please choose table");
                return;
            }
            int invoice=InvoiceDAO.Instance.GetUncheckInvoiceIdByTableId(table.Id);
            int drinkId=(cbxDrinks.SelectedItem as Drinks).Id;
            int count= (int)numberDrinkQuantity.Value;
            if (invoice==-1)
            {
                InvoiceDAO.Instance.InsertInvoice(table.Id);
                InvoiceDetailDAO.Instance.InsertInvoiceDetails(InvoiceDAO.Instance.GetMaxId(),drinkId,count);
            }
            else
            {
                InvoiceDetailDAO.Instance.InsertInvoiceDetails(invoice, drinkId, count);
            }

            ShowInvoice(table.Id);
            LoadTable();
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Table table=ViewOrder.Tag as Table;
            int invoiceId= InvoiceDAO.Instance.GetUncheckInvoiceIdByTableId(table.Id);
            int discount=(int)numberDiscount.Value;
            double totalPrice=Convert.ToDouble(txtTotalPrice.Text);
            double price = totalPrice - (totalPrice / 100) * discount;
            if (invoiceId!=-1)
            {
                if(MessageBox.Show(string.Format("Are you sure to checkout with {0}\n TotalPrice with discount = {1} : {2}", table.Name, discount, price)
                    , "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    InvoiceDAO.Instance.Checkout(invoiceId, discount,(float)price);
                    ShowInvoice(table.Id);
                    LoadTable();
                }
            }
        }
        private void btnChangeTable_Click(object sender, EventArgs e)
        {
            int idTable1 = (ViewOrder.Tag as Table).Id;
            int idTable2 = (cbxSwitchTable.SelectedItem as Table).Id;
            String t1Name = (ViewOrder.Tag as Table).Name;
            String t2Name= (cbxSwitchTable.SelectedItem as Table).Name;
            if (MessageBox.Show(string.Format("Are you want to change table from {0} to {1}", t1Name, t2Name)
                ,"Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
            {
                TableDAO.Instance.ChangeTable(idTable1, idTable2);
                LoadTable();
            }
        }

        void LoadCbTable(ComboBox cb)
        {
            cb.DataSource=TableDAO.Instance.LoadAllTable();
            cb.DisplayMember = "Name";
        }

        private void accountInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInformation u=new userInformation(loginAccount);
        }
    }
}
