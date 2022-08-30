using FunctionalProgramming.Support;

namespace FunctionalProgramming.Models;

public class Product
{
    public Product(Guid id, string name, Money cost)
    {
        this.Id = id;
        this.Name = name.NonEmpty(nameof(name));
        this.Cost = cost;
    }

    public Guid Id { get; }

    public string Name { get; }

    public int ProductCode { get; }

    public Money Cost { get; }
}
