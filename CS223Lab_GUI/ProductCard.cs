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
    public partial class ProductCard : UserControl
    {
        public ProductCard()
        {
            InitializeComponent();
        }

        public ProductCard(Product prdct)
        {
            InitializeComponent();
            this.prdct = prdct;
            ProductName = prdct.ItemName;
            InventoryNum = prdct.InventoryNum;
            Price = (prdct.Price).ToString();
        }

        public Product prdct { get; set; }

        private string _productName;

        public string ProductName
        {
            get { return _productName; }
            set { _productName = value; lblName.Text = value; }
        }

        private string _inventoryNum;

        public string InventoryNum
        {
            get { return _inventoryNum; }
            set { _inventoryNum = value; lblInventoryNum.Text = value; }
        }
       
        private string _price;

        public string Price
        {
            get { return _price; }
            set { _price = value; lblPrice.Text = value; }
        }
    }
}
