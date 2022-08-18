namespace InfiniteScroll.Client;

public class Person
{
    public Guid Id { get; init; }

    public string Name { get; init; } = default!;

    public string? Phone { get; init; }

    public string Email { get; init; } = default!;
}
