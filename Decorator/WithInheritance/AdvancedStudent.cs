using System;

namespace Decorator.WithInheritance
{
    public class AdvancedStudent : StudentDecorator
    {
        public AdvancedStudent(Student student) 
            : base(student)
        {
        }

        // 1
        public override void EnrollCourse(string course)
        {
            base.EnrollCourse(course);

            Console.WriteLine($"And then, {nameof(AdvancedStudent)} do more stuff.");
        }
    }
}