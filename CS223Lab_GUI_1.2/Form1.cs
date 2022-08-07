using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

// list, datagridview, validation (regex), error (errorprovider)
// checkbox & checkedlist box, radio button, group box, multiple forms (login & main) with data transfer

namespace CS223Lab_GUI_1
{
    public partial class Form1 : Form
    {
        public Form LoginPage;
        public Form1(string username, Form LoginPage)
        {
            InitializeComponent();
            lblUsername.Text = username;
            this.LoginPage = LoginPage;
        }

        Regex numRegex = new Regex(@"^\d+$"); // a whole number
        Regex nameRegex = new Regex(@"^\w+(\s\w+){0,3}$"); // 4 words at most
        Regex priceRegex = new Regex(@"^\d+(\.\d{1,2})?$"); // a whole number or a decimal with 1 or 2 decimal places
        bool[] isValid = { false, false, false, false, false };

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Product prdct1 = new Product();
            prdct1.Date = dtpItemDate.Text;

            // Number validation
            if (String.IsNullOrEmpty(txtNumber.Text))
            {
                errorProvider1.SetError(txtNumber, "Number is required.");
                isValid[0] = false;
            }
            else if (!numRegex.IsMatch(txtNumber.Text))
            {
                errorProvider1.SetError(txtNumber, "Make sure you entered a whole number.");
                isValid[0] = false;
            }
            else
            {
                errorProvider1.Clear();
                prdct1.Number = int.Parse(txtNumber.Text);
                isValid[0] = true;
            }
            
            // Name Validation
            if (String.IsNullOrEmpty(txtItemName.Text))
            {
                errorProvider2.SetError(txtItemName, "Item Name is required.");
                isValid[1] = false;
            }
            else if (!nameRegex.IsMatch(txtItemName.Text) || numRegex.IsMatch(txtItemName.Text))
            {
                errorProvider2.SetError(txtItemName,
                    "Make sure you didn't enter any special characters." +
                    "\nAt most 4 words are allowed." +
                    "\nName cannot be just numbers.");
                isValid[1] = false;
            }
            else
            {
                errorProvider2.Clear();
                prdct1.ItemName = txtItemName.Text;
                isValid[1] = true;
            }

            // Inventory Number Validation
            if (String.IsNullOrEmpty(txtInventoryNum.Text))
            {
                errorProvider3.SetError(txtInventoryNum, "Inventory Number is required.");
                isValid[2] = false;
            }
            else if (!numRegex.IsMatch(txtInventoryNum.Text))
            {
                errorProvider3.SetError(txtInventoryNum, "Make sure you entered a whole number.");
                isValid[2] = false;
            }
            else
            {
                errorProvider3.Clear();
                prdct1.InventoryNum = "IN-" + txtInventoryNum.Text;
                isValid[2] = true;
            }

            // Count Validation
            if (String.IsNullOrEmpty(txtCount.Text))
            {
                errorProvider4.SetError(txtCount, "Count is required");
                isValid[3] = false;
            }
            else if (!numRegex.IsMatch(txtCount.Text) || String.Equals(txtCount.Text, "0"))
            {
                errorProvider4.SetError(txtCount, "Make sure you entered a whole number different from zero.");
                isValid[3] = false;
            }
            else
            {
                errorProvider4.Clear();
                prdct1.Count = int.Parse(txtCount.Text);
                isValid[3] = true;
            }

            // Price Validation
            if (String.IsNullOrEmpty(txtPrice.Text))
            {
                errorProvider5.SetError(txtPrice, "Price is required.");
                isValid[4] = false;
            }
            else if (!priceRegex.IsMatch(txtPrice.Text))
            {
                errorProvider5.SetError(txtPrice, "Make sure you entered only 2 digits after the decimal.");
                isValid[4] = false;
            }
            else
            {
                errorProvider5.Clear();
                prdct1.Price = double.Parse(txtPrice.Text);
                isValid[4] = true;
            }

            // Gender Input
            string targetDemogrGender = "";
            try
            {
                targetDemogrGender = grpBoxTargetDemographics.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked).Text;
            } catch (Exception exception1)
            {
                targetDemogrGender = "-";
            } finally
            {
                prdct1.TargetDemogrGender = targetDemogrGender;
            }


            // Age Input
            var targetDemogrAge = clbAge.CheckedItems;
            if (targetDemogrAge.Count == 0)
            {
                prdct1.TargetDemogrAge = "-";
            }
            else
            {
                foreach (var age in targetDemogrAge)
                {
                    prdct1.TargetDemogrAge += (age.ToString()).Replace(" years", "") + ", ";
                }
                prdct1.TargetDemogrAge = (prdct1.TargetDemogrAge).Remove(prdct1.TargetDemogrAge.Length - 2);
            }

            bool allAreValid = isValid[0] && isValid[1] && isValid[2] && isValid[3] && isValid[4];

            if (allAreValid)
            {
                prdct1.Save();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = Product.GetAllProducts();
                MessageBox.Show($"Product {prdct1.ItemName} Has Been Added Successfully!");
                
                txtNumber.Clear();
                txtItemName.Clear();
                txtInventoryNum.Clear();
                txtCount.Clear();
                txtPrice.Clear();
                foreach (RadioButton rb in grpBoxTargetDemographics.Controls.OfType<RadioButton>())
                {
                    rb.Checked = false;
                }
                clbAge.ClearSelected();
            }
            else
            {
                MessageBox.Show("Go back and fix the error(s)", "Invalid Input");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDoneClicked(object sender, EventArgs e)
        {
            RadioButton item = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            MessageBox.Show(item.Name);
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginPage.Show();
        }
    }
}
