namespace DesignPatterns.Creational.Builder.Advanced;

public class FinalPersonBuilder : IPersonBuilder
{
    public FinalPersonBuilder(string name, string surname, IContact primaryContact,
                                IEnumerable<IContact> otherContacts)
    {
        this.Name = name;
        this.Surname = surname;
        this.PrimaryContact = primaryContact;
        this.OtherContacts = otherContacts;
    }

    private string Name { get; }
    
    private string Surname { get; }
    
    private IContact PrimaryContact { get; }

    private IEnumerable<IContact> OtherContacts { get; }
    

    public IPerson Build()
    {
        IPerson person = new Person(this.Name, this.Surname, this.PrimaryContact);

        foreach (IContact contact in this.OtherContacts)
            person.AddContact(contact);

        return person;
    }
}