namespace DesignPatterns.Structural.Bridge;


public interface IInvoiceParser
{
    string ParseHeader(Header header);

    string ParseCustomer(Customer customer);

    string ParseOrder(Order order);
}

public class DeliverNoteParser : IInvoiceParser
{
    public string ParseCustomer(Customer customer)
    {
        return $"Delivery note customer: {customer}";
    }

    public string ParseHeader(Header header)
    {
        return $"Delivery note header: {header}";
    }

    public string ParseOrder(Order order)
    {
        return $"Delivery note order: {order}";
    }
}

public class ClientInvoiceParser : IInvoiceParser
{
    public string ParseHeader(Header header)
    {
        return $"ClientInvoice header: {header}";
    }

    public string ParseCustomer(Customer customer)
    {
        return $"ClientInvoice customer: {customer}";
    }

    public string ParseOrder(Order order)
    {
        return $"ClientInvoice order: {order}";
    }
}
