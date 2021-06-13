using Decorator.WithComposition;
using Decorator.WithInheritance;

namespace Decorator
{
    internal static class Program
    {
        private static void Main()
        {
            // with Inheritance and abstract decorator
            var regularStudent = new RegularStudent();
            var advancedStudent = new AdvancedStudent(regularStudent);

            advancedStudent.EnrollCourse("Maths");

            // with composition
            var regularTeacher = new RegularTeacher();
            var teacherDecorator = new TeacherDecorator(regularTeacher);

            teacherDecorator.TeachCourse("Maths");
        }
    }
}