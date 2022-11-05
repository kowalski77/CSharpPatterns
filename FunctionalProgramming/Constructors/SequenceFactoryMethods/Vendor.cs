using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Constructors.SequenceFactoryMethods;

public class Vendor
{
    public Vendor(string name, IEnumerable<Product> products)
    {
        this.Name = name;
        this.Products = products;
    }

    public string Name { get; }

    public IEnumerable<Product> Products { get; }

    public Order PlaceOrder(Product product) =>
        !this.CanSell(product.NonNull()) ?
            throw new ArgumentException("Product not available") :
            new Order(this, product);

    public bool CanSell(Product product) => this.Products.Contains(product) && product.NonNull().Stock > 0;
}

// TODO: Result and IEnumerable Products