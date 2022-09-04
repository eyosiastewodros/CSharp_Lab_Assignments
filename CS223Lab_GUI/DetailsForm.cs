using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms; 

namespace CS223Lab_GUI_1
{
    public partial class DetailsForm : Form
    {
        Form mainForm;
        Product prdctSelected;
        int timesClicked = 0;
        public DetailsForm(Product prdctSelected, Form mainForm)
        {
            InitializeComponent();
            txtNumber.Hide();
            txtItemName.Hide();
            txtInventoryNum.Hide();
            txtCount.Hide();
            txtPrice.Hide();
            dtpDate.Hide();

            lblNumber.Text = prdctSelected.Number.ToString();
            lblItemName.Text = prdctSelected.ItemName;
            lblInventoryNum.Text = prdctSelected.InventoryNum; 
            lblCount.Text = prdctSelected.Count.ToString();
            lblPrice.Text = prdctSelected.Price.ToString();
            lblDate.Text = prdctSelected.Date.ToString();
            this.prdctSelected = prdctSelected;
            this.mainForm = mainForm;
        }

        private void lblGoBack_Click(object sender, EventArgs e)
        {
            mainForm.Show();
            Close();
        }

        private void GoToEditMode()
        {
            txtNumber.Text = lblNumber.Text;
            txtItemName.Text = lblItemName.Text;
            txtInventoryNum.Text = lblInventoryNum.Text;
            txtCount.Text = lblCount.Text;
            txtPrice.Text = lblPrice.Text;
            dtpDate.Text = lblDate.Text;

            lblNumber.Hide();
            lblItemName.Hide();
            lblInventoryNum.Hide();
            lblCount.Hide();
            lblPrice.Hide();
            lblDate.Hide();

            txtNumber.Show();
            txtItemName.Show();
            txtInventoryNum.Show();
            txtCount.Show();
            txtPrice.Show();
            dtpDate.Show();
        }

        private void GoToNormalMode()
        {
            lblNumber.Text = txtNumber.Text;
            lblItemName.Text = txtItemName.Text;
            lblInventoryNum.Text = txtInventoryNum.Text;
            lblCount.Text = txtCount.Text;
            lblPrice.Text = txtPrice.Text;
            lblDate.Text = dtpDate.Text;

            txtNumber.Hide();
            txtItemName.Hide();
            txtInventoryNum.Hide();
            txtCount.Hide();
            txtPrice.Hide();
            dtpDate.Hide();

            lblNumber.Show();
            lblItemName.Show();
            lblInventoryNum.Show();
            lblCount.Show();
            lblPrice.Show();
            dtpDate.Show();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (timesClicked == 0)
            {
                GoToEditMode();
                btnUpdate.BackColor = Color.DarkCyan;
                btnUpdate.ForeColor = Color.White;
                btnUpdate.Text = "Save";
            }
            else
            {
                try
                {
                    string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                    using (var conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = "UPDATE Products " +
                            "SET Number = @Number, ItemName = @ItemName, InventoryNum = @InventoryNum, Count = @Count, Price = @Price, Date = @Date " +
                            "WHERE InventoryNum = @InventoryNum2;";
                        using (var cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Number", txtNumber.Text);
                            cmd.Parameters.AddWithValue("@ItemName", txtItemName.Text);
                            cmd.Parameters.AddWithValue("@InventoryNum", txtInventoryNum.Text);
                            cmd.Parameters.AddWithValue("@Count", txtCount.Text);
                            cmd.Parameters.AddWithValue("@Price", txtPrice.Text);
                            cmd.Parameters.AddWithValue("@Date", dtpDate.Text);

                            cmd.Parameters.AddWithValue("@InventoryNum2", prdctSelected.InventoryNum);

                            cmd.ExecuteNonQuery();
                        }
                    }
                    GoToNormalMode();
                    MessageBox.Show("Product Info has been updated successfully. \n" +
                        "Hit Refresh to see changes.");
                    Close();
                    mainForm.Show();
                }
                catch (SqlException excp)
                {
                    MessageBox.Show(excp.Message);
                }
            }
            timesClicked++;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string connString = @"Server=DESKTOP-S1FH2A6\SQLEXPRESS;Database=ElectronicsImportCompany;Integrated Security=true";
                using (var conn = new SqlConnection(connString))
                {
                    conn.Open();
                    string query = "DELETE FROM Products " +
                        "WHERE InventoryNum = @InventoryNum;";
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@InventoryNum", lblInventoryNum.Text);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Product Info has been deleted successfully.\n" +
                    "Hit Refresh to see changes.");
                Close();
                mainForm.Show();
            }
            catch (SqlException excp)
            {
                MessageBox.Show(excp.Message);
            }
        }
    }
}
