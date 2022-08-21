using Microsoft.EntityFrameworkCore;

namespace DataRetrieval.API.Data;

public class DemoContext : DbContext
{
    public DemoContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Person> People { get; set; } = default!;
}
