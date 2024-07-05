using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class Drinks
    {
        private int id;
        private string name;
        private int categoryId;
        private float price;

        public Drinks(int id, string name, int categoryId, float price)
        {
            this.Id = id;
            this.Name = name;
            this.CategoryId = categoryId;
            this.Price = price;
        }

        public Drinks( DataRow row) {
            this.Id = (int)row["drinkId"];
            this.name = (string)row["drinkName"];
            this.CategoryId = (int)row["catId"];
            this.Price = (float)Convert.ToDouble(row["price"].ToString());
        }


        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int CategoryId { get => categoryId; set => categoryId = value; }
        public float Price { get => price; set => price = value; }
    }


}
