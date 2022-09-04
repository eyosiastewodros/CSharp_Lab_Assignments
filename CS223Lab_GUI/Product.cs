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
    public class Product
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
                    string query = "INSERT INTO Products VALUES" +
                        "(@Number, @ItemName, @InventoryNum, @Count, @Price, @Date, @TargetDemogrGender, @TargetDemogrAge)";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Number", Number);
                        cmd.Parameters.AddWithValue("@ItemName", ItemName);
                        cmd.Parameters.AddWithValue("@InventoryNum", InventoryNum);
                        cmd.Parameters.AddWithValue("@Count", Count);
                        cmd.Parameters.AddWithValue("@Price", Price);
                        cmd.Parameters.AddWithValue("@Date", Date);
                        cmd.Parameters.AddWithValue("@TargetDemogrGender", TargetDemogrGender);
                        cmd.Parameters.AddWithValue("@TargetDemogrAge", TargetDemogrAge);

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
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            prdctsList.Add(new Product(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3), (double)reader.GetDecimal(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
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
                    string query = "SELECT * FROM Products WHERE Price >= @minPrice AND Price <= @maxPrice;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@minPrice", minPrice);
                        cmd.Parameters.AddWithValue("@maxPrice", maxPrice);
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            prdctsList.Add(new Product(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3), (double)reader.GetDecimal(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
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
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string query = "SELECT * FROM Products WHERE ItemName LIKE @name;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@name", name + "%");
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            prdctsList.Add(new Product(reader.GetInt16(0), reader.GetString(1), reader.GetString(2), reader.GetInt16(3), (double) reader.GetDecimal(4), reader.GetString(5), reader.GetString(6), reader.GetString(7)));
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
    }
}
