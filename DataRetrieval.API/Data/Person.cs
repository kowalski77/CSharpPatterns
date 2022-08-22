namespace DataRetrieval.API.Data;

public class Person
{
    public Guid Id { get; init; } = Guid.NewGuid();

    public string Name { get; init; } = default!;

    public string? Phone { get; init; }

    public string Email { get; init; } = default!;

    public static IComparer<Person> NameComparer =>
        Comparer<Person>.Create((x, y) => x.Name.CompareTo(y.Name));
}
