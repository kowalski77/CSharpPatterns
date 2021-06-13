using System;

namespace Decorator.WithComposition
{
    public class TeacherDecorator : ITeacher
    {
        private readonly ITeacher teacher;

        public TeacherDecorator(ITeacher teacher)
        {
            this.teacher = teacher;
        }

        public void TeachCourse(string course)
        {
            this.teacher.TeachCourse(course);

            Console.WriteLine($"{nameof(TeacherDecorator)} does extra stuff");
        }
    }
}