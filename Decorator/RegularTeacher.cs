namespace Decorator;

public class RegularTeacher : ITeacher
{
    public string TeachCourse(string course)
    {
        return nameof(RegularTeacher);
    }
}