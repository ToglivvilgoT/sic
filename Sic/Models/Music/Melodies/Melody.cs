using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Melodies;

public class Melody
{
    public List<RelativeInterval> Intervals { get; }
    public Rhythm Rhythm { get; }

    public Melody(IEnumerable<RelativeInterval> intervals, Rhythm rhythm)
    {
        Intervals = [.. intervals];
        Rhythm = rhythm;
        if (Intervals.Count != Rhythm.Durations.Count)
        {
            throw new ArgumentException("Length of intervals and rhythm. Durations must be equal.");
        }
    }

    public override string ToString()
    {
        return "[" + string.Join(", ", Intervals.Zip(Rhythm.Durations).Select((inp) =>
        {
            var (interval, duration) = inp;
            return interval + ":" + duration;
        })) + "]";
    }
}