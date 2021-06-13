using System;
using System.Linq;
using System.Reflection;
using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod.Factories
{
    public class ReflectionExamProviderFactory : ExamProviderFactory
    {
        public override ExamProvider? CreateExamProvider(Difficulty difficulty)
        {
            var providers = Assembly.GetAssembly(typeof(ReflectionExamProviderFactory))?.
                GetTypes()
                .Where(t => typeof(ExamProvider)
                    .IsAssignableFrom(t));

            var providerType = (providers ?? Type.EmptyTypes)
                .Single(x => x.Name.ToLowerInvariant()
                    .Contains(difficulty.ToString().ToLowerInvariant()));

            var providerInstance = Activator.CreateInstance(providerType, new QuestionJsonProxy()) as ExamProvider;

            return providerInstance;
        }
    }
}