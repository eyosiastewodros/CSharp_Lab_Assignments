using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS223Lab_GUI_1
{
    public partial class DisplayProductsForm : Form
    {
        public Form loginForm;
        public Form mainForm;
        public DisplayProductsForm(string username, Form loginForm, Form mainForm)
        {
            InitializeComponent();
            lblUsername.Text = username;
            this.loginForm = loginForm;
            this.mainForm = mainForm;
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            mainForm.Close();
            loginForm.Show();
        }

        private void prdct_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Product Clicked");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flpInventoryItems.Controls.Clear();
            foreach (var item in Product.GetAllProducts())
            {
                ProductCard prdctCard = new ProductCard(item.ItemName, item.InventoryNum, item.Price.ToString());
                prdctCard.Click += prdct_Click;
                flpInventoryItems.Controls.Add(prdctCard);
            }
        }

        private void btnTestConn_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    MessageBox.Show("Connection Successful");
                }
            }
            catch (SqlException excp)
            {
                MessageBox.Show(excp.Message);
            }
        }
    }
}
