namespace DesignPatterns.Iterator;

public class PersonRepository
{
    private static readonly IEnumerable<Person> peopleFirstList = new List<Person>
    {
        new Person { Name = "John", Age = 42 },
        new Person { Name = "Jane", Age = 39 },
        new Person { Name = "Joe", Age = 17 }
    };

    private static readonly IEnumerable<Person> peopleSecondList = new List<Person>
    {
        new Person { Name = "Mary", Age = 23 },
        new Person { Name = "Mike", Age = 19 },
        new Person { Name = "Molly", Age = 21 }
    };

    public IEnumerable<Person> GetPeopleFirstList() => peopleFirstList;

    public IEnumerable<Person> GetPeopleSecondList() => peopleSecondList;
}
