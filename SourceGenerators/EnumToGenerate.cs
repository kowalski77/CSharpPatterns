namespace SourceGenerators;

public readonly struct EnumToGenerate
{
    public readonly string Name;
    public readonly List<string> Values;

    public EnumToGenerate(string name, List<string> values)
    {
        this.Name = name;
        this.Values = values;
    }
}