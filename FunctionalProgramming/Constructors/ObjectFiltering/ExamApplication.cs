namespace FunctionalProgramming.Constructors.ObjectFiltering;

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
