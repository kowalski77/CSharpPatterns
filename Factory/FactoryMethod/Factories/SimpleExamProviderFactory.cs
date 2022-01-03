using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod.Factories;

public class SimpleExamProviderFactory : ExamProviderFactory
{
    private readonly IQuestionProvider questionProvider;

    public SimpleExamProviderFactory(IQuestionProvider questionProvider)
    {
        this.questionProvider = questionProvider ?? throw new ArgumentNullException(nameof(questionProvider));
    }

    public override ExamProvider CreateExamProvider(Difficulty difficulty)
    {
        return difficulty switch
        {
            Difficulty.Easy => new EasyExamProvider(this.questionProvider),
            Difficulty.Medium => new EasyExamProvider(this.questionProvider),
            Difficulty.Hard => new HardExamProvider(this.questionProvider),
            _ => throw new InvalidOperationException("Could not create the exam provider")
        };
    }
}