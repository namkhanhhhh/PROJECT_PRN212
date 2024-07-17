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
    public partial class admin : Form
    {
        BindingSource dList=new BindingSource();

        BindingSource aList=new BindingSource();

        BindingSource cList = new BindingSource();

        BindingSource tList=new BindingSource();

        public Account lAccount;
        public admin()
        {
            InitializeComponent();
            LoadAll();
        }

        void LoadAll()
        {
            dtgvAccounts.DataSource= aList;
            dtgvDrinks.DataSource = dList;
            dtgvCategories.DataSource = cList;
            dtgvTables.DataSource = tList;
            loadTime();
            loadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
            loadDrinks();
            loadAllCate(cbCategoryList);
            loadAccount();
            loadCate();
            loadTable();
            addDrinkBinding();
            addAccountBinding();
            addCategoryBinding();
            addTableBinding();

        }

        void loadListInvoiceByDate(DateTime checkIn, DateTime checkOut)
        {
          dtgvBill.DataSource= InvoiceDAO.Instance.getInvoiceByDate(checkIn, checkOut);
        }

        private void btnStatistic_Click(object sender, EventArgs e)
        {
            loadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
        }

        void loadTime()
        {
            DateTime now = DateTime.Now;
            dtpkFromDate.Value = new DateTime(now.Year, now.Month, 1);
            dtpkToDate.Value = dtpkFromDate.Value.AddMonths(1).AddDays(-1);
        }

        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            loadAccount();
        }

        private void btnViewDrinks_Click(object sender, EventArgs e)
        {
            loadDrinks();
        }

        void loadDrinks()
        {
            dList.DataSource = DrinkDAO.Instance.getAllDrinks();
            dtgvDrinks.Columns["Id"].Visible = false;
            dtgvDrinks.Columns["CategoryId"].Visible = false;
        }

        void loadAllCate(ComboBox comboBox)
        {
            comboBox.DataSource = CategoryDAO.Instance.getAllCategories();
            comboBox.DisplayMember = "Name";
        }

        void loadAccount()
        {
            txtAccountName.DataBindings.Clear();
            txtRole.DataBindings.Clear();

            aList.DataSource = AccountDAO.Instance.getAllAccount();
            txtRole.DataBindings.Add(new Binding("Text", dtgvAccounts.DataSource, "Role", true, DataSourceUpdateMode.Never));
            if (txtRole.Text.Equals("1"))
            {
                txtRole.Text = "Admin";
            }
            else
            {
                txtRole.Text = "Staff";
            }
        }

        void loadCate()
        {
            cList.DataSource=CategoryDAO.Instance.getAllCategories();
            dtgvCategories.Columns["Id"].Visible = false;
        }

        void loadTable()
        {
            tList.DataSource = TableDAO.Instance.LoadAllTable();
            dtgvTables.Columns["Id"].Visible = false;
        }


        void addAccountBinding()
        {
            // Remove existing bindings before adding new ones to avoid duplicates
            txtAccountName.DataBindings.Clear();
            txtRole.DataBindings.Clear();

            txtAccountName.DataBindings.Add(new Binding("Text", dtgvAccounts.DataSource, "UserName", true, DataSourceUpdateMode.Never));
            txtRole.DataBindings.Add(new Binding("Text", dtgvAccounts.DataSource, "Role", true, DataSourceUpdateMode.Never));

            // Update role text based on the value
            dtgvAccounts.SelectionChanged += (s, e) =>
            {
                if (txtRole.Text.Equals("1"))
                {
                    txtRole.Text = "Admin";
                }
                else
                {
                    txtRole.Text = "Staff";
                }
            };
        }


        void addDrinkBinding()
        {
            txtDrinkName.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "Name", true, DataSourceUpdateMode.Never));
            txtDrinkId.DataBindings.Add(new Binding("Text", dtgvDrinks.DataSource, "Id", true, DataSourceUpdateMode.Never));
            numberPrice.DataBindings.Add(new Binding("Value", dtgvDrinks.DataSource, "Price", true, DataSourceUpdateMode.Never));
        }

        void addCategoryBinding()
        {
            txtCategoryId.DataBindings.Add(new Binding("Text", dtgvCategories.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtCategoryName.DataBindings.Add(new Binding("Text", dtgvCategories.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        void addTableBinding()
        {
            txtTableId.DataBindings.Add(new Binding("Text", dtgvTables.DataSource, "Id", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTables.DataSource, "Name", true, DataSourceUpdateMode.Never));
        }

        private void txtDrinkId_TextChanged(object sender, EventArgs e)
        {
            if (dtgvDrinks.SelectedCells.Count > 0 && dtgvDrinks.SelectedCells[0].OwningRow.Cells["CategoryId"].Value != null)
            {
                int id = (int)dtgvDrinks.SelectedCells[0].OwningRow.Cells["CategoryId"].Value;

                Category category = CategoryDAO.Instance.getCateById(id);

                cbCategoryList.SelectedItem = category;

                int index = -1;
                int i = 0;
                foreach (Category item in cbCategoryList.Items)
                {
                    if (item.Id == category.Id)
                    {
                        index = i;
                        break;
                    }
                    i++;
                }
                cbCategoryList.SelectedIndex = index;
            }
        }

        private void btnSearchDrink_Click(object sender, EventArgs e)
        {
            dList.DataSource = SearchDrinks(txtSearchDrinks.Text);
        }

        List<Drinks> SearchDrinks(string name)
        {
            List<Drinks> dList = DrinkDAO.Instance.searchDrinks(name);
            return dList;
        }

        private void btnAddDrinks_Click(object sender, EventArgs e)
        {
            string name = txtDrinkName.Text;
            int catId = (cbCategoryList.SelectedItem as Category).Id;
            float price = (float)numberPrice.Value;

            if (DrinkDAO.Instance.addDrink(name, catId, price))
            {
                MessageBox.Show("Add drink successful !");
                loadDrinks();
                if (addDrinks != null)
                {
                    addDrinks(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }
        private void btnUpdateDrinkss_Click(object sender, EventArgs e)
        {
            string name = txtDrinkName.Text;
            int catId = (cbCategoryList.SelectedItem as Category).Id;
            float price = (float)numberPrice.Value;
            int id=Convert.ToInt32(txtDrinkId.Text);

            if (DrinkDAO.Instance.updateDrink(id, name, catId, price))
            {
                MessageBox.Show("Update drink successful !");
                loadDrinks();
                if (updateDrinks != null)
                {
                    updateDrinks(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnDeleteDrinks_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtDrinkId.Text);

            if (DrinkDAO.Instance.deleteDrink(id))
            {
                MessageBox.Show("Delete drink successful !");
                loadDrinks();
                if (deleteDrinks != null)
                {
                    deleteDrinks(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private event EventHandler addDrinks;
        public event EventHandler AddDrinks
        {
            add { addDrinks += value; }
            remove { addDrinks -= value; }
        }

        private event EventHandler updateDrinks;
        public event EventHandler UpdateDrinks
        {
            add { updateDrinks += value; }
            remove { updateDrinks -= value; }
        }

        private event EventHandler deleteDrinks;
        public event EventHandler DeleteDrinks
        {
            add { deleteDrinks += value; }
            remove { deleteDrinks -= value; }
        }

        private void btnAddCategories_Click(object sender, EventArgs e)
        {
            string name = txtCategoryName.Text;

            if (CategoryDAO.Instance.addCate(name))
            {
                MessageBox.Show("Add category successful !");
                loadCate();
                if (addCate != null)
                {
                    addCate(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnDeleteCategories_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);

            if (CategoryDAO.Instance.CheckDrinksInInvoiceDetails(id))
            {
                MessageBox.Show("There are drinks in this category that are present in invoice details. Please delete those drinks first before deleting the category.");
                return;
            }
            else
            {
                if (CategoryDAO.Instance.deleteCate(id))
                {
                    MessageBox.Show("Delete category successful !");
                    loadCate();
                    if (deleteCate != null)
                    {
                        deleteCate(this, new EventArgs());
                    }
                }
                else
                {
                    MessageBox.Show("Error");
                }
            }
        }

        private void btnEditCategories_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtCategoryId.Text);
            string name = txtCategoryName.Text;

            if (CategoryDAO.Instance.updateCate(id, name))
            {
                MessageBox.Show("Update category successful !");
                loadCate();
                if (updateCate != null)
                {
                    updateCate(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private event EventHandler addCate;
        public event EventHandler AddCate
        {
            add { addCate += value; }
            remove { addCate -= value; }
        }

        private event EventHandler updateCate;
        public event EventHandler UpdateCate
        {
            add { updateCate += value; }
            remove { updateCate -= value; }
        }

        private event EventHandler deleteCate;
        public event EventHandler DeleteCate
        {
            add { deleteCate += value; }
            remove { deleteCate -= value; }
        }

        private void btnAddTables_Click(object sender, EventArgs e)
        {
            string name = txtTableName.Text;

            if (TableDAO.Instance.addTable(name))
            {
                MessageBox.Show("Add table successful !");
                loadTable();
                if (addTable != null)
                {
                    addTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }

        private void btnEditTables_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtTableId.Text);
            string name = txtTableName.Text;

            if (TableDAO.Instance.updateTable(id, name))
            {
                MessageBox.Show("Update table successful !");
                loadTable();
                if (updateTable != null)
                {
                    updateTable(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Error");
            }
        }


        private event EventHandler addTable;
        public event EventHandler AddTable
        {
            add { addTable += value; }
            remove { addTable -= value; }
        }

        private event EventHandler updateTable;
        public event EventHandler UpdateTable
        {
            add { updateTable += value; }
            remove { updateTable -= value; }
        }

        void AddAccount(string userName, int role)
        {
            if (AccountDAO.Instance.addAccount(userName, role))
            {
                MessageBox.Show("Add account successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
            loadAccount();
        }


        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string userName=txtAccountName.Text;
            int role=txtRole.Text.ToLower().Equals("admin")?1:0;
            AddAccount(userName, role);
        }

        void DeleteAccount(string userName)
        {
            if (lAccount.UserName.Equals(userName))
            {
                MessageBox.Show("Cannot delete your Account!");
                return;
            }
            if (AccountDAO.Instance.deleteAccount(userName))
            {
                MessageBox.Show("Delete account successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
            loadAccount();
        }

        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;
            DeleteAccount(userName);
        }

        void UpdateAccount(string userName, int role)
        {
            if (AccountDAO.Instance.updateAcc(userName, role))
            {
                MessageBox.Show("Update account successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
            loadAccount();
        }

        private void btnUpdateAccount_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;
            int role = txtRole.Text.ToLower().Equals("admin") ? 1 : 0;
            UpdateAccount(userName, role);
        }

        void ResetPass(string userName)
        {
            if (AccountDAO.Instance.resetPass(userName))
            {
                MessageBox.Show("Reset Password successfully");
            }
            else
            {
                MessageBox.Show("Error");
            }
            loadAccount();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            string userName = txtAccountName.Text;
            ResetPass(userName);
        }
    }
}
