using FluentAssertions;
using Playground.Instantiate;

namespace CSharpPatterns.Tests;

public class InstantiateTests
{
    [Fact]
    public void Copy_constructor_approach_creates_new_instance_with_new_properties()
    {
        // Arrange
        const string oldName = "Jim";
        const int oldAge = 68;
        const string newName = "John";
        const int newAge = 69;

        CommonPerson commonPerson = new()
        {
            Name = oldName,
            Age = oldAge,
        };

        // Act
        CommonPerson sut = new(commonPerson)
        {
            Name = newName,
            Age = newAge
        };

        // Assert
        sut.Should().NotBe(commonPerson);
        commonPerson.Name.Should().Be(oldName);
        commonPerson.Age.Should().Be(oldAge);
        sut.Name.Should().Be(newName);
        sut.Age.Should().Be(newAge);
    }

    [Fact]
    public void Struct_with_validation_in_properties_ensure_invariants()
    {
        // Arrange
        Func<Name> sut = () => new Name() { Value = string.Empty };

        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("value");
    }

    [Fact]
    public void Struct_with_validation_in_properties_ensure_invariants_when_using_constructor()
    {
        // Act
        Func<Name> sut = () => Name.Create(string.Empty);

        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("value");
    }

    [Fact]
    public void Struct_with_validation_in_properties_ensure_invariants_when_using_default_Constructor()
    {
        // Act
        Func<Name> sut = () => new Name();

        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("value");
    }

    [Fact]
    public void Struct_with_validation_in_properties_ensure_invariants_when_using_With_keyword()
    {
        // Arrange
        Name name = new("John");

        // Act
        Func<Name> sut = () => name with { Value = string.Empty };

        // Assert
        sut.Should().Throw<ArgumentException>().WithMessage("value");
    }
}
