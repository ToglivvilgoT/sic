using Sic.Models.Intervals;

namespace SicTests.Models.Intervals;

[TestClass]
public class AbsoluteIntervalTests {

    [TestMethod]
    public void TestConstructor()
    {
        RelativeInterval[] perfectIntervals = [.. new[] { 0, 3, 4, 7,  }.Select(n => new RelativeInterval(n))];
        RelativeInterval[] nonPerfectIntervals = [new(1), new(2), new()];
        IntervalType validType = IntervalType.Perfect;
    }
    public AbsoluteInterval(RelativeInterval interval, IntervalType type)
    {
        if ((interval.Kind & type.GetKind()) == 0)
        {
            throw new ArgumentException("Provided interval and type are not compatible.");
        }
        Interval = interval;
        Type = type;
    }

    public static AbsoluteInterval FromString(string interval)
    {
        int step = int.Parse(interval[..1]);
        RelativeInterval relativeInterval = new(step);
        IntervalType intervalType = IntervalTypeMethods.FromString(interval[1..]);
        return new AbsoluteInterval(relativeInterval, intervalType);
    }

    public static IEnumerable<AbsoluteInterval> MultipleFromString(string intervals)
    {
        return intervals.Split(',').Select(FromString);
    }

    public int GetSemitones()
    {
        return Interval.GetSemitones() + Type.GetSemitones(Interval.Kind);
    }
}