using System.Runtime.CompilerServices;
using InfiniteScroll.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InfiniteScroll.API.Controllers;

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
        var people = context.People
            .AsNoTracking()
            .AsAsyncEnumerable();

        await foreach (var person in people.WithCancellation(cancellationToken))
        {
            await Task.Delay(100, cancellationToken);
            yield return person;
        }
    }
}
