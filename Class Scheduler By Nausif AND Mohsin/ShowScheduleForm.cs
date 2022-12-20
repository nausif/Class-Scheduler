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
    public partial class ShowScheduleForm : Form
    {
        public ShowScheduleForm()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Class_Schedule cs = new Class_Schedule();
            cs.Show();
            this.Hide();
        }
        public static ShowScheduleForm ShowSF = new ShowScheduleForm();
        private void ShowScheduleForm_Load(object sender, EventArgs e)
        {
            ShowSF = this;
        }
    }
}
