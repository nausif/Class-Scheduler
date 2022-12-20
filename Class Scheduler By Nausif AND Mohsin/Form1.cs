using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    public partial class Form1 : Form
    {
        public static Form1 F1obj;
        public Form1()
        {
            F1obj = this;
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {
            ClassStatic.FileExists();
        }
        

        Class_Schedule FormCS = new Class_Schedule();
        private void btnNext_Click(object sender, EventArgs e)
        {
            LoginCheck LC = new LoginCheck();
            if (LC.CheckLogin(txtb_login,txtb_Pass,RBAdmin))
            {
                FormCS.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid Login Attempt");
                LC.GUIset(txtb_login, txtb_Pass, RBAdmin);
            }
        }

        private void txtb_login_KeyPress(object sender, KeyPressEventArgs e)
        {
            
                if (RBuser.Checked == true)
                {
                    if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                    {
                        e.Handled = true;
                    }
                    else { e.Handled = false; }
                }
                else
                {
                    if ((char.IsLetter(e.KeyChar) || e.KeyChar == (char)Keys.Back))
                    {
                        e.Handled = false;
                    }
                    else { e.Handled = true; }
                }
        }

        private void RBAdmin_CheckedChanged(object sender, EventArgs e)
        {
            txtb_login.ForeColor = Color.LightGray;
            txtb_Pass.ForeColor = Color.LightGray;
            if (RBGuest.Checked == true)
            { 
                this.Hide(); FormCS.Show(); 
                ClassStatic.Welcome = "Welcome, Guest"; 
            }
            else if (RBAdmin.Checked == true)
            {
                txtb_login.Text = "Enter name";
            }
            else
                txtb_login.Text = "Enter id number";
            txtb_Pass.PasswordChar = '\0';
            txtb_Pass.Text = "Password";
        }

        private void txtb_Pass_Click(object sender, EventArgs e)
        {
            if (txtb_Pass.Text == "Password")
            {
                txtb_Pass.Text = "";
                txtb_Pass.ForeColor = Color.White;
                txtb_Pass.PasswordChar = '*';
            }
        }

        private void txtb_login_Click(object sender, EventArgs e)
        {
            if (txtb_login.Text == "Enter name" || txtb_login.Text == "Enter id number")
            {
                txtb_login.Text = "";
                txtb_login.ForeColor = Color.White;
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            ClassStatic.RemoveUnusedFiles();
            Application.Exit();
        }


        
    }
}
