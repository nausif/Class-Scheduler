using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Collections;

namespace Class_Scheduler_By_Nausif_AND_Mohsin
{
    class ClassAddSTC
    {
        public int GenerateID(ClassStatic.EnumSelectTSC Sel)
        {
            int id,c = 3,m =2;
            if (ClassStatic.EnumSelectTSC.Student == Sel)
                id = 1000;
            else if (ClassStatic.EnumSelectTSC.CourseAdded == Sel)
                id = 50000;
            else
            {
                id = 10000; c = 4; m = 3;
            }
            string[] arr = File.ReadAllLines(Sel + ".txt");
            for (int i = 1; i < arr.Length; i += c)
            {
                if (arr.Length - m == i)
                {
                    id = int.Parse(arr[i]); id++;
                    break;
                }
            }
            return id;
        }
        public void AddST(string txtName,ClassStatic.EnumSelectTSC sel,string RBtext)
        {
            int newid = GenerateID(sel);
            StreamWriter sw = new StreamWriter(sel + ".txt", true);
                sw.WriteLine(txtName);
                sw.WriteLine(newid);
                if (ClassStatic.EnumSelectTSC.Teacher == sel)
                {
                    sw.WriteLine(RBtext);
                }
                sw.WriteLine(GeneratePassword());
            sw.Close();
            MessageBox.Show("Successfully Added");
        }
        public void CourseAdded(string str1, string str2)
        {
            ClassStatic.EnumSelectTSC sel = ClassStatic.EnumSelectTSC.CourseAdded;
                int newid = GenerateID(sel);
                StreamWriter sw = new StreamWriter(sel + ".txt", true);
                StreamWriter swCourse = new StreamWriter(str1 + " " + newid + ".txt", true);
                StreamWriter swTeacher = new StreamWriter(str2 + ".txt", true);
                sw.WriteLine(str1);
                sw.WriteLine(newid);
                sw.WriteLine(str2);
                swCourse.WriteLine(str1);
                swCourse.WriteLine(newid);
                swCourse.WriteLine(str2);
                swTeacher.WriteLine(str1);
                swTeacher.WriteLine(newid);
                swTeacher.Close();
                swCourse.Close();
                sw.Close();
                
                MessageBox.Show("Successfully Added");
            
        }
        public bool CheckStuinCourse(string CourseName,string StrStu)
        {
            List<string> l;
            if (File.Exists(StrStu + ".txt"))
            {
                l = File.ReadAllLines(StrStu + ".txt").ToList();
                for (int i = 0; i < l.Count; i+=2)
                {
                    if (l[i] == CourseName)
                        return false;
                }
            }
            return true;
        }
        private bool checkstuClash(string StrCour,string StrStu)
        {
            if(File.Exists(StrStu + ".txt"))
            {
                string[] strStu = File.ReadAllLines(StrStu + ".txt");
                string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt"); // herrrrr
                
                for (int i = 0; i < strStu.Length; i+=2)
                {
                    for (int j = 1; j < arr.Length; j+=4)
                    {
                        if (strStu[i]+ " " + strStu[i+1] == arr[j])
                        {
                            string day = arr[j + 1];
                            string time = arr[j + 2];
                            for (int k = 1; k < arr.Length; k+=4)
                            {
                                if (strStu[i] + " " + strStu[i + 1] != arr[k])
                                {
                                    if (StrCour == arr[k])
                                    {
                                        if (day == arr[k + 1] && time == arr[k + 2])
                                        {
                                            return true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }
        public void RegofStudentinCourse(string strCour,string StrStu)
        {
            string[] course = File.ReadAllLines(strCour + ".txt");
            int count = 0;
            if (File.Exists(StrStu + ".txt"))
            {
                string[] stu = File.ReadAllLines(StrStu + ".txt");
                for (int i = 0; i < stu.Length; i+=2)
                {
                    count++;
                }
            }
            if (count < 5)
            {
                if (CheckStuinCourse(course[0], StrStu))
                {
                    if(checkstuClash(strCour,StrStu))
                    {
                        MessageBox.Show("Student Clash");
                    }
                    else
                    {
                    if (course.Length < 23)
                    {
                        StreamWriter swCourse = new StreamWriter(strCour + ".txt", true);
                        StreamWriter swStudent = new StreamWriter(StrStu + ".txt", true);
                        swCourse.WriteLine(StrStu);
                        swStudent.WriteLine(course[0]);
                        swStudent.WriteLine(course[1]);
                        swStudent.Close();
                        swCourse.Close();
                        MessageBox.Show("Successfully Added");
                    }
                    else MessageBox.Show("ID is Full");
                    }
                }
                else MessageBox.Show("Student is Already Registered");
            }
            else MessageBox.Show("Student Not Allowed to Registered more than 5 course");
            
        }
        public void AllCourseAdd(string txtName)
        {
            string[] arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.Course + ".txt");
            bool chk = true;
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] == txtName)
                { chk = false; break; }
            }
            if (chk)
            {
                StreamWriter sw = new StreamWriter(ClassStatic.EnumSelectTSC.Course + ".txt", true);
                sw.WriteLine(txtName);
                sw.Close();
                MessageBox.Show("Successfully Added");
            }
            else MessageBox.Show("Course is Already Added");
        }


        public void AddItemAddedCoursesChange(ComboBox CB)
        {
            CB.Items.Clear();
            string[] arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt");
            for (int i = 0; i < arr.Length; i+=3)
            {
                CB.Items.Add(arr[i] + " " + arr[i + 1]);
            }
        }
        public void SelectedCourseTeacherName(TextBox TB,ComboBox CB)
        {
            string[] arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt");
            for (int i = 0; i < arr.Length; i+=3)
            {
                if (CB.Text == arr[i] + " " + arr[i + 1])
                {
                    TB.Text = arr[i + 2];
                    break;
                }
            }
        }

        public void AdditemsinChangeTecher(ComboBox CB,TextBox TB)
        {
            CB.Items.Clear();
            string[] arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.Teacher + ".txt");
            for (int i = 0; i < arr.Length; i+=4)
            {
                if (TB.Text != arr[i] + " " + arr[i+1])
                {
                    CB.Items.Add(arr[i] + " " + arr[i + 1]);
                }
            }
        }

        public void DeleteStuFromCourse(ComboBox CBCour,ComboBox CBstu)
        {
            List<string> array = File.ReadAllLines(CBCour.Text + ".txt").ToList();
            for (int i = 3; i < array.Count; i++)
            {
                if (array[i] == CBstu.Text)
                {
                    array.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(CBCour.Text + ".txt",array.ToArray());

            List<string> array2 = File.ReadAllLines(CBstu.Text + ".txt").ToList();
            for (int i = 0; i < array2.Count; i+=2)
            {
                if (array2[i] + " " + array2[i+1] == CBCour.Text)
                {
                    array2.RemoveAt(i);
                    array2.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(CBstu.Text + ".txt", array2.ToArray());
            MessageBox.Show("Student Delete From Course Successfully");
        }


        public void RemoveCourse(ComboBox CB, TextBox TB)
        {
            // Remove course & teacher from CourseAdded File
            // Remove Course File
            // Remove Course from Teacher file
            // Remove Course from Student file.
            // Remove From ScheduleCourses File
            List<string> courseschedule = File.ReadAllLines(@"Schedule\CourseSchedule.txt").ToList();
            for (int i = 1; i < courseschedule.Count; i+=4)
            {
                if (CB.Text == courseschedule[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        courseschedule.RemoveAt(i);
                    }
                    break;
                }
            }
            File.WriteAllLines(@"Schedule\CourseSchedule.txt", courseschedule.ToArray());

            string[] removecourfrmStu = File.ReadAllLines(CB.Text+".txt");
            for (int i = 3; i < removecourfrmStu.Length; i++)
            {
                List<string> stu = File.ReadAllLines(removecourfrmStu[i] + ".txt").ToList();
                for (int j = 0; j < stu.Count; j+=2)
                {
                    if(stu[j] + " " +stu[j+1] == CB.Text)
                    {
                        stu.RemoveAt(j);
                        stu.RemoveAt(j);
                        break;
                    }
                }
                File.WriteAllLines(removecourfrmStu[i] + ".txt", stu.ToArray());
            }

            int index = 0;
            List<string> arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt").ToList();
            for (int i = 0; i < arr.Count; i+=3)
            {
                if (CB.Text == arr[i] + " " + arr[i + 1])
                {
                    index = i;
                    break;
                }
            }
            for (int i = 0; i < 3; i++)
            {
                arr.RemoveAt(index);
            }
            File.WriteAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt", arr.ToArray());
            List<string> arr2 = File.ReadAllLines(TB.Text + ".txt").ToList();
            for (int i = 0; i < arr2.Count; i += 2)
            {
                if (CB.Text == arr2[i] + " " + arr2[i + 1])
                {
                    arr2.RemoveAt(i);
                    arr2.RemoveAt(i);
                    break;
                }
            }
            File.WriteAllLines(TB.Text + ".txt", arr2.ToArray());
            File.Delete(CB.Text + ".txt");
            AddItemAddedCoursesChange(CB);
            TB.Text = "";
            MessageBox.Show("Course Deleted Successfully");
        }

        public void ChangeTeacher(ComboBox CBCourName,TextBox TB,ComboBox CBNewTeac)
        {
            if (chkanyclashofteacher(CBNewTeac.Text.ToUpper(), CBCourName.Text.ToUpper()))
            {
                int index = 0;
                List<string> arr1 = File.ReadAllLines(CBCourName.Text + ".txt").ToList();
                for (int i = 0; i < arr1.Count; i += 3)
                {
                    if (CBCourName.Text == arr1[i] + " " + arr1[i + 1])
                    {
                        arr1.RemoveAt(i + 2);
                        arr1.Insert(i + 2, CBNewTeac.Text);
                        break;
                    }
                }
                File.WriteAllLines(CBCourName.Text + ".txt", arr1.ToArray());
                List<string> arr2 = File.ReadAllLines(TB.Text + ".txt").ToList();
                for (int i = 0; i < arr2.Count; i += 2)
                {
                    if (CBCourName.Text == arr2[i] + " " + arr2[i + 1])
                    {
                        arr2.RemoveAt(i);
                        arr2.RemoveAt(i);
                        break;
                    }
                }
                File.WriteAllLines(TB.Text + ".txt", arr2.ToArray());

                List<string> arr = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt").ToList();
                for (int i = 0; i < arr.Count; i++)
                {
                    if (CBCourName.Text == arr[i] + " " + arr[i + 1])
                    {
                        StreamWriter sw = new StreamWriter(CBNewTeac.Text + ".txt", true);
                        sw.WriteLine(arr[i]);
                        sw.WriteLine(arr[i + 1]);
                        sw.Close();
                        index = i + 2;
                        break;
                    }
                }
                arr.RemoveAt(index);
                arr.Insert(index, CBNewTeac.Text);
                File.WriteAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt", arr.ToArray());
                AddItemAddedCoursesChange(CBCourName);
                TB.Text = "";
                MessageBox.Show("Changed Successfully");
            }
            else MessageBox.Show("The New Teacher Have clash with same day and session");
        }
        private bool chkanyclashofteacher(string teacher,string courname)
        {
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 1; i < arr.Length; i+=4)
            {
                if (courname == arr[i])
                {
                    string day = arr[i + 1];
                    string time = arr[i + 2];
                    for (int j = 2; j < arr.Length; j+=4)
                    {
                        if (arr[j - 1] != courname)
                        {
                            if (arr[j] == day && arr[j + 1] == time)
                            {
                                string oldteach = File.ReadLines(arr[j-1] + ".txt").Skip(2).Take(1).First();
                                if (oldteach == teacher)
                                    return false;
                            }
                        }
                    }

                }
            }
            return true;
        }


        private string GeneratePassword()
        {
            Random r = new Random();
            string Numeric = "0123456789";
            string UpperAlpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            string LowerAlpha = UpperAlpha.ToLower();
            string pass = "";
            for (int i = 0; i < 8; i++)
            {
                int output = r.Next(0, 3);
                if (output == 0)
                    pass += Numeric[r.Next(Numeric.Length)];
                else if (output == 1)
                    pass += UpperAlpha[r.Next(UpperAlpha.Length)];
                else
                    pass += LowerAlpha[r.Next(LowerAlpha.Length)];
            }
            return pass;
        }
    }
    
}
