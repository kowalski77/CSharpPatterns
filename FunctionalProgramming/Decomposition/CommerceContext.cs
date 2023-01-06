using AutoFixture;
using FunctionalProgramming.Constructors.SequenceFactoryMethods;

namespace FunctionalProgramming.Decomposition;

public class CommerceContext
{
    private readonly Lazy<List<Product>> products;

    public CommerceContext()
    {
        IFixture fixture = new Fixture();
        this.products = new Lazy<List<Product>>(() => fixture.CreateMany<Product>(10).ToList());
    }

    public IEnumerable<Product> Products => this.products.Value;
}
