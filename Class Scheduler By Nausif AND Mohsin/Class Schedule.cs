using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    public partial class Class_Schedule : Form
    {
        public Class_Schedule()
        {
            InitializeComponent();
        }
        Schedule Sch = new Schedule();
        private void Class_Schedule_Load(object sender, EventArgs e)
        {
            LblWelcome.Text = ClassStatic.Welcome;
            if (Form1.F1obj.RBAdmin.Checked == true)
            {
                tabControl1.Enabled = true;
                BtnSetting.Enabled = true;
            }
            else if (Form1.F1obj.RBuser.Checked == true)
            {
                tabControl1.Enabled = false;
                BtnSetting.Enabled = true;
            }
            else
            {
                tabControl1.Enabled = false;
                BtnSetting.Enabled = false;
            }
            timer1.Start();
        }
       
        
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString();
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            ClassStatic.RemoveUnusedFiles();
            Application.Exit();
        }

        private void btnSignout_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 f1 = new Form1();
            f1.Show();
        }
        ControlsForm CF = new ControlsForm();
        private void RBAddSTC_CheckedChanged(object sender, EventArgs e)
        {
            RBREGStu.Checked = false;
            RBdeleteStufrmCour.Checked = false;
            RBChangeTeac.Checked = false;
            RBAssignCou.Checked = false;
            RBRemoveCour.Checked = false;
            txtteachisPerorVis.Visible = false;
            LBLstatusoftech.Visible = false;

            GBACRCour.Visible = false;
            GBARSTC.Visible = true;
            GBStudentReg.Visible = false;
            ClassStatic.AddItemsinCBSelect(CBSelection);
            GBARSTC.Visible = true;
            if (RBAddSTC.Checked == true)
            {
                TxtSTName.Visible = true;
                CBSTC.Visible = false;
                BtnAddStudorTeac.Text = "ADD";
                label1.Location = new Point(158, 162);
                label1.Text = "ENTER FULL NAME";
                VisiblePage1();
            }
            else if (RBRemoveSTC.Checked == true)
            {
                TxtSTName.Visible = false;
                CBSTC.Visible = true;
                label1.Location = new Point(113, 162);
                label1.Text = "SELECT ANY ONE TO REMOVE";
                BtnAddStudorTeac.Text = "REMOVE";
                VisiblePage1();
                RBPerFacu.Visible = false;
                RBVisFac.Visible = false;

            }
        }
        public void VisiblePage1()
        {
            CBSelection.Visible = true;
            label1.Visible = true;
            label4.Visible = true;
            BtnAddStudorTeac.Visible = true;
        }

        private void CBSelection_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RBAddSTC.Checked == true)
            {
                if (CBSelection.Text == ClassStatic.EnumSelectTSC.Teacher.ToString())
                {
                    RBPerFacu.Visible = true;
                    RBVisFac.Visible = true;
                }
                else
                {
                    RBPerFacu.Visible = false;
                    RBVisFac.Visible = false;
                }
            }
            else if (RBChangePerOrVis.Checked == true)
            {
                ClassStatic.SelectedTeacherPerVis(CBSelection, txtteachisPerorVis);
                if (txtteachisPerorVis.Text == "PERMANENT FACULTY")
                {
                    BtnAddStudorTeac.Text = "CHANGE TO VISITING FACULTY";
                }
                else
                {
                    BtnAddStudorTeac.Text = "CHANGE TO PERMANENT FACULTY";
                }
            }
            else
                ClassStatic.AdditemCBRemoveSTC(CBSelection.Text, CBSTC);
        }
        ClassAddSTC AddSTC = new ClassAddSTC();
        private void BtnAddStudorTeac_Click(object sender, EventArgs e)
        {
            string a = RBPerFacu.Text.ToUpper();
            if (RBVisFac.Checked == true)
                a = RBVisFac.Text.ToUpper();
            if (RBAddSTC.Checked == true)
            {
                if (String.IsNullOrWhiteSpace(TxtSTName.Text) || CBSelection.Text == "")
                {
                    MessageBox.Show("Please Enter Input");
                }
                else
                {
                    if (CBSelection.Text.Equals(ClassStatic.EnumSelectTSC.Student.ToString()))
                    {
                        AddSTC.AddST(TxtSTName.Text.ToUpper(), ClassStatic.EnumSelectTSC.Student,a);
                    }
                    else if (CBSelection.Text.Equals(ClassStatic.EnumSelectTSC.Teacher.ToString()))
                    {
                        AddSTC.AddST(TxtSTName.Text.ToUpper(), ClassStatic.EnumSelectTSC.Teacher,a);
                    }
                    else
                    {
                        AddSTC.AllCourseAdd(TxtSTName.Text.ToUpper());
                    }
                    TxtSTName.Text = "";
                }
            }
            else if (RBChangePerOrVis.Checked == true)
            {
                if (CBSelection.Text == "")
                {
                    MessageBox.Show("Please Enter Input");
                }
                else
                {
                    ClassStatic.ChangeTeacherPerVis(txtteachisPerorVis, CBSelection);
                    
                }
            }
            else
            {
                if (CBSTC.Text == "" || CBSelection.Text == "")
                {
                    MessageBox.Show("Please Enter Input");
                }
                else
                {
                    ClassStatic.RemoveSTC(CBSelection.Text, CBSTC);
                    ClassStatic.AdditemCBRemoveSTC(CBSelection.Text, CBSTC);
                }
            }


        }

        public void VisibleGB()
        {
            RBAddSTC.Checked = false;
            RBRemoveSTC.Checked = false;
            RBREGStu.Checked = false;
            RBdeleteStufrmCour.Checked = false;

            GBACRCour.Visible = true;
            GBARSTC.Visible = false;
            GBStudentReg.Visible = false;
        }
        private void RBAssignCou_CheckedChanged(object sender, EventArgs e)
        {
            VisibleGB();
            ClassStatic.AdditemsinCBCour(CBCourseName, CBSelectTeacher);
            CBCourseName.Visible = true;
            label7.Visible = true;
            BtnCourseReg.Visible = true;
            txtCurrentteacher.Visible = false;
            label9.Visible = false;
            label8.Visible = true;
            label8.Location = new Point(165, 133);
            CBSelectTeacher.Location = new Point(82, 160);
            BtnCourseReg.Location = new Point(150, 216);
            CBSelectTeacher.Visible = true;
            BtnCourseReg.Text = "ASSIGN";
        }

        private void RBChangeTeac_CheckedChanged(object sender, EventArgs e)
        {
            VisibleGB();
            txtCurrentteacher.Text = "";
            AddSTC.AddItemAddedCoursesChange(CBCourseName);
            CBCourseName.Visible = true;
            label7.Visible = true;
            BtnCourseReg.Visible = true;
            txtCurrentteacher.Visible = true;
            label9.Visible = true;
            label8.Visible = true;
            label8.Location = new Point(163, 171);
            CBSelectTeacher.Location = new Point(82, 196);
            BtnCourseReg.Location = new Point(148, 254);
            CBSelectTeacher.Visible = true;
            BtnCourseReg.Text = "CHANGE TEACHER";
            
        }

        private void RBRemoveCour_CheckedChanged(object sender, EventArgs e)
        {
            VisibleGB();
            txtCurrentteacher.Text = "";
            AddSTC.AddItemAddedCoursesChange(CBCourseName);
            CBCourseName.Visible = true;
            label7.Visible = true;
            BtnCourseReg.Visible = true;
            txtCurrentteacher.Visible = true;
            label9.Visible = true;
            label8.Visible = false;
            CBSelectTeacher.Visible = false;
            BtnCourseReg.Text = "REMOVE";
            BtnCourseReg.Location = new Point(139, 196);
        }

        private void BtnCourseReg_Click(object sender, EventArgs e)
        {
            if (CBCourseName.Text == "" )
            {
                MessageBox.Show("Please Enter Input");
            }
            else
            {
                if (RBRemoveCour.Checked == true)
                {
                    AddSTC.RemoveCourse(CBCourseName, txtCurrentteacher);
                }
                else
                {
                    if (CBSelectTeacher.Text == "")
                    {
                        MessageBox.Show("Please Enter Input");
                    }
                    else
                    {
                        if (RBAssignCou.Checked == true)
                        {
                            AddSTC.CourseAdded(CBCourseName.Text.ToUpper(), CBSelectTeacher.Text.ToUpper());
                        }
                        else if (RBChangeTeac.Checked == true)
                        {
                            AddSTC.ChangeTeacher(CBCourseName, txtCurrentteacher, CBSelectTeacher);
                            AddSTC.AdditemsinChangeTecher(CBSelectTeacher, txtCurrentteacher);
                        }
                    }
                }
            }
            
        }

        private void CBCourseName_SelectedIndexChanged(object sender, EventArgs e)
        {
            AddSTC.SelectedCourseTeacherName(txtCurrentteacher, CBCourseName);
            AddSTC.AdditemsinChangeTecher(CBSelectTeacher, txtCurrentteacher);

        }

        private void RBdeleteStufrmCour_CheckedChanged(object sender, EventArgs e)
        {
            RBChangeTeac.Checked = false;
            RBAssignCou.Checked = false;
            RBRemoveCour.Checked = false;
            RBAddSTC.Checked = false;
            RBRemoveSTC.Checked = false;

            GBACRCour.Visible = false;
            GBARSTC.Visible = false;
            GBStudentReg.Visible = true;
            txtRegCurrTeach.Text = "";
            if (RBREGStu.Checked == true)
            {
                ClassStatic.AdditemsinCBRegofstu(CBRegEnterCourse, CBEnterStutoRegister,true);
                BtnRegofStuInCour.Text = "REGISTER";
            }
            else
            {
                ClassStatic.AdditemsinCBRegofstu(CBRegEnterCourse, CBEnterStutoRegister, false);
                BtnRegofStuInCour.Text = "REMOVE STUDENT";
            }
        }

        private void btnRegofStuInCour_Click(object sender, EventArgs e)
        {
            if (CBRegEnterCourse.Text == "" || CBEnterStutoRegister.Text == "")
            {
                MessageBox.Show("Please Enter Input");
            }
            else
            {
                if (RBREGStu.Checked == true)
                {
                    AddSTC.RegofStudentinCourse(CBRegEnterCourse.Text,CBEnterStutoRegister.Text);
                    ClassStatic.AdditemsinCBRegofstu(CBRegEnterCourse, CBEnterStutoRegister, true);
                    txtRegCurrTeach.Text = "";
                }
                else
                {
                    AddSTC.DeleteStuFromCourse(CBRegEnterCourse, CBEnterStutoRegister);
                    ClassStatic.AdditemsinCBRegofstu(CBRegEnterCourse, CBEnterStutoRegister, false);
                    txtRegCurrTeach.Text = "";
                }
            }
        }

        private void CBRegEnterCourse_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassStatic.SeleteditemsinCBRoS(txtRegCurrTeach, CBRegEnterCourse.Text);
            if (RBdeleteStufrmCour.Checked == true)
            {
                ClassStatic.SelectedCoursestudele(CBRegEnterCourse, CBEnterStutoRegister);
            }
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {
           
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            RBREGStu.Checked = false;
            RBdeleteStufrmCour.Checked = false;
            RBChangeTeac.Checked = false;
            RBAssignCou.Checked = false;
            RBRemoveCour.Checked = false;
            RBAddSTC.Checked = false;
            RBRemoveSTC.Checked = false;
            GBACRCour.Visible = false;
            GBARSTC.Visible = false;
            GBStudentReg.Visible = false;
            RBAddDateTime.Checked = false;
            RBUpdateRooms.Checked = false;
            RBRemoveDayTime.Checked = false;
            RBmanual.Checked = false;
            RBautomatic.Checked = false;
            RBremoveSchedule.Checked = false;
            RBCRautoRA.Checked = false;
            RBCRautoSINGLE.Checked = false;
            GBAddDayTime.Visible = false;
            GBupdateRooms.Visible = false;
            GBCRautoSchedule.Visible = false;
            GBCRremove.Visible = false;
            GBCourseSchedule.Visible = false;
            label36.Visible = false;
            BtnAutoSchedule.Visible = false;
            CBCRautoCourName.Visible = false;
        }

        private void RBChangePerOrVis_CheckedChanged(object sender, EventArgs e)
        {
            GBARSTC.Visible = true;
            CBSelection.Visible = true;
            label4.Visible = true;
            BtnAddStudorTeac.Visible = true;
            txtteachisPerorVis.Visible = true;
            txtteachisPerorVis.Text = "";
            LBLstatusoftech.Visible = true;
            RBVisFac.Visible = false;
            RBPerFacu.Visible = false;
            CBSTC.Visible = false;
            label1.Visible = false;
            TxtSTName.Visible = false;
            BtnAddStudorTeac.Text = "CHANGE";
            ClassStatic.AdditemCBRemoveSTC(ClassStatic.EnumSelectTSC.Teacher.ToString(), CBSelection);
            

        }
        AdddaytimeofSchedule daytime = new AdddaytimeofSchedule();
        private void RBAddDateTime_CheckedChanged(object sender, EventArgs e)
        {
            GBupdateRooms.Visible = false;
            GBAddDayTime.Visible = true;
            txtSessionTime.Text = "";
            btnAddDayTime.Text = "ADD";
            daytime.AdditeminCB(CBSelectDay, CBSelectSession);
        }

        private void CBSelectSession_SelectedIndexChanged(object sender, EventArgs e)
        {
            daytime.SelectedSessionTime(CBSelectSession.Text.ToUpper(), txtSessionTime);
        }

        private void btnAddDayTime_Click(object sender, EventArgs e)
        {
            if (CBSelectSession.Text == "" || CBSelectDay.Text == "")
            {
                MessageBox.Show("Please Enter Input");
            }
            else
            {
                if (RBAddDateTime.Checked == true)
                {
                    daytime.AddDayTime(CBSelectDay.Text.ToUpper(), CBSelectSession.Text.ToUpper(), txtSessionTime.Text.ToUpper());
                }
                else if (RBRemoveDayTime.Checked == true)
                {
                    daytime.RemoveDayTime(CBSelectDay.Text.ToUpper(), CBSelectSession.Text.ToUpper(), txtSessionTime.Text.ToUpper());
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            GBupdateRooms.Visible = false;
            GBAddDayTime.Visible = true;
            txtSessionTime.Text = "";
            btnAddDayTime.Text = "REMOVE";
            daytime.AdditeminCB(CBSelectDay, CBSelectSession);
        }

        private void RBUpdateRooms_CheckedChanged(object sender, EventArgs e)
        {
            PBexclaim1.Visible = false;
            GBupdateRooms.Visible = true;
            GBAddDayTime.Visible = false;
           
        }

        private void btnupdaterooms_Click(object sender, EventArgs e)
        {
            DialogResult result1 = MessageBox.Show("Are You Sure You Want to Create " + numericUpDown1.Value + " Rooms","Alert",MessageBoxButtons.YesNo);
            if (result1 == DialogResult.Yes)
            {
                daytime.UpdateRooms((int)numericUpDown1.Value);
                RBAddDateTime.Enabled = true;
                RBRemoveDayTime.Enabled = true;
                PBexclaim1.Visible = false;
            }
            
        }

        private void RBmanual_CheckedChanged(object sender, EventArgs e)
        {
            label36.Visible = false;
            BtnAutoSchedule.Visible = false;
            RBCRautoRA.Checked = false;
            RBCRautoSINGLE.Checked = false;
            CBCRautoCourName.Visible = false;
            GBCourseSchedule.Visible = true;
            GBCRremove.Visible = false;
            GBCRautoSchedule.Visible = false;
            daytime.AddSessionsinCB(CBCRsession);
            daytime.RoomNoAdditeminCB(CBCRroom);
            ClassStatic.AddItemsinCBSchedule(CBCRcoursename);
        }

        private void CBCRsession_SelectedIndexChanged(object sender, EventArgs e)
        {
            daytime.SelectedSessionTime(CBCRsession.Text, txtCRsessiontime);
            daytime.SelectedManualDaysCB(CBCRsession.Text, CBCRSelectDay);
        }

        private void btnCRSchedule_Click(object sender, EventArgs e)
        {
            if (CBCRcoursename.Text == "" || CBCRroom.Text == "" || CBCRSelectDay.Text == "" || CBCRsession.Text == "")
            {
                MessageBox.Show("Please Enter Input for Schedule");
            }
            else
            {
                Sch.ManualScheduleCourse(CBCRcoursename.Text, CBCRSelectDay.Text, txtCRsessiontime.Text, CBCRroom.Text);
                daytime.AddSessionsinCB(CBCRsession);
                daytime.RoomNoAdditeminCB(CBCRroom);
                ClassStatic.AddItemsinCBSchedule(CBCRcoursename);
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Sch.ShowSchedule(ShowScheduleForm.ShowSF.DGVScheduledCourses);
            ShowScheduleForm.ShowSF.Show();
            this.Hide();
        }

        private void RBremoveSchedule_CheckedChanged(object sender, EventArgs e)
        {
            label36.Visible = false;
            BtnAutoSchedule.Visible = false;
            RBCRautoRA.Checked = false;
            RBCRautoSINGLE.Checked = false;
            CBCRautoCourName.Visible = false;
            GBCourseSchedule.Visible = false;
            GBCRremove.Visible = true;
            GBCRautoSchedule.Visible = false;
            txtremday.Text = "";
            txtremroomno.Text = "";
            txtremsesstime.Text = "";
            ClassStatic.AdditeminremCour(CBCRremCourNam);
        }

        private void CBCRremCourNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClassStatic.SelectediteminremCour(CBCRremCourNam.Text, txtremday, txtremroomno, txtremsesstime);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (CBCRremCourNam.Text == "")
                MessageBox.Show("Please Enter Input");
            else
            {
                ClassStatic.RemoveScheduleCourse(CBCRremCourNam.Text);
                ClassStatic.AdditeminremCour(CBCRremCourNam);
                txtremday.Text = "";
                txtremroomno.Text = "";
                txtremsesstime.Text = "";
            }
        }

        private void RBautomatic_CheckedChanged(object sender, EventArgs e)
        {
            GBCourseSchedule.Visible = false;
            GBCRremove.Visible = false;
            GBCRautoSchedule.Visible = true;
            GBCRautoSchedule.Location = new Point(200, 170);
        }

        private void RBCRautoSINGLE_CheckedChanged(object sender, EventArgs e)
        {
            BtnAutoSchedule.Visible = true;
            if (RBCRautoSINGLE.Checked == true)
            {
                label36.Visible = true;
                CBCRautoCourName.Visible = true;
                ClassStatic.AddItemsinCBSchedule(CBCRautoCourName);
                BtnAutoSchedule.Text = "SCHEDULE SINGLE";
                BtnAutoSchedule.Size = new Size(144, 44);
                BtnAutoSchedule.Location = new Point(92, 191);
            }
            else if (RBCRautoRA.Checked == true)
            {
                label36.Visible = false;
                CBCRautoCourName.Visible = false;
                BtnAutoSchedule.Text = "SCHEDULE ALL";
                BtnAutoSchedule.Size = new Size(144, 120);
                BtnAutoSchedule.Location = new Point(87, 123);
            }
        }

        private void BtnAutoSchedule_Click(object sender, EventArgs e)
        {
            if (RBCRautoSINGLE.Checked == true)
            {
                if (CBCRautoCourName.Text == "")
                    MessageBox.Show("Please Enter Course");
                else
                Sch.AutomaticSchedule(CBCRautoCourName);
            }
            else if (RBCRautoRA.Checked == true)
            {
                Sch.RemainingAllCoursesSchedule();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            if (e.TabPage == tabPage5)
            {
                if (new FileInfo(@"Schedule\CourseSchedule.txt").Length == 0)
                {
                    RBAddDateTime.Enabled = false;
                    RBRemoveDayTime.Enabled = false;
                    PBexclaim1.Visible = true;
                }
                else
                {
                    RBAddDateTime.Enabled = true;
                    RBRemoveDayTime.Enabled = true;
                    PBexclaim1.Visible = false;
                }
            }
            else if (e.TabPage == tabPage4)
            {
                bool chk = false;
                for (int i = 1; i <= 4; i++)
                {
                    if (File.Exists(@"Schedule\SESSION " + i + ".txt"))
                    {
                        chk = true; break;
                    }
                }
                if (chk)
                {
                    RBremoveSchedule.Enabled = true;
                    RBmanual.Enabled = true;
                    RBautomatic.Enabled = true;
                    PBexclaim2.Visible = !true;
                       
                }
                else
                {
                    RBremoveSchedule.Enabled = !true;
                    RBmanual.Enabled = !true;
                    RBautomatic.Enabled = !true;
                    PBexclaim2.Visible = true;
                }
            }
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            CF.Show();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            Sch.Showteacher(ShowScheduleForm.ShowSF.DGVScheduledCourses);
            ShowScheduleForm.ShowSF.Show();
            this.Hide();
            
        }



    }
}
