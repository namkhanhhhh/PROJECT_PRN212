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
    }
}
