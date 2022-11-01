namespace DesignPatterns.Creational.Builder.Advanced;

public class ExpectFirstContact : ExpectContacts
{
    public ExpectFirstContact(string name, string surname, IContact primaryContact)
    {
        this.Name = name;
        this.Surname = surname;
        this.PrimaryContact = primaryContact;
    }

    private string Name { get; }

    private string Surname { get; }
    
    private IContact PrimaryContact { get; }
    

    public override IExpectOtherContactsPersonBuilder WithOtherContact(IContact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);
        
        return new ExpectMoreContacts(this, contact);
    }

    public override Tuple<string, string, IContact> GetMandatoryData()
    {
        return Tuple.Create(this.Name, this.Surname, this.PrimaryContact);
    }

    public override void ForEachContact(Action<IContact> action)
    {
    }
}
