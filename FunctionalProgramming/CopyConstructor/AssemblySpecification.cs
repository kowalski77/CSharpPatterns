using System.Diagnostics.CodeAnalysis;

namespace FunctionalProgramming.CopyConstructor;

// Copy constructor pattern (Nondestructive mutation), like "with" for records but for classes to achieve immutability.
public class AssemblySpecification
{
    public AssemblySpecification(Guid id)
    {
        this.Id = id;
    }

    [SetsRequiredMembers] // this is dangerous, only use with copy constructors
    public AssemblySpecification(AssemblySpecification other)
        : this(other.Id)
    {
        this.Name = other.Name;
        this.Version = other.Version;
    }

    public Guid Id { get; init; }

    public required string Name { get; init; }

    public required string Version { get; init; }
}
