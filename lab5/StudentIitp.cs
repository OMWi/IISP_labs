using System;
using System.Collections.Generic;

namespace lab5
{
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
}