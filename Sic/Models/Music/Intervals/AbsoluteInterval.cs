namespace Sic.Models.Music.Intervals;

/// <summary>
/// Represents an absolute interval like "a minor third" or "a perfect fifth"
/// </summary>
public record AbsoluteInterval {
    /// <summary>
    /// The relative interval of this interval.
    /// </summary>
    public RelativeInterval Interval { get; }

    /// <summary>
    /// The type of this interval.
    /// </summary>
    public IntervalType Type { get; }

    /// <summary>
    /// Create a new interval from a RelativeInterval and its type.
    /// </summary>
    /// <exception cref="ArgumentException">Throws if the given interval is incompatible with type.</exception>
    public AbsoluteInterval(RelativeInterval interval, IntervalType type)
    {
        if ((interval.Kind & type.GetKind()) == 0)
        {
            throw new ArgumentException("Provided interval (" + interval + ") and type (" + type + ") are not compatible.");
        }
        Interval = interval;
        Type = type;
    }

    /// <summary>
    /// Create an absolute interval from a string with format "{step}[type]",
    /// where step is a digit from 0 to 6 and
    /// type is optional and can be "m", "M", "dim" or "aug",
    /// if left out "M" for major is used.
    /// </summary>
    public static AbsoluteInterval FromString(string interval)
    {
        int step = int.Parse(interval[..1]);
        RelativeInterval relativeInterval = new(step);
        IntervalType intervalType = IntervalTypeMethods.FromString(interval[1..]);
        return new AbsoluteInterval(relativeInterval, intervalType);
    }

    /// <summary>
    /// Parse multiple comma separated intervals.
    /// See <see cref="FromString"/> for how parsing of intervals work.
    /// </summary>
    public static IEnumerable<AbsoluteInterval> MultipleFromString(string intervals)
    {
        return intervals.Split(',').Select(FromString);
    }

    /// <summary>
    /// Get semitones of this interval.
    /// </summary>
    public int GetSemitones()
    {
        return Interval.GetSemitones() + Interval.Direction * Type.GetSemitones(Interval.Kind);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Type + " " + Interval;
    }
}