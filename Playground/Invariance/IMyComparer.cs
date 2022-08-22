namespace Playground.Invariance;

public interface IMyComparer<in T>
{
    int Compare(T x, T y);
}

public class PersonComparer : IMyComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        return string.CompareOrdinal(x.Name, y.Name);
    }
}