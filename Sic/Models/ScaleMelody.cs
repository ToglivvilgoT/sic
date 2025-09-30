using Sic.Models.Intervals;

namespace Sic.Models;

class ScaleMelody : IMelody
{
    private Scale MelodyScale { get; set; }
    private List<RelativeInterval> Intervals { get; set; }
    private Rythm MelodyRythm { get; }
    public ScaleMelody(Scale scale, IEnumerable<RelativeInterval> intervals, Rythm rythm)
    {
        MelodyScale = scale;
        Intervals = [.. intervals];
        MelodyRythm = rythm;
        if (Intervals.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("Length of intervals and rythm.Durations must be equal.");
        }
    }
}