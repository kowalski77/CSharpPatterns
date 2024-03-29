﻿using DesignPatterns.Behavioral.TemplateMethod;
using FluentAssertions;

namespace CSharpPatterns.Tests;

public class TemplateMethodTests
{
    [Fact]
    public void Template_pattern_calls_all_methods_accordingly()
    {
        // Arrange
        var sut = new FirstModule();

        // Act
        var result = sut.Start();

        // Assert
        result.Item.Should()
            .Contain("First thing done")
            .And
            .Contain("Second thing done");
    }
}