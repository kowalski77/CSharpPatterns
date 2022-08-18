using System.Reflection;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace InfiniteScroll.API.Data;

public static class DemoContextExtensions
{
    public static async Task SeedPeopleAsync(this WebApplication host)
    {
        using var scope = host.Services.CreateAsyncScope();
        var context = scope.ServiceProvider.GetRequiredService<DemoContext>();
        if (await context.People.AnyAsync())
        {
            return;
        }

        var people = await GetPeopleFromJsonFileAsync();
        
        await context.People.AddRangeAsync(people);
        await context.SaveChangesAsync();
    }

    public static async Task<IEnumerable<Person>> GetPeopleFromJsonFileAsync()
    {
        var assembly = typeof(DemoContextExtensions).GetTypeInfo().Assembly;
        using var stream = assembly.GetManifestResourceStream("InfiniteScroll.API.Files.persons-data.json") ?? 
            throw new InvalidOperationException("Could not load json data from manifest resource");
        
        var peopleCollection = await JsonSerializer.DeserializeAsync<List<Person>>(stream, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return peopleCollection ?? Enumerable.Empty<Person>();
    }
}
