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
    class Schedule
    {
        //NEW SCHEDULE


        public void ManualScheduleCourse(string Courname, string Day, string time, string room)
        {
            if (OverrideCheck(Day, time, room))
            {
                if (ClashHandler(Courname, Day, time))
                {
                    AddCourseinSchedule(Courname, Day, time, room);
                    MessageBox.Show("Schedule Successfully");
                }
                else MessageBox.Show("Clash with other course");

            }
            else MessageBox.Show("Already exists a Course");
        }
        public void AddCourseinSchedule(string Courname, string Day, string time, string room)
        {
            StreamWriter sw = new StreamWriter(@"Schedule\CourseSchedule.txt", true);
            sw.WriteLine(Courname);
            sw.WriteLine(Day);
            sw.WriteLine(time);
            sw.WriteLine(room);
            sw.Close();
        }
        public bool OverrideCheck(string day, string time, string room)
        {
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 2; i < arr.Length; i += 4)
            {
                if (day == arr[i] && time == arr[i + 1] && room == arr[i + 2])
                    return false;
            }
            return true;
        }

        public void AutomaticSchedule(ComboBox CB)
        {
            string courName = CB.Text;
            List<string> l = Scheduler();
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            int room = int.Parse(arr[0]);
            Random r = new Random();
            List<string> temp = new List<string>();
            int index = 0;
            for (int i = 2; i < arr.Length; i += 4)
            {
                temp.Add(arr[i] + " " + arr[i + 1] + " " + arr[i + 2]);
                index++;
            }
            int counter = index;
            while (true)
            {
                int no = generateEvenRandom(l.Count - 2);
                int ranRoom = r.Next(1, room + 1);
                if (!temp.Contains(l[no] + " " + l[no + 1] + " " + ranRoom.ToString()))
                {
                    temp.Add(l[no] + " " + l[no + 1] + " " + (ranRoom).ToString());
                    if (ClashHandler(courName, l[no], l[no + 1]))
                    {

                        AddCourseinSchedule(courName, l[no], l[no + 1], ranRoom.ToString());
                        ClassStatic.AddItemsinCBSchedule(CB);
                        MessageBox.Show("Schedule Successfully");
                        break;

                    }
                    else
                    {
                        for (int i = 0; i < room; i++)
                        {
                            if (!temp.Contains(l[no] + " " + l[no + 1] + " " + ranRoom.ToString()))
                            {
                                temp.Add(l[no] + " " + l[no + 1] + " " + (i + 1).ToString());
                                counter++;
                            }
                        }
                    }
                    counter++;
                }
                if (counter == room * (l.Count / 2))
                {
                    MessageBox.Show("Not Schedule Because In Schedule You have Clashes OR Already Courses Exist");
                    break;
                }
            } // end of while loop
        }// Method end

        public void RemainingAllCoursesSchedule()
        {
            string[] courseAdded = File.ReadAllLines(ClassStatic.EnumSelectTSC.CourseAdded + ".txt");
            string[] ScheduleCourses = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            List<string> list = new List<string>();
            for (int i = 0; i < courseAdded.Length; i += 3)
            {
                bool b = true;
                for (int j = 1; j < ScheduleCourses.Length; j += 4)
                {
                    if (courseAdded[i] + " " + courseAdded[i + 1] == ScheduleCourses[j])
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    list.Add(courseAdded[i] + " " + courseAdded[i + 1]);
                }
            }
            List<string> l = Scheduler();
            List<string> temp = new List<string>();
            int room = int.Parse(ScheduleCourses[0]);
            Random r = new Random();
            for (int k = 0; k < list.Count; k++)
            {
                temp.Clear();
                string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
                int index = 0;
                for (int i = 2; i < arr.Length; i += 4)
                {
                    temp.Add(arr[i] + " " + arr[i + 1] + " " + arr[i + 2]);
                    index++;
                }
                int counter = index;
                while (true)
                {
                    int no = generateEvenRandom(l.Count - 2);
                    int ranRoom = r.Next(1, room + 1);
                    if (!temp.Contains(l[no] + " " + l[no + 1] + " " + ranRoom.ToString()))
                    {
                        temp.Add(l[no] + " " + l[no + 1] + " " + (ranRoom).ToString());
                        if (ClashHandler(list[k], l[no], l[no + 1]))
                        {

                            AddCourseinSchedule(list[k], l[no], l[no + 1], ranRoom.ToString());
                            break;

                        }
                        else
                        {
                            for (int i = 0; i < room; i++)
                            {
                                if (!temp.Contains(l[no] + " " + l[no + 1] + " " + ranRoom.ToString()))
                                {
                                    temp.Add(l[no] + " " + l[no + 1] + " " + (i + 1).ToString());
                                    counter++;
                                }
                            }
                        }
                        counter++;
                    }
                    if (counter == room * (l.Count / 2))
                    {
                        break;
                    }
                }
            }

            MessageBox.Show("Process Done! \"If all courses are not schedule so, there is clash OR Course Already Exists OR All Courses are schedule\"");
        }

        public int generateEvenRandom(int max)
        {
            Random random = new Random();
            int ans = random.Next(0, max);
            if (ans % 2 == 0) return ans;
            else
            {
                return ans + 1;
            }
        }


        public bool ClashHandler(string courName, string Day, string Time)
        {
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 2; i < arr.Length; i += 4)
            {
                if (arr[i] == Day && arr[i + 1] == Time)
                {
                    string[] ArrCour = File.ReadAllLines(arr[i - 1] + ".txt");
                    string[] ParCour = File.ReadAllLines(courName + ".txt");
                    if (ArrCour[2] == ParCour[2])
                        return false;
                    for (int j = 3; j < ArrCour.Length; j++)
                    {
                        for (int k = 3; k < ParCour.Length; k++)
                        {
                            if (ArrCour[j] == ParCour[k])
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }










        public List<string> Scheduler()
        {
            List<string> l = new List<string>();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                string Day = day.ToString().ToUpper();
                for (int i = 1; i <= 4; i++)
                {
                    if (File.Exists(@"Schedule\SESSION " + i + ".txt"))
                    {
                        string[] arr = File.ReadAllLines(@"Schedule\SESSION " + i + ".txt");
                        for (int j = 1; j < arr.Length; j++)
                        {
                            if (arr[j] == Day)
                            {
                                l.Add(Day);
                                l.Add(arr[0]);
                                break;
                            }
                        }
                    }
                }
            }
            return l;
        }

        public void ShowSchedule(DataGridView DGV)
        {
            if (File.Exists(@"Schedule\CourseSchedule.txt"))
            {
                if (new FileInfo(@"Schedule\CourseSchedule.txt").Length != 0)
                {
                    DataTable table = new DataTable();
                    string[] CourseSchedule = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
                    int rooms = int.Parse(CourseSchedule[0]);
                    table.Columns.Add("DAY");
                    table.Columns.Add("TIME");
                    for (int i = 1; i <= rooms; i++)
                    {
                        table.Columns.Add("Room " + i);
                        //table.Columns[i].ReadOnly = true;
                    }
                    List<string> l = Scheduler();

                    for (int i = 0; i < l.Count; i += 2)
                    {
                        table.Rows.Add(l[i], l[i + 1]);
                    }


                    DGV.DataSource = table;
                    foreach (DataGridViewColumn column in DGV.Columns)
                    {
                        column.SortMode = DataGridViewColumnSortMode.NotSortable;
                    }
                    for (int i = 1; i < CourseSchedule.Length; i += 4)
                    {
                        for (int j = 0; j < l.Count; j += 2)
                        {
                            if (l[j] == CourseSchedule[i + 1] && l[j + 1] == CourseSchedule[i + 2])
                            {
                                DGV.Rows[j / 2].Cells[1 + (int.Parse(CourseSchedule[i + 3]))].Value = CourseSchedule[i];
                                DGV.Rows[j / 2].Cells[1 + (int.Parse(CourseSchedule[i + 3]))].Style.BackColor = Color.LightBlue;
                                break;
                            }
                        }
                    }

                }

            }
        }
        string[] arrayt { get; set; }
        public void Showteacher(DataGridView DGV)
        {
            DataTable table = new DataTable();
            table.Columns.Add("TEACHER NAME");
            table.Columns.Add("ID NO");
            table.Columns.Add("STATUS");
            table.Columns.Add("COURSES");
            string[] teacher = File.ReadAllLines(ClassStatic.EnumSelectTSC.Teacher+".txt");
            for (int i = 0; i < teacher.Length; i+=4)
            {
                string first = "";
                if (File.Exists(teacher[i] + " " + teacher[i + 1] + ".txt"))
                {
                    arrayt = File.ReadAllLines(teacher[i] + " " + teacher[i + 1] + ".txt");
                    first = arrayt[i] + " " + arrayt[i + 1];
                }
                table.Rows.Add(teacher[i], teacher[i + 1], teacher[i + 2], first);
                for (int j = 2; j < arrayt.Length; j+=2)
                {
                   table.Rows.Add("", "", "", arrayt[j]+ " " + arrayt[j + 1]);
                }
            }

            DGV.DataSource = table;
            foreach (DataGridViewColumn column in DGV.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            DGV.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            DGV.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }




    }
}
