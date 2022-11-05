namespace FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;

public class Product2
{
    public Product2(string name, decimal price)
    {
        this.Name = name;
        this.Price = price;
    }

    public string Name { get; }

    public decimal Price { get; }

    public int Stock { get; } = 5;
}
