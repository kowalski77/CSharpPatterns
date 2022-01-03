using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod;

public class HardExamProvider : ExamProvider
{
    public HardExamProvider(IQuestionProvider questionProvider)
        : base(questionProvider)
    {
    }

    public override double MinPercentage => 70;

    public override async Task<IEnumerable<Question>> GenerateQuestionsAsync()
    {
        var questions = await this.QuestionProvider.GetAllAsync(x => x.Difficulty is Difficulty.Hard).ConfigureAwait(false);

        return questions;
    }
}