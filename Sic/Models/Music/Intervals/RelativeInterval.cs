namespace Sic.Models.Music.Intervals;

/// <summary>
/// Represents a relative interval.
/// A relative interval is an interval like a third or a fifth.
/// Note that it is not known if the interval is major or diminished etc.
/// </summary>
/// <remarks>
/// steps represents the size of the interval.
/// steps = 0 is the unison.
/// steps = 3 is a forth going up.
/// steps = -2 is a third going down etc.
/// </remarks>
public class RelativeInterval(int steps)
{
    /// <summary>
    /// Step encodes interval step.
    /// 0 = Unison, 1 = Second, 2 = Third and so on.
    /// </summary>
    private int Steps { get; set; } = steps;
    /// <summary>
    /// How many octaves the interval reaches rounded down.
    /// </summary>
    public int Octaves
    {
        get { return Math.Abs(Steps) / 7; }
    }
    /// <summary>
    /// The interval size disregarding octave and direction.
    /// </summary>
    public int Interval
    {
        get { return Math.Abs(Steps) % 7; }
    }
    /// <summary>
    /// The direction of the interval. 1 = up, -1 = down.
    /// </summary>
    public int Direction
    {
        get { return Math.Sign(Steps); }
    }

    /// <summary>
    /// The kind of the interval type.
    /// </summary>
    public IntervalKind Kind
    {
        get
        {
            if (Interval == 0 || Interval == 3 || Interval == 4)
            {
                return IntervalKind.Perfect;
            }
            else
            {
                return IntervalKind.NonPerfect;
            }
        }
    }

    /// <summary>
    /// Returns the amount of semitones in the interval.
    /// Interval going down will have negative semitones.
    /// Semitones are based on the major scale.
    /// </summary>
    /// <returns> The semitones in the interval. </returns>
    public int GetSemitones()
    {
        int intervalSemitones = Interval switch
        {
            0 => 0, // Unison
            1 => 2, // Second
            2 => 4, // Third
            3 => 5, // Fourth
            4 => 7, // Fifth
            5 => 9, // Sixth
            6 => 11, // Seventh
            _ => throw new Exception("Expected Interval to be between 0 and 6.")
        };
        return (12 * Octaves + intervalSemitones) * Direction;
    }

    /// <summary>
    /// Combine the length of two intervals into a new interval.
    /// </summary>
    public static RelativeInterval operator +(RelativeInterval a, RelativeInterval b)
    {
        return new RelativeInterval(a.Steps + b.Steps);
    }

    /// <summary>
    /// Subtract the length of one interval from another interval.
    /// </summary>
    public static RelativeInterval operator -(RelativeInterval a, RelativeInterval b)
    {
        return new RelativeInterval(a.Steps - b.Steps);
    }

    /// <summary>
    /// Invert the direction of an interval
    /// </summary>
    public static RelativeInterval operator -(RelativeInterval interval)
    {
        return new RelativeInterval(-interval.Steps);
    }

    /// <inheritdoc/>
    public static bool operator ==(RelativeInterval a, RelativeInterval b)
    {
        return a.Steps == b.Steps;
    }

    /// <inheritdoc/>
    public static bool operator !=(RelativeInterval a, RelativeInterval b)
    {
        return a.Steps != b.Steps;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        string intervalString = Interval switch
        {
            0 => "Unison ",
            1 => "Second ",
            2 => "Third ",
            3 => "Fourth ",
            4 => "Fifth ",
            5 => "Sixth ",
            6 => "Seventh ",
            _ => throw new Exception("Expected Interval to be between 0 and 6.")
        };
        string octave = Octaves == 0 ? "" : "and " + Octaves.ToString() + " Octaves ";
        string direction = Direction == 1 ? "Up" : "Down";

        return intervalString + octave + direction;
    }

    /// <summary> Check if two intervals are equal </summary>
    public bool Equals(RelativeInterval? interval)
    {
        return Steps == interval?.Steps;
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as RelativeInterval);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return Steps.GetHashCode();
    }
}