namespace DesignPatterns.Creational.Builder.Advanced;

public class ExpectPrimaryContact : IExpectPrimaryContactPersonBuilder
{
    private readonly string name;
    private readonly string surname;

    public ExpectPrimaryContact(string name, string surname)
    {
        this.name = name;
        this.surname = surname;
    }

    public IExpectOtherContactsPersonBuilder WithPrimaryContact(IContact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);

        return new ExpectFirstContact(this.name, this.surname, contact);
    }
}