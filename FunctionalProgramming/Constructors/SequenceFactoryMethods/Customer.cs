using FunctionalProgramming.Guards;

namespace FunctionalProgramming.Constructors.SequenceFactoryMethods;

public class Customer
{
    public Customer(string name, decimal credit)
    {
        this.Name = name;
        this.Credit = credit;
    }

    public string Name { get; }

    public decimal Credit { get; }

    public bool CanAfford(Order order) => this.Credit >= order.NonNull().Total;

    public OrderPurchase Purchase(Order order)
    {
        if (!this.CanAfford(order))
        {
            throw new ArgumentException("Insufficient credit");
        }
        
        return new(this, order);
    }
}
