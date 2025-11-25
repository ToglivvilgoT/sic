using Microsoft.VisualBasic;
using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

public class Scale
{
    private AbsoluteInterval[] ScaleIntervals { get; }

    public Scale(IEnumerable<AbsoluteInterval> intervals)
    {
        ScaleIntervals = [.. intervals];
    }

    /// <summary>
    /// Given a relative interval, return all absolute intervals of that type in the scale.
    /// Note that this will always return exactly one interval for major scale and its modes.
    /// </summary>
    public AbsoluteInterval GetAbsoluteInterval(RelativeInterval relativeInterval)
    {
        return ScaleIntervals.Where((interval) => interval.Interval == relativeInterval).First();
    }

    public static Scale GetLydian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2M,3M,4aug,5,6M,7M"));
    }
    public static Scale GetMajor()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("0,1M,2M,3,4,5M,6M"));
    }
    public static Scale GetMixolydian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2M,3M,4,5,6M,7m"));
    }
    public static Scale GetDorian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2M,3m,4,5,6M,7m"));
    }
    public static Scale GetMinor()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2M,3m,4,5,6m,7m"));
    }
    public static Scale GetPhrygian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2m,3m,4,5,6m,7m"));
    }
    public static Scale GetLocrian()
    {
        return new Scale(AbsoluteInterval.MultipleFromString("1,2m,3m,4,5dim,6m,7m"));
    }
}
