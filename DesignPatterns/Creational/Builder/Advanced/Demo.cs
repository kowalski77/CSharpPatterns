namespace DesignPatterns.Creational.Builder.Advanced;

public class Demo
{
    public void Run()
    {
        IPerson person =
            PersonBuilder
                .WithName("Max")
                .WithSurname("Planck")
                .WithPrimaryContact(new EmailAddress("max@planck.institute"))
                .WithOtherContact(new EmailAddress("max@houseof.planck"))
                .WithOtherContact(new PhoneNumber("011", "12345"))
                .WithNoMoreContacts()
                .Build();
    }
}
