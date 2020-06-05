using System;
using System.Text;
using System.Collections.Generic;
using lab3;

namespace lab6
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

    public interface IStudent
    {
        string GetInfo();
        void Say();
    } 
    
    public class Program
    {
        public static List<Exam> GetIitpSchedule()
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

        public static List<Exam> GetPoitSchedule()
        {
            List<Exam> schedule = new List<Exam>();
            DateTime time = new DateTime(2020, 6, 29, 11, 0, 0);
            Exam exam = new Exam(Lessons.Физика, time);
            schedule.Add(exam);
            return schedule;
        }

        public static List<Exam> GetVmsisSchedule()
        {
            List<Exam> schedule = new List<Exam>();
            DateTime time = new DateTime(2020, 6, 13, 11, 0, 0);
            Exam exam = new Exam(Lessons.АиЛОВТ, time);
            schedule.Add(exam);
            return schedule;
        }

        static bool Compare(Student st1, Student st2)
        {
            return st1.Equals(st2);
        }

        static bool KeyIsCorrect(char key)
        {
            return (key == '1' || key == '2' || key == '3' || key == '4');
        }

        static void Main()
        {
            while (true)
            {
                DateTime birthday = new DateTime(2000, 1, 1);
                StudentIitp iitp1 = new StudentIitp("name1", "male",
                    birthday, GetIitpSchedule());
                if (!iitp1.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
                StudentIitp iitp2 = new StudentIitp("name1", "male",
                    birthday, GetIitpSchedule());
                if (!iitp2.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
                StudentPoit poit = new StudentPoit("name2", "male",
                    birthday, GetPoitSchedule());
                if (!poit.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
                StudentVmsis vmsis = new StudentVmsis("name3", "male",
                    birthday, GetVmsisSchedule());
                if (!vmsis.LessonsAreCorrect()) Console.WriteLine("Wrong lessons");
                Console.WriteLine(iitp1.GetInfo() + "\n" + iitp2.GetInfo() + "\n" +
                    poit.GetInfo() + "\n" + vmsis.GetInfo());
                Console.Write("Введите номер первого студента для сравнения ");
                char key1 = Console.ReadKey().KeyChar;
                while (!KeyIsCorrect(key1))
                {
                    Console.WriteLine();
                    Console.Write("Неправильный номер. Повторите ввод ");
                    key1 = Console.ReadKey().KeyChar;
                }
                Console.WriteLine();
                Console.Write("Введите номер второго студента для сравнения ");
                char key2 = Console.ReadKey().KeyChar;
                while (!KeyIsCorrect(key2) || key2 == key1)
                {
                    Console.WriteLine();
                    Console.Write("Неправильный номер. Повторите ввод ");
                    key2 = Console.ReadKey().KeyChar;
                }
                Console.WriteLine();
                bool compare = false;
                if (key1 == '1')
                    if (key2 == '2') compare = Compare((Student)iitp1, (Student)iitp2);
                    else if (key2 == '3') compare = Compare((Student)iitp1, (Student)poit);
                    else if (key2 == '4') compare = Compare((Student)iitp1, (Student)vmsis);
                if (key1 == '2')
                    if (key2 == '1') compare = Compare((Student)iitp1, (Student)iitp2);
                    else if (key2 == '3') compare = Compare((Student)iitp2, (Student)poit);
                    else if (key2 == '4') compare = Compare((Student)iitp2, (Student)vmsis);
                if (key1 == '3')
                    if (key2 == '1') compare = Compare((Student)iitp1, (Student)poit);
                    else if (key2 == '2') compare = Compare((Student)iitp2, (Student)poit);
                    else if (key2 == '4') compare = Compare((Student)vmsis, (Student)poit);
                if (key1 == '4')
                    if (key2 == '1') compare = Compare((Student)vmsis, (Student)iitp1);
                    else if (key2 == '2') compare = Compare((Student)vmsis, (Student)iitp2);
                    else if (key2 == '3') compare = Compare((Student)vmsis, (Student)poit);
                if (compare) Console.WriteLine("Студенты эквивалентны");
                else Console.WriteLine("Студенты не эквивалентны");

                Console.ReadKey(true);
                Console.Clear();
            }
        }
    }
}