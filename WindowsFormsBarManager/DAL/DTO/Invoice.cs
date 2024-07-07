using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class Invoice
    {
        private int id;
        private DateTime? dateCheckIn;
        private DateTime? dateCheckOut;
        private int status;
        private int discount;

        public Invoice(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status, int discount = 0)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
            this.Discount=discount;
        }

        public Invoice(DataRow dataRow)
        {
            this.Id = (int)dataRow["invoiceId"];
            this.DateCheckIn = (DateTime?)dataRow["timeCheckin"];
            var dTemp = dataRow["timeCheckout"];
            if (dTemp.ToString() != "" )
            {
            this.DateCheckOut = (DateTime?)dTemp;
            }
            this.Status = (int)dataRow["status"];
            if (dataRow["discount"].ToString()!="")
            this.Discount = (int)dataRow["discount"];

        }

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
        public int Discount { get => discount; set => discount = value; }
    }
}
