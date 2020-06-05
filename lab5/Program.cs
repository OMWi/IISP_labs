using System;
using System.Collections.Generic;

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
