using System.Diagnostics.CodeAnalysis;

namespace NullableReferences;

public class DisallowNullAtr
{
}

public interface IEqualityComparerFake<in T>
{
    bool Equals(T? x, T? y);

    int GetHashCode([DisallowNull] T obj);
}

public class Coder : IEqualityComparerFake<Coder?> 
{
    public bool Equals(Coder? x, Coder? y)
    {
        throw new NotImplementedException();
    }

    public int GetHashCode(Coder obj)
    {
        throw new NotImplementedException();
    }

    // The GetHashCode method here indicates that it does not accept nulls. So even if we instantiate this as IEqualityComparer<SomeClass?>,
    // the effective signature of GetHashCode makes the argument type SomeClass (i.e., non-nullable) and not the SomeClass? (nullable) specified in the generic type argument
    // public int GetHashCode(Coder? obj)
    // {
    //      throw new NotImplementedException();
    // }
}