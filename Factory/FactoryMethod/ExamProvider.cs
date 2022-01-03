using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod;

public abstract class ExamProvider
{
    protected ExamProvider(IQuestionProvider questionProvider)
    {
        this.QuestionProvider = questionProvider;
    }

    protected IQuestionProvider QuestionProvider { get; }

    public abstract double MinPercentage { get; }

    public abstract Task<IEnumerable<Question>> GenerateQuestionsAsync();
}