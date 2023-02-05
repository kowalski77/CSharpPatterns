namespace DesignPatterns.Structural.Decorator;

public class ChainedDecorator : ITeacher
{
    private readonly ITeacher first;

    private readonly ITeacher next;

    public ChainedDecorator(ITeacher first, ITeacher next)
    {
        this.first = first;
        this.next = next;
    }

    public string TeachCourse(string course)
    {
        return this.next.TeachCourse(this.first.TeachCourse(course));
    }
}

public static class ChainFactory
{
    public static ITeacher Then(this ITeacher first, ITeacher next) =>
        next is null ?
            first :
            new ChainedDecorator(first, next);
}