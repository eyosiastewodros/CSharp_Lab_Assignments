using System;
using System.Collections;
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
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Initial Catalog=ElectronicsImportCompany;Integrated Security=true";
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = $"INSERT INTO Products VALUES({Number}, '{ItemName}', '{InventoryNum}', {Count}, {Price}, '{Date}', '{TargetDemogrGender}', '{TargetDemogrAge}')";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                } 
            }
            catch (SqlException e)
            {
                 MessageBox.Show(e.Message);
            }
        }

        public static List<Product> GetAllProducts()
        {
            //return products;
            List<Product> prdctsList = new List<Product>();
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "SELECT * FROM Products;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            prdctsList.Add(new Product(sdr.GetInt32(sdr.GetOrdinal("Number")),
                                                       sdr.GetString(sdr.GetOrdinal("ItemName")),
                                                       sdr.GetString(sdr.GetOrdinal("InventoryNum")),
                                                       sdr.GetInt32(sdr.GetOrdinal("Count")),
                                                       sdr.GetDouble(sdr.GetOrdinal("Price")),
                                                       sdr.GetString(sdr.GetOrdinal("Date")),
                                                       sdr.GetString(sdr.GetOrdinal("TargetDemogrGender")),
                                                       sdr.GetString(sdr.GetOrdinal("TargetDemogrAge"))));
                        }
                    }
                }
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }

            return prdctsList;
        }

        public static List<Product> FilterByPrice(double minPrice, double maxPrice)
        {
            //return products.FindAll(p => p.Price >= minPrice && p.Price <= maxPrice);
            List<Product> prdctsList = new List<Product>();
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM Products WHERE Price >= {minPrice} AND Price <= {maxPrice};";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        SqlDataReader sdr = cmd.ExecuteReader();

                        while (sdr.Read())
                        {
                            prdctsList.Add(new Product((int)sdr[0], (string)sdr[1], (string)sdr[2], (int)sdr[3], (double)sdr[4], (string)sdr[5], (string)sdr[6], (string)sdr[7]));
                        }
                    }
                }
                
            }
            catch (SqlException e)
            {
                MessageBox.Show(e.Message);
            }
            return prdctsList;
        }

        public static List<Product> FindByName(string name)
        {
            //return products.FindAll(p => p.ItemName == name);
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
        }
    }
}
