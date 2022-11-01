namespace DesignPatterns.Creational.Builder.Advanced;

public interface IContact
{
}

public class PhoneNumber : IContact
{
    public PhoneNumber(string areaCode, string number)
    {
        if (string.IsNullOrEmpty(areaCode))
            throw new ArgumentException(null, nameof(areaCode));

        if (string.IsNullOrEmpty(number))
            throw new ArgumentException(null, nameof(number));
        // ... more validation, e.g. regular expression

        this.AreaCode = areaCode;
        this.Number = number;
    }

    public string AreaCode { get; }

    public string Number { get; }
}

public class EmailAddress : IContact
{
    public EmailAddress(string address)
    {

        if (string.IsNullOrEmpty(address))
            throw new ArgumentException(null, nameof(address));
        // ... more validation, e.g. regular expression

        this.Address = address;
    }

    public string Address { get; }
}
