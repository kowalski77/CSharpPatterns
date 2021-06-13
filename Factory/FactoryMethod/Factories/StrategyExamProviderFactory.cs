using System;
using System.Collections.Generic;
using Factory.Models;

namespace Factory.FactoryMethod.Factories
{
    public class StrategyExamProviderFactory : ExamProviderFactory
    {
        private readonly Dictionary<Difficulty, ExamProvider> strategies;

        public StrategyExamProviderFactory(Dictionary<Difficulty, ExamProvider> strategies)
        {
            this.strategies = strategies;
        }

        public override ExamProvider CreateExamProvider(Difficulty difficulty)
        {
            if (this.strategies.TryGetValue(difficulty, out var strategy))
            {
                return strategy;
            }

            throw new InvalidOperationException($"No strategy registered for type: {difficulty}");
        }
    }
}