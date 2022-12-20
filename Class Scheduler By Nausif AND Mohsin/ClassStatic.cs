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
    static class ClassStatic
    {
        private static string[] arrCBSchedule { get; set; }
        public static string LoginUserFileName { get; set; }
        public static string Welcome { get; set; }
        public static void AddItemsinCBSchedule(ComboBox CBSchedule)
        {
            CBSchedule.Items.Clear();
            arrCBSchedule = File.ReadAllLines(EnumSelectTSC.CourseAdded + ".txt");
            String[] read = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 0; i < arrCBSchedule.Length; i += 3)
            {
                bool flag = true;
                for (int j = 1; j < read.Length; j+=4)
                {
                    if (read[j] == arrCBSchedule[i] + " " + arrCBSchedule[i + 1])
                    {
                        flag = false;
                        break;
                    }
                }
                if(flag) CBSchedule.Items.Add(arrCBSchedule[i] + " " + arrCBSchedule[i + 1]);
            }
        }
        public static void SelecteditemIDnTeac(TextBox ID, TextBox Teacher,String CBtext)
        {
            for (int i = 1; i < arrCBSchedule.Length; i+=3)
            {
                if (CBtext == arrCBSchedule[i])
                {
                    ID.Text = arrCBSchedule[i - 1];
                    Teacher.Text = arrCBSchedule[i + 1];
                    break;
                }
            }
        }


        public static void AdditemsinCBCour(ComboBox CBCourseName, ComboBox CBSelectTeacher)
        {
            CBCourseName.Items.Clear();
            CBSelectTeacher.Items.Clear();
            string[] arr2 = File.ReadAllLines(EnumSelectTSC.Teacher + ".txt");
            for (int i = 0; i < arr2.Length; i += 4)
            {
                CBSelectTeacher.Items.Add(arr2[i] + " " + arr2[i + 1]);
            }
            string[] arr1 = File.ReadAllLines(EnumSelectTSC.Course + ".txt");
            for (int i = 0; i < arr1.Length; i++)
            {
                CBCourseName.Items.Add(arr1[i]);
            }
        }

        static string[] arr1 { get; set; }
        public static void AdditemsinCBRegofstu(ComboBox CBRegEnterCourse, ComboBox CBRegStuName,bool b)
        {
            CBRegEnterCourse.Items.Clear();
            CBRegStuName.Items.Clear();
            arr1 = File.ReadAllLines(EnumSelectTSC.CourseAdded + ".txt");
            for (int i = 0; i < arr1.Length; i += 3)
            {
               CBRegEnterCourse.Items.Add(arr1[i] + " "+ arr1[i+1]);
            }
            if (b)
            {
                string[] arr2 = File.ReadAllLines(EnumSelectTSC.Student + ".txt");
                for (int i = 0; i < arr2.Length; i += 3)
                {
                    CBRegStuName.Items.Add(arr2[i] + " " + arr2[i + 1]);
                }
            }
        }

        public static void SeleteditemsinCBRoS(TextBox TeachName, string CBtext)
        {
            for (int i = 0; i < arr1.Length; i += 3)
            {
                if (CBtext == arr1[i]+ " " + arr1[i+1])
                {
                    TeachName.Text = arr1[i + 2];
                    break;
                }
            }
        }
        public static void SelectedCoursestudele(ComboBox CBEnterCour,ComboBox CBEnterStu)
        {
            CBEnterStu.Items.Clear();
            string[] Array = File.ReadAllLines(CBEnterCour.Text + ".txt");
            for (int i = 3; i < Array.Length; i++)
            {
                CBEnterStu.Items.Add(Array[i]);
            }
        }

        public static void FileExists()
        {
            if (!File.Exists(@"Admin.txt"))
            {
                StreamWriter sw = new StreamWriter(@"Admin.txt", true);
                sw.WriteLine("admin");
                sw.WriteLine("admin");
                sw.Close();
            }
            if (!File.Exists(ClassStatic.EnumSelectTSC.Student + ".txt"))
                File.Create(ClassStatic.EnumSelectTSC.Student + ".txt").Dispose();
            if (!File.Exists(ClassStatic.EnumSelectTSC.Teacher + ".txt"))
                File.Create(ClassStatic.EnumSelectTSC.Teacher + ".txt").Dispose();
            if (!File.Exists(ClassStatic.EnumSelectTSC.CourseAdded + ".txt"))
                File.Create(ClassStatic.EnumSelectTSC.CourseAdded + ".txt").Dispose();
            if (!File.Exists(ClassStatic.EnumSelectTSC.Course + ".txt"))
                File.Create(ClassStatic.EnumSelectTSC.Course + ".txt").Dispose();
            if (!File.Exists(ClassStatic.EnumSelectTSC.CourseAdded + ".txt"))
                File.Create(ClassStatic.EnumSelectTSC.CourseAdded + ".txt").Dispose();
            if (!Directory.Exists("Schedule"))
                Directory.CreateDirectory("Schedule");
            if (!File.Exists(@"Schedule\CourseSchedule.txt"))
                File.Create(@"Schedule\CourseSchedule.txt").Dispose();
        }

        public static void AddItemsinCBSelect(ComboBox CBSelection)
        {
            CBSelection.Items.Clear();
            CBSelection.Items.Add(EnumSelectTSC.Teacher);
            CBSelection.Items.Add(EnumSelectTSC.Student);
            CBSelection.Items.Add(EnumSelectTSC.Course);
        }

        public static void RemoveSTC(string sel,ComboBox CB)
        {
            List<string> arr = File.ReadAllLines(sel + ".txt").ToList();
            int a = arr.Count;
            if (sel == ClassStatic.EnumSelectTSC.Student.ToString())
            {
                for (int i = 0; i < a; i+=3)
                {
                    if (CB.Text == arr[i] + " " + arr[i + 1])
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            arr.RemoveAt(i);
                        }
                        break;
                    }
                }
                File.WriteAllLines(sel + ".txt", arr.ToList());

                if (File.Exists(CB.Text + ".txt"))
                {
                    string[] array = File.ReadAllLines(CB.Text + ".txt");
                    for (int i = 0; i < array.Length; i += 2)
                    {
                        List<string> cou = File.ReadAllLines(array[i] + " " + array[i + 1] + ".txt").ToList();
                        for (int j = 3; j < cou.Count; j++)
                        {
                            if (cou[j] == CB.Text)
                            {
                                cou.RemoveAt(j);
                                break;
                            }
                        }
                        File.WriteAllLines(array[i] + " " + array[i + 1] + ".txt", cou.ToArray());
                    }
                }
                File.Delete(CB.Text + ".txt");
                MessageBox.Show("Remove Successfully");
            }
            else if (sel == ClassStatic.EnumSelectTSC.Teacher.ToString())
            {
                if (chkcourseisaddedornot(CB, true))
                {
                    for (int i = 0; i < a; i += 4)
                    {
                        if (CB.Text == arr[i] + " " + arr[i + 1])
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                arr.RemoveAt(i);
                            }
                            break;
                        }
                    }
                    File.WriteAllLines(sel + ".txt", arr.ToList());
                    MessageBox.Show("Remove Successfully");
                }
                else MessageBox.Show("Teacher has Course, first remove course or change teacher of course then you will access it");
            }
            else
            {
                if (chkcourseisaddedornot(CB,false))
                {
                    for (int i = 0; i < a; i++)
                    {
                        if (CB.Text == arr[i])
                        {
                            arr.RemoveAt(i);
                            
                            break;
                        }
                    }
                    File.WriteAllLines(sel + ".txt", arr.ToList());
                    MessageBox.Show("Remove Successfully");
                }
                else
                    MessageBox.Show("this course is added, first remove all then you will access it");
            }
        }

        public static bool chkcourseisaddedornot(ComboBox CB,bool b)
        {
            string[] Array = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt");
            int chk = 0;
            if (b)
            {
                chk = 2;
            }
            {
                for (int j = chk; j < Array.Length; j += 3)
                {
                    if (Array[j] == CB.Text)
                    {
                        return false;
                    }
                }
                return true;
            }
        }

        public static void SelectedTeacherPerVis(ComboBox CB,TextBox TB)
        {
            string[] array = File.ReadAllLines(ClassStatic.EnumSelectTSC.Teacher + ".txt");
            for (int i = 0; i < array.Length; i+=4)
            {
                if (CB.Text == array[i] + " " + array[i + 1])
                {
                    TB.Text = array[i + 2];
                    break;
                }
            }
        }

        public static void ChangeTeacherPerVis(TextBox TB, ComboBox CB)
        {
            List<string> list = File.ReadAllLines(ClassStatic.EnumSelectTSC.Teacher + ".txt").ToList();
            for (int i = 0; i < list.Count; i+=4)
            {
                if (list[i] + " " + list[i + 1] == CB.Text)
                {
                    if (TB.Text == "PERMANENT FACULTY")
                    {
                        list.RemoveAt(i + 2);
                        list.Insert(i + 2, "VISITING FACULTY");
                    }
                    else
                    {
                        list.RemoveAt(i + 2);
                        list.Insert(i + 2, "PERMANENT FACULTY");
                    }
                    break;
                }
            }
            File.WriteAllLines(ClassStatic.EnumSelectTSC.Teacher + ".txt", list.ToArray());
            AdditemCBRemoveSTC(ClassStatic.EnumSelectTSC.Teacher.ToString(), CB);
            TB.Text = "";
            MessageBox.Show("Changed Successfully");
            
        }

        public static void AdditemCBRemoveSTC(string sel,ComboBox CB)
        {
            CB.Items.Clear();
            string[] arr;
            int c = 1;
            if (sel == ClassStatic.EnumSelectTSC.Student.ToString())
            {
                arr = File.ReadAllLines(sel + ".txt");
                c = 3;
            }
            else if (sel == ClassStatic.EnumSelectTSC.Teacher.ToString())
            {
                arr = File.ReadAllLines(sel + ".txt");
                c = 4;
            }
            else
                arr = File.ReadAllLines(sel + ".txt");
            for (int i = 0; i < arr.Length;i = i + c)
            {
                if (sel == ClassStatic.EnumSelectTSC.Course.ToString())
                    CB.Items.Add(arr[i]);
                else
                    CB.Items.Add(arr[i] + " " + arr[i + 1]);
            }

                
        }

        public static void AdditeminremCour(ComboBox CB)
        {
            CB.Items.Clear();
            string[] arr =  File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 1; i < arr.Length; i+=4)
            {
                CB.Items.Add(arr[i]);
            }
        }
        public static void SelectediteminremCour(string text,TextBox day,TextBox room,TextBox session)
        {
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 1; i < arr.Length; i+=4)
            {
                if (text == arr[i])
                {
                    day.Text = arr[i + 1];
                    session.Text = arr[i + 2];
                    room.Text = arr[i + 3];
                    break;
                }
            }
        }
        public static void RemoveScheduleCourse(string CourName)
        {
            List<string> l = File.ReadAllLines(@"Schedule\CourseSchedule.txt").ToList();
            for (int i = 1; i < l.Count; i += 4)
            {
                if (CourName == l[i])
                {
                    for (int j = 0; j < 4; j++)
                    {
                        l.RemoveAt(i);
                    }
                    break;
                }
            }
            File.WriteAllLines(@"Schedule\CourseSchedule.txt", l.ToArray());
            MessageBox.Show("Course Schedule Remove Successfully");
        }

        public enum EnumSelectTSC
        {
            Teacher, Student, Course, CourseAdded
        }
        public static void RemoveUnusedFiles()
        {
            string executableLocation = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            foreach (string file in Directory.EnumerateFiles(executableLocation, "*.txt"))
            {
                if (new FileInfo(file).Length == 0)
                {
                    File.Delete(file);
                }
            }
        }
    }
}
