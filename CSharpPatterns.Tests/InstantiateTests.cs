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
}
