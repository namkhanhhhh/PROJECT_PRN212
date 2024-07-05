using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;


namespace WindowsFormsBarManager.DAL.DAO
{
    public class MenuDAO
    {
        private static MenuDAO instance;

        public static MenuDAO Instance {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set => instance = value;
        }

        private MenuDAO() { }

        public List<Menuu> GetMenuByT(int id)
        {
            List<Menuu> mList = new List<Menuu>();
            DataTable data = DbContext.Instance.ExcuteQuery("  select Drinks.drinkName, InvoiceDetails.count, Drinks.price, Drinks.price*InvoiceDetails.count as TotalPrice " +
                "from InvoiceDetails, Invoices, Drinks\r\n  " +
                "where InvoiceDetails.invoiceId=Invoices.invoiceId and InvoiceDetails.drinkId=Drinks.drinkId and Invoices.status=0 and Invoices.tableId= "+ id);
            
            foreach (DataRow row in data.Rows)
            {
                Menuu m = new Menuu(row);
                mList.Add(m);
            }
            return mList;
        }
    }
}
