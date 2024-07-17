using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class DrinkWithCategory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public float Price { get; set; }

        public DrinkWithCategory(int id, string name, string categoryName, float price)
        {
            this.Id = id;
            this.Name = name;
            this.CategoryName = categoryName;
            this.Price = price;
        }

        public DrinkWithCategory(DataRow row)
        {
            this.Id = (int)row["drinkId"];
            this.Name = (string)row["drinkName"];
            this.CategoryName = (string)row["catName"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }
    }

}
