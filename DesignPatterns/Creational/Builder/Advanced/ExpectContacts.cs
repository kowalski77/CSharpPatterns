namespace DesignPatterns.Creational.Builder.Advanced;

public abstract class ExpectContacts : IExpectOtherContactsPersonBuilder
{
    public abstract IExpectOtherContactsPersonBuilder WithOtherContact(IContact contact);

    public abstract Tuple<string, string, IContact> GetMandatoryData();

    public abstract void ForEachContact(Action<IContact> action);

    public IPersonBuilder WithNoMoreContacts()
    {
        var (name, surname, primaryContact) = this.GetMandatoryData();
    
        IList<IContact> otherContacts = new List<IContact>();
        this.ForEachContact(otherContacts.Add);

        return new FinalPersonBuilder(name, surname, primaryContact, otherContacts);
    }
}
