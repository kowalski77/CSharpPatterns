using System.Text.Json;

namespace DesignPatterns.Creational.Prototype;

public abstract class Person
{
    public Identifier? Identifier { get; set; }
    
    public abstract string? Name { get; set; }

    public abstract Person Clone(bool deepClone);
}

public class Manager : Person
{
    public override string? Name { get; set; }

    public override Person Clone(bool deepClone)
    {
        if (deepClone)
        {
            var objectAsJson = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<Manager>(objectAsJson)!;
        }

        return (Person)this.MemberwiseClone();
    }
}

// Deep Copy
//Copy of primitive type values and
//complex type values

