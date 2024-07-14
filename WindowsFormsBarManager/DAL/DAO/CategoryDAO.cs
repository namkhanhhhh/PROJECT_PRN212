using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsBarManager.DAL.DTO;

namespace WindowsFormsBarManager.DAL.DAO
{
    public class CategoryDAO
    {
        public CategoryDAO() { }
        private static CategoryDAO instance;

        public static CategoryDAO Instance {
            get { if (instance == null) instance = new CategoryDAO(); return instance; }
            private set => instance = value;
        }

        public List<Category> getAllCategories()
        {
            List<Category> cList = new List<Category>();
            string query= "select * from DrinkCategories";
            DataTable data=DbContext.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                Category category = new Category(item);
                cList.Add(category);
            }
            return cList;
        }

        public Category getCateById(int id)
        {
            Category category=null;
            List<Category> cList = new List<Category>();
            string query = "select * from DrinkCategories where catId = '"+id+"'";
            DataTable data = DbContext.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
            }
            return category;
        }

        public Category getCateByName(string name)
        {
            Category category = null;
            List<Category> cList = new List<Category>();
            string query = "select * from DrinkCategories where catName = '" + name + "'";
            DataTable data = DbContext.Instance.ExcuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                category = new Category(item);
            }
            return category;
        }

        public bool addCate(string name)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("insert into DrinkCategories(catName) values ('{0}')", name));
            return res > 0;
        }

        public bool updateCate(int id, string name)
        {
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("update DrinkCategories set catName = '{0}' where catId = {1}", name, id));
            return res > 0;
        }

        public bool deleteCate(int id)
        {
            DrinkDAO.Instance.DeleteDrinksByCateId(id);
            int res = DbContext.Instance.ExecuteNonQuery(string.Format("Delete DrinkCategories where catId = {0}", id));
            return res > 0;
        }

        public bool CheckDrinksInInvoiceDetails(int categoryId)
        {
/*            string query = "SELECT COUNT(*) FROM InvoiceDetails WHERE drinkId IN ( SELECT drinkId FROM Drinks WHERE catId = @CategoryId )";
*/            int count = DbContext.Instance.ExecuteNonQuery(string.Format("SELECT COUNT(*) FROM InvoiceDetails WHERE drinkId IN ( SELECT drinkId FROM Drinks WHERE catId = {0} )", categoryId));
            return count > 0;
        }
    }
}
