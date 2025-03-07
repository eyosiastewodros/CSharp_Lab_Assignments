﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CS223Lab_GUI_1
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //memokerya for pass and user
            Product.Usernames.Add("eyosi");
            Product.passwords.Add("eyosi");

            Product p = new Product();

            Regex repass = new Regex(@"^[a-z] $");
            Regex reuser = new Regex(@"^[a-z] $");
            bool[] bools = new bool[] { false, false };
            errorProvider1.Clear();

            errorProvider2.Clear();

            bool b = true;
            if (!(string.IsNullOrEmpty(pass_txt.Text) || string.IsNullOrEmpty(user_txt.Text)))

            {

                if ((p.valuser(user_txt.Text) && p.valpass(pass_txt.Text)))
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
                            MessageBox.Show("user account succesfully logged in!");
                            this.Hide();

                            MainForm mainForm1 = new MainForm(user_txt.Text, this);
                            mainForm1.Show();
                            user_txt.Clear();
                            pass_txt.Clear();

                        }


                    }
                    else
                    {
                        MessageBox.Show("user account NOT succesfully logged in!(maybe memory,not duplicate!");
                        user_txt.Clear();
                        pass_txt.Clear();

                    }

                }
                else
                {
                    if (p.valuser(user_txt.Text) == true && p.valpass(pass_txt.Text) == false)

                    {
                        MessageBox.Show("You got the name correct! Just try and remember your password");
                        pass_txt.Clear();

                    }
                    else if (p.valuser(user_txt.Text) == false && p.valpass(pass_txt.Text) == true)
                    {
                        MessageBox.Show("You Remembered your password. Now try and remember your usernmae!");
                        user_txt.Clear();


                    }

                    else if (p.valuser(user_txt.Text) && p.valpass(pass_txt.Text) == false)

                    {
                        MessageBox.Show("These Usernmae and password are non-existent!! please Reenter Both to continue!");

                        user_txt.Clear();
                        pass_txt.Clear();

                    }
                    else
                    {
                        MessageBox.Show("These Usernmae and password are non-existent!! please Reenter Both to continue!");

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


            private void button3_Click(object sender, EventArgs e)
            {
                LoginForm lf = new LoginForm();
                this.Hide();
                Signup s = new Signup(lf);
                s.Show();
            }
        }
    }
