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
    public partial class SearchProductForm : Form
    {
        public Form loginForm;
        public Form mainForm;
        public SearchProductForm(string username, Form loginForm, Form mainForm)
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

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // dgvSearchResults.DataSource = null;
            if (String.IsNullOrEmpty(txtSearchEntry.Text))
            {
                return;
            }
            if (Product.findByName(txtSearchEntry.Text).Count() == 0)
            {
                dgvSearchResults.DataSource = null;
                MessageBox.Show("No Results Found.", "Search");
            }
            else
            {
                dgvSearchResults.DataSource = Product.findByName(txtSearchEntry.Text);
            }
        }

        private void btnPriceFilter1_Click(object sender, EventArgs e)
        {
            List<Product> filterResults = Product.findAll(0, 10);
            if (filterResults.Count() == 0)
            {
                dgvSearchResults.DataSource = null;
                MessageBox.Show("No Results Found.", "Filter");
            }
            else
            {
                dgvSearchResults.DataSource = filterResults;
            }
        }

        private void btnPriceFilter2_Click(object sender, EventArgs e)
        {
            List<Product> filterResults = Product.findAll(10, 80);
            if (filterResults.Count() == 0)
            {
                dgvSearchResults.DataSource = null;
                MessageBox.Show("No Results Found.", "Filter");
            }
            else
            {
                dgvSearchResults.DataSource = filterResults;
            }
        }

        private void btnPriceFilter3_Click(object sender, EventArgs e)
        {
            List<Product> filterResults = Product.findAll(80, 150);
            if (filterResults.Count() == 0)
            {
                dgvSearchResults.DataSource = null;
                MessageBox.Show("No Results Found.", "Filter");
            }
            else
            {
                dgvSearchResults.DataSource = filterResults;
            }
        }
    }
}
