using Factory.Models;

namespace Factory.FactoryMethod.Factories;

public abstract class ExamProviderFactory
{
    public abstract ExamProvider CreateExamProvider(Difficulty difficulty);
}