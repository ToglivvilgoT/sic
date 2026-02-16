using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Chords;

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
            "m" => [.. AbsoluteInterval.MultipleFromString("0,2m,4")],
            "M" => [.. AbsoluteInterval.MultipleFromString("0,2M,4")],
            "dim" => [.. AbsoluteInterval.MultipleFromString("0,2m,4dim")],
            "aug" => [.. AbsoluteInterval.MultipleFromString("0,2M,4aug")],
            _ => throw new ArgumentException("Chord not supported.")
        };
    }

    public override string ToString()
    {
        return string.Join(',', ChordIntervals);
    }
}