namespace Playground.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class PartitionKeyPathAttribute : Attribute
{
    public string Path { get; } = "/id";

    public PartitionKeyPathAttribute(string path) =>
        this.Path = path ?? 
        throw new ArgumentNullException(nameof(path), "A path is required.");
}
