namespace DesignPatterns.Creational.Builder.Advanced;

public interface IExpectSurnamePersonBuilder
{
    IExpectPrimaryContactPersonBuilder WithSurname(string surname);
}

public interface IExpectPrimaryContactPersonBuilder
{
    IExpectOtherContactsPersonBuilder WithPrimaryContact(IContact contact);
}

public interface IExpectOtherContactsPersonBuilder
{
    IExpectOtherContactsPersonBuilder WithOtherContact(IContact contact);
    
    IPersonBuilder WithNoMoreContacts();
}

public interface IPersonBuilder
{
    IPerson Build();
}
