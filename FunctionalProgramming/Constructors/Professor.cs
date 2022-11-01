namespace FunctionalProgramming.Constructors;

public class Professor
{
    public Professor(string name, IEnumerable<Subject> subjects)
    {
        this.Name = name;
        this.Subjects = subjects;
    }

    public string Name { get; }

    public IEnumerable<Subject> Subjects { get; }

    public bool CanAdminister(Subject subject) => this.Subjects.Contains(subject);
}
