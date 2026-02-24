using Sic.Models.Music.Intervals;

namespace SicTests.Models.Music.Intervals;

[Parallelizable(scope: ParallelScope.All)]
public class RelativeIntervalTests
{
    [TestCase(0, ExpectedResult = 0)]
    [TestCase(6, ExpectedResult = 0)]
    [TestCase(-6, ExpectedResult = 0)]
    [TestCase(7, ExpectedResult = 1)]
    [TestCase(-7, ExpectedResult = 1)]
    [TestCase(13, ExpectedResult = 1)]
    [TestCase(-13, ExpectedResult = 1)]
    [TestCase(14, ExpectedResult = 2)]
    [TestCase(-14, ExpectedResult = 2)]
    public int TestGetOctaves(int steps)
    {
        RelativeInterval interval = new(steps);
        return interval.Octaves;
    }

    [TestCase(0, ExpectedResult = 0)]
    [TestCase(6, ExpectedResult = 6)]
    [TestCase(-6, ExpectedResult = 6)]
    [TestCase(7, ExpectedResult = 0)]
    [TestCase(-7, ExpectedResult = 0)]
    [TestCase(13, ExpectedResult = 6)]
    [TestCase(-13, ExpectedResult = 6)]
    [TestCase(14, ExpectedResult = 0)]
    [TestCase(-14, ExpectedResult = 0)]
    public int TestGetInterval(int steps)
    {
        RelativeInterval interval = new(steps);
        return interval.Interval;
    }

    [TestCase(0, ExpectedResult = 0)]
    [TestCase(1, ExpectedResult = 1)]
    [TestCase(4, ExpectedResult = 1)]
    [TestCase(17, ExpectedResult = 1)]
    [TestCase(-1, ExpectedResult = -1)]
    [TestCase(-5, ExpectedResult = -1)]
    [TestCase(-19, ExpectedResult = -1)]
    public int TestGetDirection(int steps)
    {
        RelativeInterval interval = new(steps);
        return interval.Direction;
    }

    [Test]
    public void TestGetPerfectInterval(
        [Values(0, 3, 4)] int interval,
        [Range(-2, 2, 1)] int octaves,
        [Values(-1, 1)] int direction
    )
    {
        int steps = (interval + 7 * octaves) * direction;
        RelativeInterval relativeInterval = new(steps);

        IntervalKind kind = relativeInterval.Kind;

        Assert.That(kind, Is.EqualTo(IntervalKind.Perfect));
    }

    [Test]
    public void TestGetNonPerfectInterval(
        [Values(1, 2, 5, 6)] int interval,
        [Range(-2, 2, 1)] int octaves,
        [Values(-1, 1)] int direction
    )
    {
        int steps = (interval + 7 * octaves) * direction;
        RelativeInterval relativeInterval = new(steps);

        IntervalKind kind = relativeInterval.Kind;

        Assert.That(kind, Is.EqualTo(IntervalKind.NonPerfect));
    }

    [TestCase(0, 0)]
    [TestCase(2, 4)]
    [TestCase(7, 12)]
    [TestCase(8, 14)]
    public void TestGetSemitones(int steps, int expected)
    {
        RelativeInterval intervalUp = new(steps);
        RelativeInterval intervalDown = new(-steps);

        int semitonesUp = intervalUp.GetSemitones();
        int semitonesDown = intervalDown.GetSemitones();

        Assert.Multiple(() =>
        {
            Assert.That(semitonesUp, Is.EqualTo(expected));
            Assert.That(semitonesDown, Is.EqualTo(-expected));
        });
    }
}