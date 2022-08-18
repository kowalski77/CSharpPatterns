using System.Text.Json;
using InfiniteScroll.Client;

Console.WriteLine("Press a key to start...");
Console.ReadKey();

var client = new HttpClient
{
    BaseAddress = new Uri("https://localhost:7206/People")
};

using var stream = await client.GetStreamAsync(client.BaseAddress);

await foreach(var person in JsonSerializer.DeserializeAsyncEnumerable<Person>(stream))
{
    Console.WriteLine($"{person!.Name} - {person.Email}");
}