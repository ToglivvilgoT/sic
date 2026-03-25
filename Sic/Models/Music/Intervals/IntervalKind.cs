namespace Sic.Models.Music.Intervals;

/// <summary>
/// Represents the type of a IntervalType.
/// Unison, forth, fifth and octave are perfect intervals
/// since they can be diminished, perfect or augmented.
/// Second, third, sixth and seventh are non perfect intervals
/// since they can be diminished, minor, major or augmented.
/// </summary>
[Flags]
public enum IntervalKind
{
    /// <summary>
    /// This is the kind of unisons, forth, fifths and octaves.
    /// </summary>
    Perfect = 1,

    /// <summary>
    /// This is the kind of seconds, thirds, sixths and sevenths.
    /// </summary>
    NonPerfect = 2,
}

/// <summary>
/// Methods for IntervalKinds.
/// </summary>
public static class IntervalKindMethods
{
    /// <summary>
    /// Return the IntervalKind of the interval with size semitones.
    /// E.g. FromSemitones(2) returns NonPerfect since 2 semitones is a major second and the second is a NonPerfect interval.
    /// FromSemitones(7) returns Perfect since 7 semitones is a perfect fifth and the fifth is a Perfect interval. 
    /// </summary>
    public static IntervalKind FromSemitones(int semitones)
    {
        semitones = Math.Abs(semitones) % 12; // "Normalize" the interval to be in one (positive) octave.
        bool isUnison = semitones == 0;
        bool isFourthOrFifth = semitones >= 5 && semitones <= 7;
        if (isUnison || isFourthOrFifth)
        {
            return IntervalKind.Perfect;
        }
        else
        {
            return IntervalKind.NonPerfect;
        }
    }
}