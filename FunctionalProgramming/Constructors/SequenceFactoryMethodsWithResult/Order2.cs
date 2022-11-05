namespace FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;

public class Order2
{
    public Order2(Vendor2 vendor, Product2 product)
    {
        this.Vendor = vendor;
        this.Product = product;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public Vendor2 Vendor { get; }

    public Product2 Product { get; }

    public decimal Total => this.Product.Price;
}
