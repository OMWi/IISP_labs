using System;
using System.Collections.Generic;

namespace lab5
{
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
}
