namespace Sic.Models.Music.Intervals;

/// <summary>
/// Represents the type of an interval.
/// </summary>
public enum IntervalType
{
    /// <summary>
    /// Diminished.
    /// </summary>
    Diminished,

    /// <summary>
    /// Minor.
    /// </summary>
    Minor,

    /// <summary>
    /// Perfect i.e. unchanged
    /// </summary>
    Perfect,

    /// <summary>
    /// Major.
    /// </summary>
    Major,

    /// <summary>
    /// Augmented.
    /// </summary>
    Augmented,
}

/// <summary>
/// Methods for IntervalTypes.
/// </summary>
public static class IntervalTypeMethods
{
    /// <summary>
    /// Gets the semitones of this interval.
    /// </summary>
    /// <param name="interval">This interval.</param>
    /// <param name="kind">The kind of this interval.</param>
    /// <exception cref="ArgumentException">If the kind and interval are incompatible (e.g. a Perfect second)</exception>
    public static int GetSemitones(this IntervalType interval, IntervalKind kind)
    {
        if (kind == IntervalKind.Perfect)
        {
            return interval switch
            {
                IntervalType.Diminished => -1,
                IntervalType.Minor => throw new ArgumentException("a perfect interval can't be minor"),
                IntervalType.Perfect => 0,
                IntervalType.Major => throw new ArgumentException("a perfect interval can't be major"),
                IntervalType.Augmented => 1,
                _ => throw new ArgumentException("Unsupported IntervalType"),
            };
        }
        else
        {
            return interval switch
            {
                IntervalType.Diminished => -2,
                IntervalType.Minor => -1,
                IntervalType.Perfect => throw new ArgumentException("a non perfect interval can't be perfect"),
                IntervalType.Major => 0,
                IntervalType.Augmented => 1,
                _ => throw new ArgumentException("Unsupported IntervalType"),
            };
        }
    }

    /// <summary>
    /// Get the kind of this interval.
    /// Can return both kinds for e.g. diminished and augmented since they can be both Perfect or NonPerfect.
    /// There for, don't use comparison like <code>GetKind(type) == IntervalKind.Perfect</code>
    /// but instead use binary and operator like <code>GetKind(type) &amp; IntervalKind.Perfect</code> 
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    /// <exception cref="ArgumentException"></exception>
    public static IntervalKind GetKind(this IntervalType type)
    {
        return type switch
        {
            IntervalType.Perfect => IntervalKind.Perfect,
            IntervalType.Minor => IntervalKind.NonPerfect,
            IntervalType.Major => IntervalKind.NonPerfect,
            IntervalType.Diminished => IntervalKind.Perfect | IntervalKind.NonPerfect,
            IntervalType.Augmented => IntervalKind.Perfect | IntervalKind.NonPerfect,
            _ => throw new ArgumentException("type is not a valid IntervalType")
        };
    }

    /// <inheritdoc/>
    public static IntervalType FromString(string intervalType)
    {
        return intervalType switch
        {
            "dim" => IntervalType.Diminished,
            "m" => IntervalType.Minor,
            "" => IntervalType.Perfect,
            "M" => IntervalType.Major,
            "aug" => IntervalType.Augmented,
            _ => throw new ArgumentException("provided intervalType did not match any IntervalType")
        };
    }
}