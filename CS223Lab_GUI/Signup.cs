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

namespace CS223Lab_GUI_1
{
    public partial class Signup : Form
    {
        public Signup()
        {
            InitializeComponent();
        }
        public Signup(LoginForm lf)
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
          //memokerya
            Product.Usernames.Add("eyosi");
            Product.passwords.Add("eyosi");

            Product p = new Product();

            Regex repass = new Regex(@"^[a-z] $");
            Regex reuser = new Regex(@"^[a-z] $");
            bool[] bools = new bool[] { false, false };
            bool b = true;
            if (!(string.IsNullOrEmpty(pass_txt.Text) || string.IsNullOrEmpty(user_txt.Text)))

            {

                if (!(p.valuser(user_txt.Text) || p.valpass(pass_txt.Text)))
                {

                  if (!repass.IsMatch(pass_txt.Text))
                    {

                        errorProvider1.SetError(pass_txt, "character should be between a-z");
                        bools[0] = false;

                    }
                    else
                    {
                        bools[0] = true;

                    }


                     if (!repass.IsMatch(user_txt.Text))
                    {
                        errorProvider1.SetError(user_txt, "Make sure there are no special characters");
                        bools[1] = false;


                    }
                    else
                    {
                        errorProvider1.Clear();
                        bools[1] = true;

                    }
                    if (bools[0] == bools[1] == true)
                    {
                        //null refrence exception handler
                        if (Product.Usernames != null)
                        {
                            Product.Usernames.Add(user_txt.Text);
                            MessageBox.Show("user account succesfully created!");
                            this.Hide();

                            MainForm mainForm1 = new MainForm(user_txt.Text, this);
                            mainForm1.Show();
                            user_txt.Clear();
                            pass_txt.Clear();

                        }


                    }
                    else
                    {
                        MessageBox.Show("user account NOT succesfully created!(maybe memory,not duplicate!");
                        user_txt.Clear();
                        pass_txt.Clear();

                    }

                }
                else
                {
                    if (p.valuser(user_txt.Text) == true && p.valpass(pass_txt.Text) == false)

                    {
                        MessageBox.Show("This user name is already taken!! please Reenter your user name!");
                        user_txt.Clear();

                    }
                    else if (p.valuser(user_txt.Text) == false && p.valpass(pass_txt.Text) == true)
                    {
                        MessageBox.Show("This password is already taken!! please Reenter your password!");
                        pass_txt.Clear();


                    }

                    else if (p.valuser(user_txt.Text) && p.valpass(pass_txt.Text) == true)

                    {
                        MessageBox.Show("These Usernmae and password are already taken!! please Reenter your Both to continue!");

                        user_txt.Clear();
                        pass_txt.Clear();

                    }


                }
            }
            else
            {
                if (string.IsNullOrEmpty(pass_txt.Text) && string.IsNullOrEmpty(user_txt.Text))
                {

                    errorProvider1.SetError(user_txt, "Username can't be empty!");
                    errorProvider2.SetError(pass_txt, "password can't be empty!");


                  
                }
                else if (string.IsNullOrEmpty(user_txt.Text))
                {
                    errorProvider1.SetError(user_txt, "Username can't be empty!");


                }
                else if (string.IsNullOrEmpty(pass_txt.Text))
                {
                    errorProvider1.SetError(pass_txt, "Password can't be empty");

                }

            }



        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            this.Close();
            loginForm.Show();
        }
    }
    }
