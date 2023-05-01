using FluentAssertions;
using FunctionalProgramming.CopyConstructor;

namespace CSharpPatterns.Tests;

public class CopyConstructorTests
{
    [Fact]
    public void CopyConstructorTest()
    {
        AssemblySpecification original = new(Guid.NewGuid())
        {
            Name = "Original", 
            Version = "1.0" 
        };

        AssemblySpecification copy = new(original)
        {
            Name = "Test"
        };

        copy.Id.Should().Be(original.Id);
        copy.Name.Should().Be("Test");
        copy.Version.Should().Be(original.Version);
    }
}
