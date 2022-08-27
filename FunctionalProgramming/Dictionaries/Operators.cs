using FunctionalProgramming.Models;

namespace FunctionalProgramming.Dictionaries;

public static class Operators
{
    public static MoneyBag ToMoneyBag(this IEnumerable<Money> moneys) => new(moneys);
}
