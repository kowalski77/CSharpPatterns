namespace FunctionalProgramming.Models;

public class SaleItem
{
    public SaleItem(Money cost, Guid assignedToProduct, DateTime saleTime)
    {
        this.Cost = cost;
        this.AssignedToProduct = assignedToProduct;
        this.SaleTime = saleTime;
    }

    public Money Cost { get; }

    public Guid AssignedToProduct { get; }
    
    public DateTime SaleTime { get; }

    public override string ToString() => $"{this.SaleTime:HH:MM}: product {this.Cost}";
}
