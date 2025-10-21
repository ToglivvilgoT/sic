using Sic.Models.Music.Intervals;

namespace Sic.Models;

public class Chord
{
    public List<AbsoluteInterval> ChordIntervals { get; private set; }

    public Chord(IEnumerable<AbsoluteInterval> intervals)
    {
        ChordIntervals = [.. intervals];
    }

    public Chord(string chord)
    {
        ChordIntervals = chord switch
        {
            "m" => [.. AbsoluteInterval.MultipleFromString("1,3m,5")],
            "M" => [.. AbsoluteInterval.MultipleFromString("1,3M,5")],
            "dim" => [.. AbsoluteInterval.MultipleFromString("1,3m,5dim")],
            "aug" => [.. AbsoluteInterval.MultipleFromString("1,3M,5aug")],
            _ => throw new ArgumentException("Chord not supported.")
        };
    }
}