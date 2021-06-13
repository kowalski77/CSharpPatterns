using System.Collections.Generic;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Order;
using Factory.FactoryMethod;
using Factory.FactoryMethod.Factories;
using Factory.Models;
using Factory.Support;

namespace Factory
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class FactoryBenchmark
    {
        [Benchmark]
        public void SimpleExamProviderFactory()
        {
            ExamProviderFactory simpleExamProviderFactory = new SimpleExamProviderFactory();
            var examProvider = simpleExamProviderFactory.CreateExamProvider(Difficulty.Hard);
        }

        [Benchmark]
        public void ReflectionExamProviderFactory()
        {
            ExamProviderFactory reflectionExamProviderFactory = new ReflectionExamProviderFactory();
            var examProvider = reflectionExamProviderFactory.CreateExamProvider(Difficulty.Hard);
        }

        
        [Benchmark]
        public void StrategyExamProviderFactory()
        {
            ExamProviderFactory strategyExamProviderFactory = new StrategyExamProviderFactory(ExamProviders);
            var examProvider = strategyExamProviderFactory.CreateExamProvider(Difficulty.Hard);
        }

        private static readonly Dictionary<Difficulty, ExamProvider> ExamProviders = new()
        {
            {Difficulty.Easy, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Medium, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Hard, new HardExamProvider(new QuestionJsonProxy())}
        };
    }
}