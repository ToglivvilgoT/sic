using Sic.Models.Music;
using Sic.Models.Music.Intervals;

namespace SicTests.Models.Music;

[Parallelizable(scope: ParallelScope.All)]
public class PitchTests
{
    [Test]
    public void TestGetFrequency(
        [Range(-12, 12)] int step)
    {
        Pitch pitch = new(step);
        double expected = 440 * Math.Pow(2 * step, 1/12);
        double onePercentOfASemitone = expected * Math.Pow(2 * 0.01, 1/12);
        Assert.That(
            pitch.GetFrequency(),
            Is.EqualTo(expected)
            .Within(onePercentOfASemitone)
        );
    }

    [TestCase(-6, -4, IntervalType.Diminished)]
    [TestCase(-3, -2, IntervalType.Minor)]
    [TestCase(0, 0, IntervalType.Perfect)]
    [TestCase(4, 2, IntervalType.Major)]
    [TestCase(6, 3, IntervalType.Augmented)]
    [TestCase(7, 4, IntervalType.Perfect)]
    public void TestAddition(int step, int relativeIntervalSteps, IntervalType intervalType)
    {
        RelativeInterval relativeInterval = new(relativeIntervalSteps);
        AbsoluteInterval absoluteInterval = new(relativeInterval, intervalType);
        Pitch startPoint = new(0);

        Pitch result = startPoint + absoluteInterval;
        Pitch expected = new(step);

        Assert.That(result, Is.EqualTo(expected));
    }

    [TestCase(0)]
    [TestCase(-3)]
    [TestCase(7)]
    public void TestEquality(int step)
    {
        Pitch pitch1 = new(step);
        Pitch pitch2 = new(step);
        Pitch low = new(step - 1);
        Pitch high = new(step + 1);

        Assert.That(pitch1, Is.EqualTo(pitch2));
        Assert.That(pitch1, Is.Not.EqualTo(low));
        Assert.That(pitch1, Is.Not.EqualTo(high));
    }

    [Test]
    public void TestToStringDoesNotThrowAnException(
        [Values(0, 3, 13, -2, -15)] int step)
    {
        Pitch pitch = new(step);

        Assert.DoesNotThrow(() => {
            pitch.ToString();
        });
    }
}