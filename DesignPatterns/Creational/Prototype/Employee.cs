namespace DesignPatterns.Creational.Prototype;

public class Employee
{
    public string? Name { get; set; }

    public string? Department { get; set; }

    public Identifier? Identifier { get; set; }

    public Employee Clone()
    {
        return (Employee)this.MemberwiseClone();
    }
}
// ShallowCopy
//Copy of primitive type values
//Complex type values will be shared
//across clones
