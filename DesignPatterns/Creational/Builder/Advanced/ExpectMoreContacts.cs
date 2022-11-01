namespace DesignPatterns.Creational.Builder.Advanced;

public class ExpectMoreContacts : ExpectContacts
{
    public ExpectMoreContacts(ExpectContacts predecessor, IContact contact)
    {
        this.Predecessor = predecessor;
        this.Contact = contact;
    }

    private ExpectContacts Predecessor { get; }
    
    private IContact Contact { get; }

    public override IExpectOtherContactsPersonBuilder WithOtherContact(IContact contact)
    {
        ArgumentNullException.ThrowIfNull(contact);
        
        return new ExpectMoreContacts(this, contact);
    }

    public override Tuple<string, string, IContact> GetMandatoryData()
    {
        return this.Predecessor.GetMandatoryData();
    }

    public override void ForEachContact(Action<IContact> action)
    {
        ArgumentNullException.ThrowIfNull(action);

        this.Predecessor.ForEachContact(action);
        action(this.Contact);
    }
}