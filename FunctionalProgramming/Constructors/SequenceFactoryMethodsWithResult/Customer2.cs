using FunctionalProgramming.Guards;
using FunctionalProgramming.Results;

namespace FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;

public class Customer2
{
    public Customer2(string name, decimal credit)
    {
        this.Name = name;
        this.Credit = credit;
    }

    public string Name { get; }

    public decimal Credit { get; }

    public Result<OrderPurchase2> Purchase(Order2 order)
    {
        Result result = this.CanAfford(order);
        return result.Success ?
            new OrderPurchase2(this, order) :
            result.Error!;
    }

    private Result CanAfford(Order2 order) =>
        order.NonNull().Total < this.Credit ?
            Result.Ok() :
            new ErrorResult("insufficient.cretit", "Insufficient credit");
}
