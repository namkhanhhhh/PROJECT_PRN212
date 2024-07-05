using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class InvoiceDetail
    {
        private int id;
        private int invoiceId;
        private int drinkId;
        private int count;

        public InvoiceDetail(int id, int invoiceId, int drinkId, int count)
        {
            this.Id = id;
            this.InvoiceId = invoiceId;
            this.DrinkId = drinkId;
            this.Count = count;
        }

        public InvoiceDetail(DataRow dataRow)
        {
            this.Id = (int)dataRow["invoiceDtlId"];
            this.InvoiceId = (int)dataRow["invoiceId"];
            this.DrinkId = (int)dataRow["drinkId"];
            this.Count = (int)dataRow["count"];
        }

        public int Id { get => id; set => id = value; }
        public int InvoiceId { get => invoiceId; set => invoiceId = value; }
        public int DrinkId { get => drinkId; set => drinkId = value; }
        public int Count { get => count; set => count = value; }
    }
}
