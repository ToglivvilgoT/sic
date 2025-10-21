using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Melodies;

public class ScaleMelody : IMelody
{
    private Scale MelodyScale { get; set; }
    private List<RelativeInterval> Intervals { get; set; }
    private Rhythm MelodyRhythm { get; }
    public ScaleMelody(Scale scale, IEnumerable<RelativeInterval> intervals, Rhythm rhythm)
    {
        MelodyScale = scale;
        Intervals = [.. intervals];
        MelodyRhythm = rhythm;
        if (Intervals.Count != MelodyRhythm.Durations.Count)
        {
            throw new ArgumentException("Length of intervals and rhythm. Durations must be equal.");
        }
    }
}