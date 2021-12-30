namespace ADS.DataStructures.Lists.Extensions;

internal static class EnumerableExtensions
{
    public static void ForEach<T>(this IEnumerable<T> values, Action<T> action)
    {
        foreach (var value in values)
            action(value);
    }
}