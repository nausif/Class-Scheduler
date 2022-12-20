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
    class AdddaytimeofSchedule
    {
        public void AdditeminCB(ComboBox CB1,ComboBox CB2)
        {
            CB1.Items.Clear();
            CB2.Items.Clear();
            foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
            {
                CB1.Items.Add(day.ToString().ToUpper());
            }
            for (int i = 1; i <= 4; i++)
            {
                CB2.Items.Add("SESSION " + i);
            }
        }
        public void AddSessionsinCB(ComboBox CB)
        {
            CB.Items.Clear();
            for (int i = 1; i <= 4; i++)
            {
                CB.Items.Add("SESSION " + i);
            }
        }
        public void SelectedManualDaysCB(string session,ComboBox CB)
        {
            CB.Items.Clear();
            string[] arr = File.ReadAllLines(@"Schedule\" + session + ".txt");
            for (int i = 1; i < arr.Length; i++)
            {
                CB.Items.Add(arr[i]);
            }
        }
        public void SelectedSessionTime(string CB,TextBox TB)
        {
            string[] time = { "8:00 - 10:00", "10:30 - 12:30", "1:00 - 3:00", "3:30 - 5:30" };
            for (int i = 1; i <= 4 ; i++)
            {
                if ("SESSION " + i == CB)
                {
                   TB.Text = time[i - 1];
                   break;
                }
            }
        }
        public bool CheckAlreadyaddedornot(string day, string session)
        {
            if (File.Exists(@"Schedule\" + session + ".txt"))
            {
                string[] arr = File.ReadAllLines(@"Schedule\" + session + ".txt");
                for (int i = 1; i < arr.Length; i++)
                {
                    if (arr[i] == day)
                        return false;
                }
            }
            return true;
        }
        public void RoomNoAdditeminCB(ComboBox CB)
        {
            CB.Items.Clear();
            int a = 0;
            long chk = new FileInfo(@"Schedule\CourseSchedule.txt").Length;
            if (chk > 0)
            {
                a = int.Parse(File.ReadLines(@"Schedule\CourseSchedule.txt").First());
            }
            for (int i = 1; i <= a; i++)
            {
                CB.Items.Add(i);
            }
        }
        public void AddDayTime(string day, string session, string time)
        {
            if (CheckAlreadyaddedornot(day, session))
            {
                StreamWriter sw = new StreamWriter(@"Schedule\" + session + ".txt", true);
                if (new FileInfo(@"Schedule\" + session + ".txt").Length == 0)
                    sw.WriteLine(time);
                sw.WriteLine(day);
                sw.Close();
                MessageBox.Show("Added Successfully");

            }
            else MessageBox.Show("Given Input is Already Added");
        }

        public void UpdateRooms(int Value)
        {
            if (!File.Exists(@"Schedule\CourseSchedule.txt"))
            {
                StreamWriter sw = new StreamWriter(@"Schedule\CourseSchedule.txt",true);
                sw.WriteLine(Value);
                sw.Close();
            }
            else
            {
                int len = File.ReadAllLines(@"Schedule\CourseSchedule.txt").Count();
                if (len == 0 || len == 1)
                {
                    File.Delete(@"Schedule\CourseSchedule.txt");
                    StreamWriter sw = new StreamWriter(@"Schedule\CourseSchedule.txt",true);
                    sw.WriteLine(Value);
                    sw.Close();
                    MessageBox.Show("Rooms Updated Successfully");
                }
                else MessageBox.Show("You can only Update, if Scheduled Course Donot Exists");
            }
        }

        public void RemoveDayTime(string day, string session,string time)
        {
            if (File.Exists(@"Schedule\" + session + ".txt"))
            {
                if (CheckAlreadyaddedornot(day,session) == false)
                {
                    if (CourseExistinTimtable(day, time))
                    {
                        List<string> l = File.ReadAllLines(@"Schedule\" + session + ".txt").ToList();
                        for (int i = 1; i < l.Count; i++)
                        {
                            if (day == l[i])
                            {
                                l.RemoveAt(i);
                                break;
                            }
                        }
                        File.WriteAllLines(@"Schedule\" + session + ".txt", l.ToArray());
                        MessageBox.Show("Deleted Successfully");
                    }
                    else MessageBox.Show("You can't Remove Because there exist courses. First Remove All courses in this row");
                }
                else MessageBox.Show("Not Found Because You haven't added it");

            }
            else MessageBox.Show("Not Found");
        }
        private bool CourseExistinTimtable(string day,string time)
        {
            string[] arr = File.ReadAllLines(@"Schedule\CourseSchedule.txt");
            for (int i = 2; i < arr.Length; i+=4)
            {
                if (arr[i] == day && arr[i+1] == time)
                    return false;
            }
            return true;
        }
    }
}
