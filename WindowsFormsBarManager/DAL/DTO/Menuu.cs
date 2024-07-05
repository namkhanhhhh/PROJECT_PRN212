using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsBarManager.DAL.DTO
{
    public class Menuu
    {
        private string drinkName;
        private int count;
        private float price;
        private float totalPrice;

        public Menuu(string drinkName, int count, float price, float totalPrice=0)
        {
            this.DrinkName = drinkName;
            this.Count = count;
            this.Price = price;
            this.TotalPrice = totalPrice;
        }

        public Menuu(DataRow dataRow)
        {
            this.DrinkName = dataRow["drinkName"].ToString();
            this.Count = (int)dataRow["count"];
            this.Price = (float)Convert.ToDouble(dataRow["price"].ToString());
            this.TotalPrice = (float)Convert.ToDouble(dataRow["TotalPrice"].ToString());
        }

        public string DrinkName { get => drinkName; set => drinkName = value; }
        public int Count { get => count; set => count = value; }
        public float Price { get => price; set => price = value; }
        public float TotalPrice { get => totalPrice; set => totalPrice = value; }
    }
}
