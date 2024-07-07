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

namespace WindowsFormsBarManager
{
    public partial class admin : Form
    {
        public admin()
        {
            InitializeComponent();
            LoadAll();
        }

        void LoadAll()
        {
            loadTime();
            loadListInvoiceByDate(dtpkFromDate.Value, dtpkToDate.Value);
            loadDrinks();
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

        private void btnViewDrinks_Click(object sender, EventArgs e)
        {
            loadDrinks();
        }

        void loadDrinks()
        {
            dtgvDrinks.DataSource=DrinkDAO.Instance.getAllDrinks();
        }
    }
}
