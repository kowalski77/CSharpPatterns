namespace DesignPatterns.Creational.Builder.Advanced;

public class ExpectSurname : IExpectSurnamePersonBuilder
{
    private readonly string name;

    public ExpectSurname(string name)
    {
        this.name = name;
    }

    public IExpectPrimaryContactPersonBuilder WithSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname))
            throw new ArgumentException(null, nameof(surname));
        
        return new ExpectPrimaryContact(this.name, surname);
    }
}