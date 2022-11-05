namespace FunctionalProgramming.Constructors.SequenceFactoryMethods;

public class OrderPurchase
{
    public OrderPurchase(Customer customer, Order order)
    {
        this.Customer = customer;
        this.Order = order;
    }

    public Customer Customer { get; }
    
    public Order Order { get; }
}
