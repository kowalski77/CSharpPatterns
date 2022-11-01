using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Constructors;

public class Exam
{
    private Exam(Subject subject, Professor administrator) => 
        (this.Subject, this.Administrator) = (subject.NonNull(), administrator.NonNull());

    public Subject Subject { get; }

    public Professor Administrator { get; }

    public static IEnumerable<Exam> TryAdminister(Professor administrator, IEnumerable<Subject> subjects)
        => administrator is null ?
            Enumerable.Empty<Exam>() :
            subjects
                .Where(subject => subjects is not null)
                .Where(administrator.CanAdminister)
                .Select(subject => new Exam(subject, administrator));
}

public class ExamApplication
{
    public ExamApplication(Exam exam, Student student)
    {
        this.Exam = exam;
        this.Student = student;
    }

    public Exam Exam { get; }

    public Student Student { get; set; }

    public static IEnumerable<ExamApplication> TryApplyFor(
        Student candidate, IEnumerable<Exam> exams) =>
        candidate is null ? 
        Enumerable.Empty<ExamApplication>() : 
        exams
          .Where(exam => exam is not null)
          .Where(candidate.CanApplyFor)
          .Select(exam => new ExamApplication(exam, candidate));
}
