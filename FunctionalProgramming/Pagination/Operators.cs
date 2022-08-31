namespace FunctionalProgramming.Pagination;

public static class Operators
{
    public static IPaginated<T> Paginate<T>(
        this IEnumerable<T> sequence, IComparer<T> comparer, int pageSize) =>
        new SortedListPaginator<T>(sequence, comparer, pageSize);
}
