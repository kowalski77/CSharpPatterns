﻿using Factory.Models;

namespace Factory.FactoryMethod.Factories;

public class StrategyExamProviderFactory : ExamProviderFactory
{
    private readonly Dictionary<Difficulty, ExamProvider> strategies;

    public StrategyExamProviderFactory(Dictionary<Difficulty, ExamProvider> strategies)
    {
        this.strategies = strategies;
    }

    public override ExamProvider CreateExamProvider(Difficulty difficulty)
    {
        return this.strategies.TryGetValue(difficulty, out var strategy) ?
            strategy :
            throw new InvalidOperationException("Could not create the exam provider");
    }
}