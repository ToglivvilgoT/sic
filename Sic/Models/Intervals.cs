static class Intervals
{
    public static readonly IInterval[] intervals = {
        new PerfectInterval("1"),
        new NonPerfectInterval("2m"),
        new NonPerfectInterval("2M"),
        new NonPerfectInterval("2aug"),
        new NonPerfectInterval("3m"),
        new NonPerfectInterval("3M"),
        new PerfectInterval("4"),
        new PerfectInterval("4aug"),
        new PerfectInterval("5dim"),
        new PerfectInterval("5"),
        new NonPerfectInterval("6m"),
        new NonPerfectInterval("6M"),
        new NonPerfectInterval("7m"),
        new NonPerfectInterval("7M"),
        new PerfectInterval("8"),
    };
}