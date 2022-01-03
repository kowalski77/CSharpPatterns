using System.Text.Json;
using System.Text.Json.Serialization;
using Factory.Models;

namespace Factory.Support;

public class QuestionJsonProxy : IQuestionProvider
{
    public async Task<IReadOnlyList<Question>> GetAllAsync(Func<Question, bool> predicate)
    {
        var questionJson = await File.ReadAllTextAsync("questions.json").ConfigureAwait(false);

        var options = new JsonSerializerOptions();
        options.Converters.Add(new JsonStringEnumConverter());
        var questionCollection = JsonSerializer.Deserialize<List<Question>>(questionJson, options);

        var filteredQuestions = (questionCollection ?? new List<Question>()).Where(predicate).ToList();

        return filteredQuestions;
    }
}