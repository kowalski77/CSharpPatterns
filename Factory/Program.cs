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

            if (examProvider != null)
            {
                var questions = await examProvider.GenerateQuestionsAsync();
            }

            // Reflection
            ExamProviderFactory reflectionExamProviderFactory = new ReflectionExamProviderFactory();
            var examProvider2 = reflectionExamProviderFactory.CreateExamProvider(Difficulty.Easy);

            if (examProvider2 != null)
            {
                var questions2 = await examProvider2.GenerateQuestionsAsync();
            }

            // Strategy
            var dictionary = new Dictionary<Difficulty, ExamProvider>
            {
                {Difficulty.Easy, new EasyExamProvider(new QuestionJsonProxy())},
                {Difficulty.Medium, new EasyExamProvider(new QuestionJsonProxy())},
                {Difficulty.Hard, new HardExamProvider(new QuestionJsonProxy())}
            };
            ExamProviderFactory strategyExamProviderFactory = new StrategyExamProviderFactory(dictionary);
            var examProvider3 = strategyExamProviderFactory.CreateExamProvider(Difficulty.Medium);

            if (examProvider3 != null)
            {
                var questions3 = await examProvider3.GenerateQuestionsAsync();
            }
        }
    }
}