using System;

namespace Decorator.WithInheritance
{
    // Concrete Component
    public class RegularStudent : Student
    {
        // 3
        public override void EnrollCourse(string course)
        {
            Console.WriteLine($"{nameof(RegularStudent)} enrolled to {course}");
        }
    }
}