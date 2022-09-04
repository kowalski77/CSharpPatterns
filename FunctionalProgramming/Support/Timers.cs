namespace FunctionalProgramming.Support;

public static class Timers
{
    public static IEnumerable<TimeSpan> GetRandomTimeSpans(TimeSpan from, TimeSpan to) =>
        ReplicatingOperators.GetRandomDoubleValues(from.TotalMilliseconds, to.TotalMilliseconds)
            .Select(TimeSpan.FromMilliseconds);

    public static IEnumerable<DateTime> GetRandomDateTimes(
        DateTime begin, TimeSpan averageStep, TimeSpan wavePeriod)
    {
        var current = TimeSpan.Zero;
        foreach (var rnd in ReplicatingOperators.GetRandomDoubleValues(.3, 1.7))
        {
            var position = current.TotalSeconds / wavePeriod.TotalSeconds;
            position -= (int)position;

            var angle = 2 * Math.PI * position;
            var relativeStep = ((Math.Cos(angle) + 1) / 2) + .5;
            var stepSeconds = relativeStep * averageStep.TotalSeconds;

            var condensingFactor = position <= .9 ? (3 + (10 * position)) / 6 : 15.5 - (15 * position);

            var step = TimeSpan.FromSeconds(rnd * stepSeconds * condensingFactor);
            current += step;
            yield return begin + current;
        }
    }

    public static IEnumerable<DateTime> GetUniformTimestamps(DateTime start, TimeSpan step)
    {
        var current = start;
        while (true)
        {
            yield return current;
            current += step;
        }
    }
}
