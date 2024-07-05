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

        public Invoice(int id, DateTime? dateCheckIn, DateTime? dateCheckOut, int status)
        {
            this.Id = id;
            this.DateCheckIn = dateCheckIn;
            this.DateCheckOut = dateCheckOut;
            this.Status = status;
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
        }

        public int Id { get => id; set => id = value; }
        public DateTime? DateCheckIn { get => dateCheckIn; set => dateCheckIn = value; }
        public DateTime? DateCheckOut { get => dateCheckOut; set => dateCheckOut = value; }
        public int Status { get => status; set => status = value; }
    }
}
