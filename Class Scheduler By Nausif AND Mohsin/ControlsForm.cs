using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    public partial class ControlsForm : Form
    {
        public ControlsForm()
        {
            InitializeComponent();
        }
       
        ClassAddSTC AddSTC = new ClassAddSTC();
       

        private void BtnPassUpdate_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(TxtCurrPass.Text) || String.IsNullOrWhiteSpace(TxtNewPass.Text))
                MessageBox.Show("Enter Input");
            else
            {
                ChangePass cp = new ChangePass();
                cp.Changepass(TxtCurrPass.Text, TxtNewPass.Text);
            }
            TxtCurrPass.Text = ""; TxtNewPass.Text = "";
        }


        private void BtnControlExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ControlsForm_Load(object sender, EventArgs e)
        {
            this.Size = new Size(262, 280);
        }

    }
}
