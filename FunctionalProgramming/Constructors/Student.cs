namespace FunctionalProgramming.Constructors;

public class Student
{
    public Student(string name, IEnumerable<Exam> exams)
    {
        this.Name = name;
        this.Exams = exams;
    }

    public string Name { get; }

    public IEnumerable<Exam> Exams { get; }

    public bool CanApplyFor(Exam exam) => !this.Exams.Contains(exam);
}
