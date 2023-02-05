using DesignPatterns.Structural.Decorator;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class DecoratorTests
{
    [Fact]
    public void Component_calls_concrete_standard_decorator_accordingly()
    {
        // Arrange
        ITeacher teacherDecorator = new StandardDecorator(new RegularTeacher());

        // Act
        var result = teacherDecorator.TeachCourse("Maths");

        // Assert
        result.Should().Be($"course Maths with RegularTeacher and {nameof(StandardDecorator)}");
    }

    [Fact]
    public void Component_calls_concrete_chained_decorator_accordingly()
    {
        // Arrange
        ITeacher teacherDecorator = new RegularTeacher().Then(new SuperTeacher());

        // Act
        var result = teacherDecorator.TeachCourse("Maths");

        // Assert
        result.Should().Be("course Maths with RegularTeacher and SuperTeacher");
    }
}