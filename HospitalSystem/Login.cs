﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalSystem
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            if (UsernameTB.Text == "" || PasswordTB.Text == "")
            {
                MessageBox.Show("Missing Data!");
            }
            else if (UsernameTB.Text == "Admin" && PasswordTB.Text == "AdminPassword")
            {
                Patients Obj = new Patients();
                Obj.Show();
                this.Hide();
            }
            else
            {
                UsernameTB.Text = "";
                PasswordTB.Text = "";
            }
        }
    }
}
