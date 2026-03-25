namespace Sic.Models.Music;

/// <summary>
/// Represents a musical duration, like a whole note or a dotted quarter note etc.
/// </summary>
public struct Duration : IEquatable<Duration>
{
    private Fraction Length { get; set; }

    /// <summary>
    /// Create a new Duration with length: beats / divisions
    /// </summary>
    /// <param name="beats">how many beats the duration lasts.</param>
    /// <param name="divisions">how many beats a bar is divided into.</param>
    /// <exception cref="ArgumentException">If divisions is zero or negative or beats is negative</exception>
    /// <remarks>
    /// <code>
    /// Duration(1, 1)  // Duration of a whole note
    /// Duration(1, 4)  // Duration of a quarter note
    /// Duration(3, 4)  // Duration of a dotted half note
    /// </code>
    /// </remarks>
    public Duration(int beats, int divisions)
    {
        if (divisions <= 0)
        {
            throw new ArgumentException("divisions must be a positive integer");
        } 
        else if (beats < 0)
        {
            throw new ArgumentException("beats must be zero or a positive integer");
        }

        Length = new Fraction(beats, divisions);
    }

    /// <summary>
    /// Create a new Duration from a given fraction.
    /// </summary>
    private Duration(Fraction fraction)
    {
        Length = fraction;
    }

    /// <summary>
    /// Returns how long the duration is in seconds.
    /// </summary>
    /// <param name="bpm">Beats per minute</param>
    public readonly double GetTime(double bpm)
    {
        const int beatsPerWholeNote = 4;
        const int secondsPerMinute = 60;

        double secondsPerBeat = secondsPerMinute / bpm;
        double secondsPerWholeNote = beatsPerWholeNote * secondsPerBeat;

        return Length.AsDouble() * secondsPerWholeNote;
    }

    /// <inheritdoc/>
    public readonly bool Equals(Duration other)
    {
        return Length == other.Length;
    }

    /// <summary>
    /// Compare if two Durations are equal in length.
    /// </summary>
    /// <remarks>
    /// Note that this will be true:
    /// <code>new Duration(1, 2) == new Duration(2, 4)</code>
    /// </remarks>
    public static bool operator ==(Duration a, Duration b) {
        return a.Equals(b);
    }

    /// <summary>
    /// Compare if two Durations are not equal in length.
    /// </summary>
    public static bool operator !=(Duration a, Duration b) {
        return !a.Equals(b);
    }

    /// <summary>
    /// Combine two Durations.
    /// </summary>
    public static Duration operator +(Duration a, Duration b)
    {
        Fraction sum = a.Length + b.Length;
        return new(sum);
    }

    /// <inheritdoc/>
    public override readonly string ToString()
    {
        return Length.ToString();
    }

    /// <inheritdoc/>
    public override readonly bool Equals(object? obj)
    {
        return obj is Duration duration && Equals(duration);
    }

    /// <inheritdoc/>
    public override readonly int GetHashCode()
    {
        return Length.GetHashCode();
    }
}