using Playground.Invariants;

namespace Playground.Instantiate;

// Immutable, cannot update properties without creating a new instance
// When not using Result approach in project
public readonly record struct Name
{
    private readonly string value = null!;

    public Name() : this(string.Empty)
    {
    }

    public Name(string value)
    {
        this.Value = value;
    }

    public static Name Create(string name) => new(name);

    public string Value
    {
        get => this.value;
        init => this.value = value.NonEmpty();
    }
}
