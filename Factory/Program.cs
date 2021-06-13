using System.Collections.Generic;
using System.Threading.Tasks;
using Factory.FactoryMethod;
using Factory.FactoryMethod.Factories;
using Factory.Models;
using Factory.Support;

namespace Factory
{
    internal static class Program
    {
        private static async Task Main()
        {
            // Simple
            ExamProviderFactory simpleExamProviderFactory = new SimpleExamProviderFactory();
            var examProvider = simpleExamProviderFactory.CreateExamProvider(Difficulty.Hard);

            // Reflection
            ExamProviderFactory reflectionExamProviderFactory = new ReflectionExamProviderFactory();
            var examProvider2 = reflectionExamProviderFactory.CreateExamProvider(Difficulty.Easy);

            // Strategy
            var dictionary = new Dictionary<Difficulty, ExamProvider>
            {
                {Difficulty.Easy, new EasyExamProvider(new QuestionJsonProxy())},
                {Difficulty.Medium, new EasyExamProvider(new QuestionJsonProxy())},
                {Difficulty.Hard, new HardExamProvider(new QuestionJsonProxy())}
            };
            ExamProviderFactory strategyExamProviderFactory = new StrategyExamProviderFactory(dictionary);
            var examProvider3 = strategyExamProviderFactory.CreateExamProvider(Difficulty.Medium);

            var questions = await examProvider.GenerateQuestionsAsync();
            var questions2 = await examProvider2.GenerateQuestionsAsync();
            var questions3 = await examProvider3.GenerateQuestionsAsync();
        }
    }
}