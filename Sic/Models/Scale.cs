class Scale
{
    private AbsoluteInterval[] ScaleIntervals { get; }

    public Scale(IEnumerable<AbsoluteInterval> intervals)
    {
        ScaleIntervals = [.. intervals];
    }

    public IEnumerable<AbsoluteInterval> GetIntervalsMatchingLength(IntervalLength length)
    {
        return ScaleIntervals.Where((interval) => interval.IsLength(length));
    }

    public static Scale GetLydian()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2M,3M,4aug,5,6M,7M"));
    }
    public static Scale GetMajor()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2M,3M,4,5,6M,7M"));
    }
    public static Scale GetMixolydian()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2M,3M,4,5,6M,7m"));
    }
    public static Scale GetDorian()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2M,3m,4,5,6M,7m"));
    }
    public static Scale GetMinor()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2M,3m,4,5,6m,7m"));
    }
    public static Scale GetPhrygian()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2m,3m,4,5,6m,7m"));
    }
    public static Scale GetLocrian()
    {
        return new Scale(Intervals.GetAbsoluteIntervals("1,2m,3m,4,5dim,6m,7m"));
    }
}
