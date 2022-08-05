namespace DesignPatterns.Structural.Bridge;

public abstract class InvoiceBuilder
{
    protected InvoiceBuilder(IInvoiceParser invoiceParser)
    {
        this.InvoiceParser = invoiceParser;
    }
    
    public IInvoiceParser InvoiceParser { get; }

    public abstract string BuildHeader();

    public abstract string BuildCustomer();

    public abstract string BuildOrder();
}

public class SimpleInvoiceBuilder : InvoiceBuilder
{
    public SimpleInvoiceBuilder(IInvoiceParser invoiceParser) : base(invoiceParser)
    {
    }

    public override string BuildHeader()
    {
        return this.InvoiceParser.ParseHeader(new Header("Invoice"));
    }

    public override string BuildCustomer()
    {
        return this.InvoiceParser.ParseCustomer(new Customer("John Doe"));
    }

    public override string BuildOrder()
    {
        return this.InvoiceParser.ParseOrder(new Order("Order 1"));
    }
}
