﻿using System;
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

        public void ChangeTable(int tableFirst, int tableSecond)
        {
            DbContext.Instance.ExcuteQuery("changeTable @idTableFirst , @idTableSecond", new object[] {tableFirst,tableSecond});
        }

        public static int TableWidth = 70;
        public static int TableHeight = 70;
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
        public bool addTable(string name)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("insert into barTables(tableName) values ('{0}')", name));
            return res > 0;
        }

        public bool updateTable(int id, string name)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("update barTables set tableName = '{0}' where tableId = {1}", name, id));
            return res > 0;
        }
    }
}
