using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Chords;

/// <summary>
/// Represents a Chord.
/// </summary>
public class Chord
{
    /// <summary>
    /// The intervals of this chord.
    /// </summary>
    public List<AbsoluteInterval> ChordIntervals { get; private set; }

    /// <summary>
    /// Construct a new chord given a set of intervals.
    /// </summary>
    /// <param name="intervals"></param>
    public Chord(IEnumerable<AbsoluteInterval> intervals)
    {
        ChordIntervals = [.. intervals];
    }

    /// <summary>
    /// Construct a new chord from a string.
    /// The string can be:
    /// "m" => a minor chord.
    /// "M" => a major chord.
    /// "dim" => a diminished chord.
    /// "aug" => an augmented chord.
    /// anything else will throw an exception.
    /// </summary>
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

    /// <inheritdoc/>
    public override string ToString()
    {
        return string.Join(',', ChordIntervals);
    }
}