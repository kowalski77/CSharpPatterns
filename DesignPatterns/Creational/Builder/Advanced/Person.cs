namespace DesignPatterns.Creational.Builder.Advanced;

public interface IPerson
{
    string Name { get; }

    string Surname { get; }
    
    IContact PrimaryContact { get; }

    IList<IContact> AllContacts { get; }

    void AddContact(IContact contact);
}

public class Person : IPerson
{
    public Person(string name, string surname, IContact primaryContact)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentException(null, nameof(name));
        if (string.IsNullOrEmpty(surname))
            throw new ArgumentException(null, nameof(surname));

        this.Name = name;
        this.Surname = surname;

        this.SetPrimaryContact(primaryContact);
    }

    public string Name { get; }

    public string Surname { get; }

    public IContact PrimaryContact { get; private set; } = default!;

    public IList<IContact> AllContacts { get; } = new List<IContact>();

    public void SetPrimaryContact(IContact contact)
    {
        this.AddContact(contact);
        this.PrimaryContact = contact;
    }

    public void AddContact(IContact contact)
    {
        if (contact == null)
            throw new ArgumentNullException(nameof(contact));

        this.AllContacts.Add(contact);
    }
}
