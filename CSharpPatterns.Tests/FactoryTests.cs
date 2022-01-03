using System.Collections.Generic;
using Factory.FactoryMethod;
using Factory.FactoryMethod.Factories;
using Factory.Models;
using Factory.Support;
using FluentAssertions;
using Moq;
using Xunit;

namespace CSharpPatterns.Tests;

public class FactoryTests
{
    [Fact]
    public void Simple_factory_returns_provider_accordingly()
    {
        // Arrange
        var questionProviderMock = new Mock<IQuestionProvider>();
        ExamProviderFactory sut = new SimpleExamProviderFactory(questionProviderMock.Object);

        // Act
        var examProvider = sut.CreateExamProvider(Difficulty.Hard);

        // Assert
        examProvider.Should().BeOfType<HardExamProvider>();
    }

    [Fact]
    public void Reflection_factory_returns_provider_accordingly()
    {
        // Arrange
        ExamProviderFactory sut = new ReflectionExamProviderFactory();

        // Act
        var examProvider = sut.CreateExamProvider(Difficulty.Hard);

        // Assert
        examProvider.Should().BeOfType<HardExamProvider>();
    }

    [Fact]
    public void Strategy_factory_returns_provider_accordingly()
    {
        // Arrange
        Dictionary<Difficulty, ExamProvider> examProviders = new()
        {
            {Difficulty.Easy, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Medium, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Hard, new HardExamProvider(new QuestionJsonProxy())}
        };
        ExamProviderFactory sut = new StrategyExamProviderFactory(examProviders);

        // Act
        var examProvider = sut.CreateExamProvider(Difficulty.Hard);

        // Assert
        examProvider.Should().BeOfType<HardExamProvider>();
    }
}