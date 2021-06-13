using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Factory.Models;

namespace Factory.Support
{
    public class QuestionJsonProxy : IQuestionProvider
    {
        public async Task<IReadOnlyList<Question>> GetAllAsync(Func<Question, bool> predicate)
        {
            var questionJson = await File.ReadAllTextAsync("questions.json");

            var options = new JsonSerializerOptions();
            options.Converters.Add(new JsonStringEnumConverter());
            var questionCollection = JsonSerializer.Deserialize<List<Question>>(questionJson, options);

            var filteredQuestions = (questionCollection ?? new List<Question>()).Where(predicate).ToList();

            return filteredQuestions;
        }
    }
}