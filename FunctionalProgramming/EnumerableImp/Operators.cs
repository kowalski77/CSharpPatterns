namespace FunctionalProgramming.EnumerableImp;

public static class Operators
{
    public static MoneyBag ToMoneyBag(this IEnumerable<Money> moneys) => new(moneys);
}
