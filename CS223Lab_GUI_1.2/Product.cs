using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CS223Lab_GUI_1
{
    class Product
    {
        public int Number { get; set; }
        public string ItemName { get; set; }
        public string InventoryNum { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }
        public string Date { get; set; }
        public string TargetDemogrGender { get; set; }
        public string TargetDemogrAge { get; set; }
        public static List<Product> products = new List<Product>();

        public void Save()
        {
            products.Add(this);
            Console.WriteLine("Product has been loaded to database.");
        }

        public static List<Product> GetAllProducts()
        {
            return products;
        }
    }
}
