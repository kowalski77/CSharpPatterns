using System.Reflection;
using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod.Factories;

public class ReflectionExamProviderFactory : ExamProviderFactory
{
    public override ExamProvider CreateExamProvider(Difficulty difficulty)
    {
        var providers = Assembly.GetAssembly(typeof(ReflectionExamProviderFactory))?.GetTypes()
            .Where(t => typeof(ExamProvider)
                .IsAssignableFrom(t));

        var providerType = (providers ?? Type.EmptyTypes)
            .Single(x => x.Name.Contains(difficulty.ToString(), StringComparison.OrdinalIgnoreCase));

        var providerInstance = Activator.CreateInstance(providerType, new QuestionJsonProxy()) as ExamProvider ?? 
                               throw new InvalidOperationException("Could not create the exam provider");

        return providerInstance;
    }
}