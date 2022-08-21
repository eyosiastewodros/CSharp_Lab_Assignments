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
    public partial class MainForm : Form
    {
        // AddProductForm addProductForm1 = new AddProductForm();
        AddProductForm2 apf2;
        SearchProductForm searchProductForm1;
        DisplayProductsForm displayProductsForm1;

        public MainForm(string username, Form loginForm)
        {
            InitializeComponent();

            apf2 = new AddProductForm2(username, loginForm, this);
            searchProductForm1 = new SearchProductForm(username, loginForm, this);
            displayProductsForm1 = new DisplayProductsForm(username, loginForm, this);

            // addProductForm1.MdiParent = this;
            apf2.MdiParent = this;
            searchProductForm1.MdiParent = this;
            displayProductsForm1.MdiParent = this;

            // apf2.username = username;
            // apf2.loginForm = loginForm;
            // apf2.mainForm = this;
            // searchProductForm1.username = username;
            // searchProductForm1.loginForm = loginForm;
            // searchProductForm1.mainForm = this;
            // displayProductsForm1.username = username;
            // displayProductsForm1.loginForm = loginForm;
            // displayProductsForm1.mainForm = this;
            
            apf2.Show();
        }

        private void addProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != apf2)
            {
                ActiveMdiChild.Hide();
                apf2.Show();
            }
        }

        private void searchProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != searchProductForm1)
            {
                ActiveMdiChild.Hide();
                searchProductForm1.Show();
            }
        }

        private void displayProductsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveMdiChild != displayProductsForm1)
            {
                ActiveMdiChild.Hide();
                displayProductsForm1.Show();
            }
        }
    }
}
