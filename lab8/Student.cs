using System;
using System.Collections.Generic;
using System.Text;
using lab6;
using lab3;

namespace lab8
{
    class Student : Human, IStudent, IEquatable<Student>
    {
        public delegate void Handler();
        public event Handler FOpenError;
        public event Handler FOpen;
        
        public void ReadFile(string filePath, string fileName)
        {
            string[] arr = new string[3];
            try
            {
                using (System.IO.StreamReader file = new System.IO.StreamReader(filePath + fileName))
                {
                    for (int i = 0; i < 3; i++)
                    {
                        arr[i] = file.ReadLine();
                    }
                    file.Close();
                }
            }
            catch (Exception)
            {
                FOpenError?.Invoke();
                return;
            }
            Name = arr[0];
            Sex = arr[1];
            DateTime.TryParse(arr[2], out DateTime birth);
            Birthday = birth;
            FOpen?.Invoke();
        }


        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.GetInfo());
            info.Append(GetExamSchedule());
            return info.ToString();
        }
        private List<Exam> examSchedule = new List<Exam>();
        public List<Exam> ExamSchedule
        {
            get
            {
                return examSchedule;
            }
            set
            {
                examSchedule = value;
            }
        }
        public Student() { }
        public Student(string name, string sex, DateTime birthday, List<Exam> examSchedule)
            : base(name, sex, birthday)
        {
            this.examSchedule = examSchedule;
        }
        public string GetExamSchedule()
        {
            StringBuilder schedule = new StringBuilder();
            if (examSchedule.Count != 0) schedule.AppendLine("Даты экзаменов :");
            for (int i = 0; i < examSchedule.Count; i++)
            {
                schedule.Append(examSchedule[i].time);
                schedule.Append('\t');
                schedule.Append(examSchedule[i].title);
                schedule.AppendLine();
            }
            return schedule.ToString();
        }
        public bool Equals(Student student)
        {
            if (student.Name != Name) return false;
            if (student.Sex != Sex) return false;
            if (student.Birthday != Birthday) return false;
            return true;
        }
    }
}
