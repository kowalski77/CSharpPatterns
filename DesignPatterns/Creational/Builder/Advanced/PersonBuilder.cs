namespace DesignPatterns.Creational.Builder.Advanced;

public static class PersonBuilder
{
    public static IExpectSurnamePersonBuilder WithName(string name) =>
        string.IsNullOrEmpty(name) ?
            throw new ArgumentException(null, nameof(name)) :
            new ExpectSurname(name);
}
