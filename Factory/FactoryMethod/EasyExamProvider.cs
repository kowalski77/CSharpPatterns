using Factory.Models;
using Factory.Support;

namespace Factory.FactoryMethod;

public class EasyExamProvider : ExamProvider
{
    public EasyExamProvider(IQuestionProvider questionProvider)
        : base(questionProvider)
    {
    }

    public override double MinPercentage => 50;

    public override async Task<IEnumerable<Question>> GenerateQuestionsAsync()
    {
        var questions = await this.QuestionProvider.GetAllAsync(x => x.Difficulty is Difficulty.Easy or Difficulty.Medium).ConfigureAwait(false);

        return questions;
    }
}