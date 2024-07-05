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
        public tableManager()
        {
            InitializeComponent();
            LoadTable();
            LoadCategories();
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
            a.ShowDialog();
        }

        private void userInformationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            userInformation userinformation = new userInformation();
            userinformation.ShowDialog();
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
            if (invoiceId!=-1)
            {
                if(MessageBox.Show("Are you sure to checkout with " + table.Name, "Notification", MessageBoxButtons.OKCancel) == System.Windows.Forms.DialogResult.OK)
                {
                    InvoiceDAO.Instance.Checkout(invoiceId);
                    ShowInvoice(table.Id);
                    LoadTable();
                }
            }
        }
    }
}
