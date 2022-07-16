namespace DesignPatterns.Creational.Prototype;

public class Identifier
{
    public int Id { get; set; }

    public Identifier(int id)
    {
        this.Id = id;
    }
}
// ShallowCopy
//Copy of primitive type values
//Complex type values will be shared
//across clones
