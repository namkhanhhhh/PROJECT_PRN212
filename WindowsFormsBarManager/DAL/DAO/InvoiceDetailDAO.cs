using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class InvoiceDetailDAO
    {
        private static InvoiceDetailDAO instance;

        public static InvoiceDetailDAO Instance {
            get { if (instance == null) instance = new InvoiceDetailDAO(); return instance; }
            private set => instance = value;
        }

        private InvoiceDetailDAO() { }

        public List<InvoiceDetail> GetAllInvoiceDetail(int id)
        {
            List<InvoiceDetail> IDlist=new List<InvoiceDetail>();

            DataTable data = DbContext.Instance.ExcuteQuery("select * from InvoiceDetails where invoiceId = "+id);
            foreach (DataRow row in data.Rows)
            {
                InvoiceDetail invoiceDetail = new InvoiceDetail(row);
                IDlist.Add(invoiceDetail);
            }
            return IDlist;
        }
        public void InsertInvoiceDetails(int invoice, int drinkId, int count)
        {
        DbContext.Instance.ExecuteNonQuery("InsertInvoiceDetailss @invoice , @drinkId , @count ", new object[] { invoice , drinkId , count });
        }
    }
}
