namespace DesignPatterns.Iterator;

public class PersonService
{
    private readonly PersonRepository personRepository = new();

    public IEnumerable<Person> GetPeople()
    {
        var firstList = this.personRepository.GetPeopleFirstList();
        using var firstListEnumerator = firstList.GetEnumerator();
        while (firstListEnumerator.MoveNext())
        {
            yield return firstListEnumerator.Current;
            while (firstListEnumerator.MoveNext()) yield return firstListEnumerator.Current;
            yield break;
        }

        foreach (var person in this.personRepository.GetPeopleSecondList()) yield return person;
    }
}
