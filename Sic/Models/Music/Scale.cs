using Microsoft.VisualBasic;
using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

/// <summary>
/// Represents a musical Scale.
/// </summary>
/// <remarks>
/// A Scale in this context is a set of AbsoluteIntervals,
/// contained within an octave,
/// that must also contain the unison interval,
/// known as the root of the Scale.
/// </remarks>
public class Scale(IEnumerable<AbsoluteInterval> intervals)
{
    private AbsoluteInterval[] ScaleIntervals { get; } = [.. intervals];

    /// <summary>
    /// Given a relative interval, return all absolute intervals of that type in the scale.
    /// Note that this will always return exactly one interval for major scale and its modes.
    /// </summary>
    public AbsoluteInterval GetAbsoluteInterval(RelativeInterval relativeInterval)
    {
        return new AbsoluteInterval(
            relativeInterval,
            ScaleIntervals
                .First((interval) => interval.Interval.Interval == relativeInterval.Interval)
                .Type
        );
    }

    /// <summary>
    /// Creates and returns the Lydian Scale.
    /// The Lydian Scale is the major scale with a raised forth.
    /// </summary>
    public static Scale GetLydian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2M,3aug,4,5M,6M"));
    }

    /// <summary>
    /// /// Creates and returns the normal major Scale.
    /// </summary>
    public static Scale GetMajor()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2M,3,4,5M,6M"));
    }

    /// <summary>
    /// Creates and returns the mixolydian Scale.
    /// The mixolydian scale is like the major Scale but with a flat seventh.
    /// </summary>
    public static Scale GetMixolydian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2M,3,4,5M,6m"));
    }

    /// <summary>
    /// Creates and returns the dorian Scale.
    /// The dorian scale is like the minor Scale but with a sharp sixth.
    /// </summary>
    public static Scale GetDorian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2m,3,4,5M,6m"));
    }

    /// <summary>
    /// Creates and returns the normal minor Scale.
    /// </summary>
    public static Scale GetMinor()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2m,3,4,5m,6m"));
    }

    /// <summary>
    /// Creates and returns the phrygian Scale.
    /// The phrygian scale is like the minor Scale but with a flat second.
    /// </summary>
    public static Scale GetPhrygian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1m,2m,3,4,5m,6m"));
    }

    /// <summary>
    /// Creates and returns the locrian Scale.
    /// The locrian scale should not be used since it is very unpleasant.
    /// It is the standard diminished scale.
    /// </summary>
    public static Scale GetLocrian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1m,2m,3,4dim,5m,6m"));
    }
}
