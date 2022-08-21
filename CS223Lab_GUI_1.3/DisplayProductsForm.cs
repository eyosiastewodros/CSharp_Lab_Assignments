using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            flpInventoryItems.Controls.Clear();
            foreach (var item in Product.GetAllProducts())
            {
                ProductCard prdctCard = new ProductCard(item.ItemName, item.InventoryNum, item.Price.ToString());
                flpInventoryItems.Controls.Add(prdctCard);
            }
        }
    }
}
