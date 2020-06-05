using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using lab3;

namespace lab5
{
    class Student : Human
    {
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
        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.GetInfo());
            info.Append(GetExamSchedule());
            return info.ToString();
        }
    }
}
