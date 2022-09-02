using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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

        public Product()
        {

        }
        public Product(int Number, string ItemName, string InventoryNum, int Count, double Price, string Date, string TargetDemogrGender, string TargetDemogrAge)
        {
            this.Number = Number;
            this.ItemName = ItemName;
            this.InventoryNum = InventoryNum;
            this.Count = Count;
            this.Price = Price;
            this.Date = Date;
            this.TargetDemogrGender = TargetDemogrGender;
            this.TargetDemogrAge = TargetDemogrAge;
        }
        public void Save()
        {
            //products.Add(this);
            //Console.WriteLine("Product has been loaded to database.");
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                var conn = new SqlConnection(connString);
                conn.Open();

                string dbDate = Date.Substring(Date.Length - 4) + "-" + Date.Substring(Date.Length - 7, 2) + "-" + Date.Substring(Date.Length - 10, 2);
                string query = $"INSERT INTO Products VALUES({Number}, '{ItemName}', '{InventoryNum}', {Count}, {Price}, '{dbDate}', '{TargetDemogrGender}', '{TargetDemogrAge}')";
                var cmd = new SqlCommand(query, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (SqlException e)
            {
                 MessageBox.Show(e.Message);
            }
        }

        public static List<Product> GetAllProducts()
        {
            List<Product> prdctsList = new List<Product>();
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                var conn = new SqlConnection(connString);
                conn.Open();

                string query = "SELECT * FROM Products;";
                var cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    prdctsList.Add(new Product((int)sdr[0], (string)sdr[1], (string)sdr[2], (int)sdr[3], (double)sdr[4], (string)sdr[5], (string)sdr[6], (string)sdr[7]));
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return prdctsList;
        }

        public static List<Product> FilterByPrice(double minPrice, double maxPrice)
        {
            List<Product> prdctsList = new List<Product>();

            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                var conn = new SqlConnection(connString);
                conn.Open();

                string query = $"SELECT * FROM Products WHERE Price >= {minPrice} AND Price <= {maxPrice};";
                var cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    prdctsList.Add(new Product((int)sdr[0], (string)sdr[1], (string)sdr[2], (int)sdr[3], (double)sdr[4], (string)sdr[5], (string)sdr[6], (string)sdr[7]));
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return prdctsList;
            //return products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
        }

        public static List<Product> FindByName(string name)
        {
            List<Product> prdctsList = new List<Product>();

            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                var conn = new SqlConnection(connString);
                conn.Open();

                string query = $"SELECT * FROM Products WHERE ItemName = '{name}';";
                var cmd = new SqlCommand(query, conn);
                SqlDataReader sdr = cmd.ExecuteReader();

                while (sdr.Read())
                {
                    prdctsList.Add(new Product((int)sdr[0], (string)sdr[1], (string)sdr[2], (int)sdr[3], (double)sdr[4], (string)sdr[5], (string)sdr[6], (string)sdr[7]));
                }
                conn.Close();
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return prdctsList;
            //return products.FindAll(p => p.ItemName == name);
        }
    }
}
