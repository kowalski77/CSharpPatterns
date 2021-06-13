using System;

namespace Decorator.WithComposition
{
    public class RegularTeacher : ITeacher
    {
        public void TeachCourse(string course)
        {
            Console.WriteLine($"{nameof(RegularTeacher)} teaches {course}");
        }
    }
}