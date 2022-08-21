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
        public string Date { get; set; }
        public string InventoryNum { get; set; }
        public string ItemName { get; set; }
        public int Count { get; set; }
        public double Price { get; set; }

        public void Save()
        {
            Console.WriteLine("Product has been loaded to database.");
        }
    }
}
