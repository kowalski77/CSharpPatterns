namespace FunctionalProgramming.Constructors.SequenceFactoryMethodsWithResult;

public class OrderPurchase2
{
    public OrderPurchase2(Customer2 customer, Order2 order)
    {
        this.Customer = customer;
        this.Order = order;
    }

    public Customer2 Customer { get; }

    public Order2 Order { get; }
}
