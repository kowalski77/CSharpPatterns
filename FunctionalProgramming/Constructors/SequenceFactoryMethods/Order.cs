namespace FunctionalProgramming.Constructors.SequenceFactoryMethods;

public class Order
{
    public Order(Vendor vendor, Product product)
    {
        this.Vendor = vendor;
        this.Product = product;
    }

    public Guid Id { get; } = Guid.NewGuid();

    public Vendor Vendor { get; }

    public Product Product { get; }

    public decimal Total => this.Product.Price;
}
