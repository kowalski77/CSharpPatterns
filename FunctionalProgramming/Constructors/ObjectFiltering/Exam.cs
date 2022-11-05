using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Constructors.ObjectFiltering;

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
