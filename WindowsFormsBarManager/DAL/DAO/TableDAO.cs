using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set => instance = value;
        }

        public static int TableWidth = 80;
        public static int TableHeight = 80;
        private TableDAO() { }
        public List<Table> LoadAllTable()
        {
            List<Table> tList = new List<Table>();
            DataTable data = DbContext.Instance.ExcuteQuery("Select * from BarTables");
            foreach (DataRow row in data.Rows)
            {
                Table table=new Table(row);
                tList.Add(table);
            }
            return tList;
        }
    }
}
