using System;

namespace Decorator.WithInheritance
{
    // Abstract Decorator
    public abstract class StudentDecorator : Student
    {
        private readonly Student student;

        protected StudentDecorator(Student student)
        {
            this.student = student;
        }

        // 2
        public override void EnrollCourse(string course)
        {
            Console.WriteLine("Do some decorator stuff...");

            this.student.EnrollCourse(course);
        }
    }
}