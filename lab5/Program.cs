using System;
using System.Collections.Generic;
using System.Text;
using lab3;

namespace lab5
{
    public enum Lessons
    {
        Программирование,
        ММА,
        ИнЯз,
        МГиА,
        ОАиП,
        Математика,
        ДМ,
        Физика,
        АиЛОВТ,
    }

    public struct Exam
    {
        public Lessons title;
        public DateTime time;
        public Exam(Lessons title, DateTime time)
        {
            this.title = title;
            this.time = time;
        }
    }

    class Student : Human
    {
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
        public override string GetInfo()
        {
            StringBuilder info = new StringBuilder();
            info.Append(base.GetInfo());
            info.Append(GetExamSchedule());
            return info.ToString();
        }
    }

    class StudentIitp : Student
    {
        public StudentIitp() { }
        public StudentIitp(string name, string sex, DateTime birthday, List<Exam> examSchedule)
            : base(name, sex, birthday, examSchedule) { }
        public bool LessonsAreCorrect()
        {
            for (int i = 0; i < ExamSchedule.Count; i++)
            {
                if (ExamSchedule[i].title != Lessons.ИнЯз && ExamSchedule[i].title != Lessons.МГиА &&
                    ExamSchedule[i].title != Lessons.ММА && ExamSchedule[i].title != Lessons.ОАиП &&
                    ExamSchedule[i].title != Lessons.Программирование)
                {
                    return false;
                }
            }
            return true;
        }
    }

    class StudentPoit : Student
    {
        public StudentPoit() { }
        public StudentPoit(string name, string sex, DateTime birthday, List<Exam> examSchedule)
            : base(name, sex, birthday, examSchedule) { }
        public bool LessonsAreCorrect()
        {
            for (int i = 0; i < ExamSchedule.Count; i++)
            {
                if (ExamSchedule[i].title != Lessons.Математика && ExamSchedule[i].title != Lessons.ДМ &&
                    ExamSchedule[i].title != Lessons.ИнЯз && ExamSchedule[i].title != Lessons.ОАиП &&
                    ExamSchedule[i].title != Lessons.Физика)
                {
                    return false;
                }
            }
            return true;
        }
    }

    class StudentVmsis : Student
    {
        public StudentVmsis() { }
        public StudentVmsis(string name, string sex, DateTime birthday, List<Exam> examSchedule)
            : base(name, sex, birthday, examSchedule) { }
        public bool LessonsAreCorrect()
        {
            for (int i = 0; i < ExamSchedule.Count; i++)
            {
                if (ExamSchedule[i].title != Lessons.Математика && ExamSchedule[i].title != Lessons.АиЛОВТ &&
                    ExamSchedule[i].title != Lessons.ИнЯз && ExamSchedule[i].title != Lessons.ОАиП &&
                    ExamSchedule[i].title != Lessons.Физика)
                {
                    return false;
                }
            }
            return true;
        }
    }

    class Program
    {
        static List<Exam> GetIitpSchedule()
        {
            List<Exam> schedule = new List<Exam>();
            DateTime time = new DateTime(2020, 6, 25, 8, 0, 0);
            Exam exam = new Exam(Lessons.ММА, time);
            schedule.Add(exam);
            time = new DateTime(2020, 6, 29, 8, 0, 0);
            exam = new Exam(Lessons.Программирование, time);
            schedule.Add(exam);
            return schedule;
        }

        static List<Exam> GetPoitSchedule()
        {
            List<Exam> schedule = new List<Exam>();
            DateTime time = new DateTime(2020, 6, 29, 11, 0, 0);
            Exam exam = new Exam(Lessons.Физика, time);
            schedule.Add(exam);
            return schedule;
        }

        static List<Exam> GetVmsisSchedule()
        {
            List<Exam> schedule = new List<Exam>();
            DateTime time = new DateTime(2020, 6, 13, 11, 0, 0);
            Exam exam = new Exam(Lessons.АиЛОВТ, time);
            schedule.Add(exam);
            return schedule;
        }

        static void Main()
        {
            DateTime birthday = new DateTime(2000, 1, 1);
            StudentIitp iitp = new StudentIitp("name1", "male",
                birthday, GetIitpSchedule());
            if (!iitp.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
            StudentPoit poit = new StudentPoit("name2", "male",
                birthday, GetPoitSchedule());
            if (!poit.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
            StudentVmsis vmsis = new StudentVmsis("name3", "male",
                birthday, GetVmsisSchedule());
            if (!vmsis.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
            Console.WriteLine(iitp.GetInfo() + "\n" + poit.GetInfo() + "\n" + vmsis.GetInfo());
            Console.ReadLine();
        }
    }
}
