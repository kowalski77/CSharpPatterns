namespace DesignPatterns.Structural.Decorator;

public class RegularTeacher : ITeacher
{
    public string TeachCourse(string course) => $"course {course} with {nameof(RegularTeacher)}";
}