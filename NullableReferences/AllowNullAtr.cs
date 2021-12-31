using System.Diagnostics.CodeAnalysis;

namespace NullableReferences;

public class AllowNullAtr
{
    public void Run()
    {
        var person = new Person
        {
            DisplayName = null // accept null value because you are sure that it will be returned with a value
        };
    }
}

public class Person
{
    [AllowNull]
    public string DisplayName
    {
        get => this.displayName ?? this.Id;
        set => this.displayName = value;
    }
    private string? displayName;

    public string Id { get; } = Guid.NewGuid().ToString();
}