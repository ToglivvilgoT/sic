static class Intervals
{
    public static readonly IInterval[] intervals = [
        new PerfectAbsoluteInterval("1"),
        new NonPerfectAbsoluteInterval("2m"),
        new NonPerfectAbsoluteInterval("2M"),
        new NonPerfectAbsoluteInterval("2aug"),
        new NonPerfectAbsoluteInterval("3m"),
        new NonPerfectAbsoluteInterval("3M"),
        new PerfectAbsoluteInterval("4"),
        new PerfectAbsoluteInterval("4aug"),
        new PerfectAbsoluteInterval("5dim"),
        new PerfectAbsoluteInterval("5"),
        new NonPerfectAbsoluteInterval("6m"),
        new NonPerfectAbsoluteInterval("6M"),
        new NonPerfectAbsoluteInterval("7m"),
        new NonPerfectAbsoluteInterval("7M"),
        new PerfectAbsoluteInterval("8"),
    ];

    public static AbsoluteInterval GetAbsoluteInterval(string interval)
    {
        int intervalLength = (interval[0] - '0') % 7;
        if (intervalLength == 1 || intervalLength == 4 || intervalLength == 5)
        {
            return new PerfectAbsoluteInterval(interval);
        }
        else
        {
            return new NonPerfectAbsoluteInterval(interval);
        }
    }

    public static IEnumerable<AbsoluteInterval> GetAbsoluteIntervals(string intervals)
    {
        return intervals.Split(',').Select(GetAbsoluteInterval);
    }
}