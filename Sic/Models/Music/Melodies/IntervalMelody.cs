using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Melodies;

public class IntervalMelody
{
    private Pitch Root { get; }
    private List<AbsoluteInterval> Intervals { get; }
    private Rhythm MelodyRythm { get; }

    public IntervalMelody(Pitch root, IEnumerable<AbsoluteInterval> intervals, Rhythm rythm)
    {
        Root = root;
        Intervals = [.. intervals];
        MelodyRythm = rythm;
        if (Intervals.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("Length of intervals and rythm.Durations must be equal.");
        }
    }

    public IEnumerable<TimedNote> GetTimedNotes()
    {
        throw new NotImplementedException();
    }
}