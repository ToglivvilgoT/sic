using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Melodies;

public class IntervalMelody : IMelody
{
    private Tone Root { get; }
    private List<AbsoluteInterval> Intervals { get; }
    private Rhythm MelodyRythm { get; }

    public IntervalMelody(Tone root, IEnumerable<AbsoluteInterval> intervals, Rhythm rythm)
    {
        Root = root;
        Intervals = [.. intervals];
        MelodyRythm = rythm;
        if (Intervals.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("Length of intervals and rythm.Durations must be equal.");
        }
    }
}