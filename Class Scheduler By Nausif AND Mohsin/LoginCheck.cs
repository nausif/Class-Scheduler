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
    class LoginCheck
    {
        string[] adminLogin = File.ReadAllLines("Admin.txt");
        string[] studentLogin = File.ReadAllLines(ClassStatic.EnumSelectTSC.Student + ".txt");
        string[] teacherLogin = File.ReadAllLines(ClassStatic.EnumSelectTSC.Teacher + ".txt");
        public bool CheckLogin(TextBox txtb_login, TextBox txtb_Pass,RadioButton RBAdmin)
        {
            if (RBAdmin.Checked == true)
            {
                for (int i = 0; i < adminLogin.Length; i += 2)
                {
                    if (txtb_login.Text == adminLogin[i] && txtb_Pass.Text == adminLogin[i + 1])
                    {
                        ClassStatic.Welcome = "Welcome, " + adminLogin[i];
                        ChangePass.Selection = "Admin.txt";
                        ChangePass.loginIndex = i + 1;
                        return true;
                    }
                }
            }
            else
            {
                
                for (int i = 1; i < studentLogin.Length; i+=3)
                {
                    if (txtb_login.Text == studentLogin[i] && txtb_Pass.Text == studentLogin[i + 1])
                    {
                        ClassStatic.LoginUserFileName = studentLogin[i - 1] + " " + studentLogin[i];
                        ClassStatic.Welcome = "Welcome, " + studentLogin[i-1];
                        ChangePass.Selection = ClassStatic.EnumSelectTSC.Student.ToString() + ".txt";
                        ChangePass.loginIndex = i + 1;
                        return true;
                    }
                }
                for (int i = 1; i < teacherLogin.Length; i+=4)
                {
                    if (txtb_login.Text == teacherLogin[i] && txtb_Pass.Text == teacherLogin[i + 2])
                    {
                        ClassStatic.LoginUserFileName = teacherLogin[i - 1] + " " + teacherLogin[i];
                        ClassStatic.Welcome = "Welcome, " + teacherLogin[i - 1];
                        ChangePass.Selection = ClassStatic.EnumSelectTSC.Teacher.ToString() + ".txt";
                        ChangePass.loginIndex = i + 2;
                        return true;
                    }
                        
                }
            }
            return false;
        }
        public void GUIset(TextBox txtb_login, TextBox txtb_Pass, RadioButton RBAdminAdmin)
        {
            txtb_login.ForeColor = Color.LightGray;
            txtb_Pass.ForeColor = Color.LightGray;
            if (RBAdminAdmin.Checked == true)
                txtb_login.Text = "Enter name";
            else txtb_login.Text = "Enter id number";
            txtb_Pass.PasswordChar = '\0';
            txtb_Pass.Text = "Password";
        }
    }
}
