namespace Playground.Invariance;

public interface IPersonReadOnlyCollection<out T>
{
    T GetFirstElement();
}

public class PersonReadOnlyCollection<T> : IPersonReadOnlyCollection<T>
{
    public PersonReadOnlyCollection(IEnumerable<T> people)
    {
        this.Values = new List<T>(people);
    }

    private List<T> Values { get; }
    
    public T GetFirstElement()
    {
        return this.Values.First();
    }
}
