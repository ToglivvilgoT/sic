using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Melodies;

public class IntervalMelody : IMelody
{
    private Note Root { get; }
    private List<AbsoluteInterval> Intervals { get; }
    private Rhythm MelodyRythm { get; }

    public IntervalMelody(Note root, IEnumerable<AbsoluteInterval> intervals, Rhythm rythm)
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