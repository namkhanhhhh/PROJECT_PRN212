using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class InvoiceDAO
    {
        private static InvoiceDAO instance;

        public static InvoiceDAO Instance {
            get { if (instance == null) instance = new InvoiceDAO(); return instance; }
            private set => instance = value;
        }

        private InvoiceDAO() { }

        public int GetUncheckInvoiceIdByTableId(int id) {
            DataTable data = DbContext.Instance.ExcuteQuery("select * from Invoices where tableId = "+id+"and status = 0");
            if(data.Rows.Count > 0)
            {
                Invoice invoice = new Invoice(data.Rows[0]);
                return invoice.Id;
            }
            return -1;
                }
        public void InsertInvoice(int id)
        {
            DbContext.Instance.ExecuteNonQuery("exec InsertInvoice @tableId", new object[]{id});
        }
        
        public int GetMaxId()
        {
            try
            {
            return (int)DbContext.Instance.ExcuteScalar("select MAX(invoiceId) from Invoices");
            }
            catch
            {
                return 1;
            }
           
        }

        public void Checkout(int id)
        {
            string query= "update Invoices set status = 1 where invoiceId = "+id;
            DbContext.Instance.ExecuteNonQuery(query);
        }
    }
}
