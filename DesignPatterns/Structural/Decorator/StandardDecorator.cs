namespace DesignPatterns.Structural.Decorator;

public class StandardDecorator : ITeacher
{
    private readonly ITeacher teacher;

    public StandardDecorator(ITeacher teacher)
    {
        this.teacher = teacher;
    }

    public string TeachCourse(string course)
    {
        var result = this.teacher.TeachCourse(course);

        return $"{result} and {nameof(StandardDecorator)}";
    }
}