using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
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

        public List<Drinks> getAllDrinks()
        {
            List<Drinks> dList = new List<Drinks>();
            string query = "select * from Drinks";
            DataTable data = DbContext.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Drinks drinks = new Drinks(item);
                dList.Add(drinks);
            }
            return dList;
        }

/*        public DataTable getAllDrinksWithCategoryName()
        {
            string query = "select drinkName, DrinkCategories.catName, price from drinks join DrinkCategories on DrinkCategories.catId=Drinks.catId";
            return DbContext.Instance.ExcuteQuery(query);
        }*/

        public bool addDrink(string name, int catId, float price)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("insert drinks(drinkName , catId , price) values ('{0}' , {1} , {2} )", name, catId, price ));
            return res>0;
        }

        public bool updateDrink(int id, string name, int catId, float price)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("update drinks set drinkName = '{0}', catId = {1} , price = {2} where drinkId = {3}", name, catId, price, id));
            return res > 0;
        }

        public bool deleteDrink(int id)
        {
            InvoiceDetailDAO.Instance.DeleteIDetailByDrinkId(id);
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("Delete drinks where drinkId = {0}", id));
            return res > 0;
        }

        public void DeleteDrinksByCateId(int id)
        {
            DbContext.Instance.ExcuteQuery("delete Drinks where catId = " + id);
        }

        public List<Drinks> searchDrinks(string name)
        {
            List<Drinks> dList = new List<Drinks>();
            string query =string.Format("select * from Drinks where drinkName like '%{0}%'",name);
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
