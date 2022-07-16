using DesignPatterns.Creational.Prototype;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class PrototypeTests
{
    [Fact]
    public void SallowCopyTest()
    {
        // Arrange
        var employee = new Employee
        {
            Name = "John",
            Department = "IT",
            Identifier = new Identifier(1)
        };

        // Act
        var clonedEmployee = employee.Clone();
        employee.Identifier.Id = 2;

        // Assert
        employee.Should().NotBeSameAs(clonedEmployee);
        employee.Name.Should().Be(clonedEmployee.Name);
        employee.Department.Should().Be(clonedEmployee.Department);
        employee.Identifier.Id.Should().Be(clonedEmployee.Identifier!.Id);
    }

    [Fact]
    public void DeepCopyTest()
    {
        // Arrange
        var manager = new Manager
        {
            Name = "John",
            Identifier = new Identifier(1)
        };

        // Act
        var clonedManager = manager.Clone(true);
        manager.Identifier!.Id = 2;

        // Assert
        manager.Should().NotBeSameAs(clonedManager);
        manager.Name.Should().Be(clonedManager.Name);
        manager.Identifier.Id.Should().NotBe(clonedManager.Identifier!.Id);
    }
}
