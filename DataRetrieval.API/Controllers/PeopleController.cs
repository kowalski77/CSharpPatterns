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
    public async Task<IActionResult> GetPeople()
    {
        var people = await this.context.People.ToListAsync();

        return this.Ok(people);
    }

    [HttpGet("v1/{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var person = await this.context.People.FirstOrDefaultAsync(p => p.Id == id);
        if (person is null)
        {
            return this.NotFound();
        }

        return this.Ok(person);
    }

    [HttpGet("v2/{id:guid}")]
    public async Task<IActionResult> GetById2(Guid id)
    {
        var person = await this.context.People.FindAsync(new object[] { id });
        if (person is null)
        {
            return this.NotFound();
        }

        return this.Ok(person);
    }

    [HttpGet("scroll")]
    public async IAsyncEnumerable<Person> GetPeople([EnumeratorCancellation] CancellationToken cancellationToken)
    {
        // Simulating a long pagination with infinite scroll
        var skip = 0;
        var take = 10;
        while (!cancellationToken.IsCancellationRequested)
        {
            var people = this.context.People
                .AsNoTracking()
                .Skip(skip += 10)
                .Take(take)
                .AsAsyncEnumerable();

            if (!await people.AnyAsync(cancellationToken: cancellationToken))
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
