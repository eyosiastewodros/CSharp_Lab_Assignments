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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product prdct1 = new Product 
            { 
                Number = int.Parse(txtNumber.Text), 
                Date = dtpItemDate.Text, 
                InventoryNum = txtInventoryNum.Text, 
                ItemName = txtItemName.Text, 
                Count = int.Parse(txtCount.Text), 
                Price = double.Parse(txtPrice.Text)
            };
            prdct1.Save();
            MessageBox.Show($"Product {prdct1.ItemName} Has Been Added Successfully!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtNumber.Clear();
            txtInventoryNum.Clear();
            txtItemName.Clear();
            txtCount.Clear();
            txtPrice.Clear();
        }
    }
}
