using FunctionalProgramming.Guards;
using SharedKernel.Results;

namespace FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;

public class Vendor2
{
    public Vendor2(string name, IEnumerable<Product2> products)
    {
        this.Name = name;
        this.Products = products;
    }

    public string Name { get; }

    public IEnumerable<Product2> Products { get; }

    public Result<Order2> PlaceOrder(Product2 product)
    {
        Result result = this.CanSell(product);
        return result.Success ?
            new Order2(this, product) :
            result.Error!;
    }

    private Result CanSell(Product2 product) =>
        this.Products.Contains(product) && product.NonNull().Stock > 0
            ? Result.Ok()
            : (Result)new ErrorResult("product.not.available", "Product not available");
}