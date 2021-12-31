namespace Decorator;

public class TeacherDecorator : ITeacher
{
    private readonly ITeacher teacher;

    public TeacherDecorator(ITeacher teacher)
    {
        this.teacher = teacher;
    }

    public string TeachCourse(string course)
    {
        var result = this.teacher.TeachCourse(course);

        return $"{result} {nameof(TeacherDecorator)}";
    }
}