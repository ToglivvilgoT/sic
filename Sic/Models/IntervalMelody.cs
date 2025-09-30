using Sic.Models.Intervals;

namespace Sic.Models;

class IntervalMelody : IMelody
{
    private Note Root { get; }
    private List<AbsoluteInterval> Intervals { get; }
    private Rythm MelodyRythm { get; }

    public IntervalMelody(Note root, IEnumerable<AbsoluteInterval> intervals, Rythm rythm)
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