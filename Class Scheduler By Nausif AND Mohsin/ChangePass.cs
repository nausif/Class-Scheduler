using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Drawing;

namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    class ChangePass
    {
        public static int loginIndex { get; set; }
        public static string Selection { get; set; }
        List<string> list { get; set; }
        public void Changepass(string txt1,string txt2)
        {
            list = File.ReadAllLines(Selection).ToList();
            if (list[loginIndex] == txt1)
            {
                if (txt2.Length >= 8)
                {
                    list.RemoveAt(loginIndex);
                    list.Insert(loginIndex, txt2);
                    File.WriteAllLines(Selection, list.ToArray());
                    MessageBox.Show("Password changed Successfully");
                }
                else MessageBox.Show("New Password Must have 8 or More than 8 Characters");
            }
            else
            {
                MessageBox.Show("Wrong Pass");
            }
        }
    }
}
