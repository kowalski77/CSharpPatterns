using Decorator;
using FluentAssertions;
using Xunit;

namespace CSharpPatterns.Tests;

public class DecoratorTests
{
    [Fact]
    public void Component_calls_concrete_decorator_accordingly()
    {
        // Arrange
        ITeacher teacherDecorator = new TeacherDecorator(new RegularTeacher());

        // Act
        var result = teacherDecorator.TeachCourse("Maths");

        // Assert
        result.Should().Contain(nameof(RegularTeacher));
        result.Should().Contain(nameof(TeacherDecorator));
    }
}