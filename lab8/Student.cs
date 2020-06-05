using System;
using System.Collections.Generic;
using System.Text;
using lab6;
using lab3;

namespace lab8
{
    class Student : Human, IStudent, IEquatable<Student>
    {
        public delegate void Del1(string str);
        public event Del1 DataGot;   
        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.GetInfo());
            info.Append(GetExamSchedule());
            DataGot?.Invoke(info.ToString());
            return info.ToString();
        }
        public override void Say()
        {
            Console.WriteLine("I want offset");
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
