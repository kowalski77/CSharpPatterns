namespace Playground.Instantiate;

// Immutable, cannot update properties without creating a new instance
// For classes that does not want the ceremony on the constructor passing all the arguments.
// init initialization
public class CommonPerson
{
    public CommonPerson(string name = "", int age = 0)
    {
        this.Name = name;
        this.Age = age;
    }

    // Copy constructor instead With... approach
    public CommonPerson(CommonPerson other)
        : this(other.Name, other.Age)
    {
    }

    public string Name { get; init; }

    public int Age { get; init; }

    // 1 drawback of With... approach: calling the constructor in many places inside the class itself
    // If a new constructor parameter were added later, then we would have to modify all existing With
    public CommonPerson WithName(string name) => new(name, this.Age);

    // 2 drawback  of With... We can only change one property in one call. To modify several properties at once,
    // we would have to change as many separate method calls and sustain construction of equally many new objects
    public CommonPerson WithAge(int age) => new(this.Name, age);
}

public class Runner
{
    public void Run()
    {
        var commonPerson = new CommonPerson
        {
            Age = 31, Name = "Tim"
        };
    }
}