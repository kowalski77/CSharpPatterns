using System.Text.Json;

namespace DataRetrieval.Client;

public static class Scroll
{
    public static async Task RunAsync()
    {
        using HttpClient httpClient = new();

        using var response = await httpClient.GetAsync(new Uri("https://localhost:7206/People"), HttpCompletionOption.ResponseHeadersRead);

        response.EnsureSuccessStatusCode();

        var responseStream = await response.Content.ReadAsStreamAsync();
        var people = JsonSerializer.DeserializeAsyncEnumerable<Person>(responseStream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        await foreach (var person in people!)
        {
            Console.WriteLine($"{person!.Name} - {person.Email}");
        }
    }
}
