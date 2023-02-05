namespace DesignPatterns.Structural.Decorator;

public class SuperTeacher : ITeacher
{
    public string TeachCourse(string course) => $"{course} and {nameof(SuperTeacher)}";
}
