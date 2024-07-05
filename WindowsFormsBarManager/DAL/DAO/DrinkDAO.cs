using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class DrinkDAO
    {
        public DrinkDAO() { }
        private static DrinkDAO instance;

        public static DrinkDAO Instance
        {
            get { if (instance == null) instance = new DrinkDAO(); return instance; }
            private set => instance = value;
        }

        public List<Drinks> getAllFoodByCategories(int id)
        {
            List<Drinks> dList = new List<Drinks>();
            string query = "select * from Drinks where catId= "+id;
            DataTable data = DbContext.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drinks drinks = new Drinks(item);
                dList.Add(drinks);
            }
            return dList;
        }
    }
}
