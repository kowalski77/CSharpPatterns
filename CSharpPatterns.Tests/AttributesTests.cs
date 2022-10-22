using System.Reflection;
using FluentAssertions;
using Playground.Attributes;

namespace CSharpPatterns.Tests;

public class AttributesTests
{
    [Fact]
    public void Attribute_in_class_shold_return_actual_value()
    {
        // Arrange
        const string expectedValue = "/email";
        var sut = new Person();

        // Act
        var partitionKeyPath = sut.GetType().GetCustomAttribute<PartitionKeyPathAttribute>()?.Path;

        // Assert
        partitionKeyPath.Should().Be(expectedValue);
    }

}
