using Sic.Models.Music;
using Sic.Models.Music.Intervals;

namespace SicTests.Models.Music;

[Parallelizable(scope: ParallelScope.All)]
public class ScaleTests
{
    [TestCaseSource(nameof(ScaleContentCases))]
    public void TestScaleContent((Scale, AbsoluteInterval[]) input)
    {
        var (scale, expectedIntervals) = input;

        foreach (var expected in expectedIntervals)
        {
            RelativeInterval interval = expected.Interval;
            var actual = scale.GetAbsoluteInterval(interval);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }

    private static IEnumerable<(Scale, AbsoluteInterval[])> ScaleContentCases()
    {
        AbsoluteInterval[] intervals = [.. AbsoluteInterval.MultipleFromString("0,1M,2M,3aug,4,5M,6M")];
        yield return (Scale.GetLydian(), (AbsoluteInterval[])intervals.Clone());

        intervals[3] = AbsoluteInterval.FromString("3");
        yield return (Scale.GetMajor(), (AbsoluteInterval[])intervals.Clone());

        intervals[6] = AbsoluteInterval.FromString("6m");
        yield return (Scale.GetMixolydian(), (AbsoluteInterval[])intervals.Clone());

        intervals[2] = AbsoluteInterval.FromString("2m");
        yield return (Scale.GetDorian(), (AbsoluteInterval[])intervals.Clone());

        intervals[5] = AbsoluteInterval.FromString("5m");
        yield return (Scale.GetMinor(), (AbsoluteInterval[])intervals.Clone());

        intervals[1] = AbsoluteInterval.FromString("1m");
        yield return (Scale.GetPhrygian(), (AbsoluteInterval[])intervals.Clone());

        intervals[4] = AbsoluteInterval.FromString("4dim");
        yield return (Scale.GetLocrian(), (AbsoluteInterval[])intervals.Clone());
    }

    [TestCase("2M",  2, IntervalType.Major)]
    [TestCase("2M",  9, IntervalType.Major)]
    [TestCase("2M", -2, IntervalType.Major)]
    [TestCase("2M", -9, IntervalType.Major)]
    public void TestOctaves(string scaleInterval, int relativeIntervalSteps, IntervalType expectedType)
    {
        Scale scale = new([AbsoluteInterval.FromString(scaleInterval)]);
        RelativeInterval relativeInterval = new(relativeIntervalSteps);
        AbsoluteInterval expected = new(relativeInterval, expectedType);

        AbsoluteInterval result = scale.GetAbsoluteInterval(relativeInterval);

        Assert.That(result, Is.EqualTo(expected));
    }
}