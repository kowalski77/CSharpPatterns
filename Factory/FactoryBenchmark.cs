using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using Factory.FactoryMethod;
using Factory.FactoryMethod.Factories;
using Factory.Models;
using Factory.Support;

namespace Factory
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MarkdownExporter]
    [MemoryDiagnoser]
    public class FactoryBenchmark
    {
        private static readonly Dictionary<Difficulty, ExamProvider> ExamProviders = new()
        {
            {Difficulty.Easy, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Medium, new EasyExamProvider(new QuestionJsonProxy())},
            {Difficulty.Hard, new HardExamProvider(new QuestionJsonProxy())}
        };

        [Benchmark]
        public ExamProvider SimpleExamProviderFactory()
        {
            ExamProviderFactory simpleExamProviderFactory = new SimpleExamProviderFactory();
            var examProvider = simpleExamProviderFactory.CreateExamProvider(Difficulty.Hard);

            return examProvider!;
        }

        [Benchmark]
        public ExamProvider ReflectionExamProviderFactory()
        {
            ExamProviderFactory reflectionExamProviderFactory = new ReflectionExamProviderFactory();
            var examProvider = reflectionExamProviderFactory.CreateExamProvider(Difficulty.Hard);

            return examProvider!;
        }


        [Benchmark]
        public ExamProvider StrategyExamProviderFactory()
        {
            ExamProviderFactory strategyExamProviderFactory = new StrategyExamProviderFactory(ExamProviders);
            var examProvider = strategyExamProviderFactory.CreateExamProvider(Difficulty.Hard);

            return examProvider!;
        }
    }
}