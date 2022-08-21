using System.Runtime.CompilerServices;
using DataRetrieval.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DataRetrieval.API.Controllers;

[ApiController]
[Route("People")]
public class PeopleController : ControllerBase
{
    private readonly DemoContext context;

    public PeopleController(DemoContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async IAsyncEnumerable<Person> GetPeople([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Simulating a long pagination with infinite scroll
        var skip = 0;
        var take = 10;
        while (!cancellationToken.IsCancellationRequested)
        {
            var people = context.People
                .AsNoTracking()
                .Skip(skip += 10)
                .Take(take)
                .AsAsyncEnumerable();

            if (!await people.AnyAsync())
            {
                break;
            }

            await foreach (var person in people.WithCancellation(cancellationToken))
            {
                yield return person;
            }
        }
    }
}
