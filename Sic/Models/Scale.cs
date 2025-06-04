class Scale
{
    private IInterval[] ScaleIntervals { get; set; }

    public Scale(IEnumerable<IInterval> intervals)
    {
        ScaleIntervals = [.. intervals];
    }

    public Scale(string intervals)
    {
        ScaleIntervals = [.. intervals.Split(',').Select(Intervals.GetInterval)];
    }

    public static Scale GetLydian()
    {
        return new Scale("1,2M,3M,4aug,5,6M,7M");
    }
    public static Scale GetMajor()
    {
        return new Scale("1,2M,3M,4,5,6M,7M");
    }
    public static Scale GetMixolydian()
    {
        return new Scale("1,2M,3M,4,5,6M,7m");
    }
    public static Scale GetDorian()
    {
        return new Scale("1,2M,3m,4,5,6M,7m");
    }
    public static Scale GetMinor()
    {
        return new Scale("1,2M,3m,4,5,6m,7m");
    }
    public static Scale GetPhrygian()
    {
        return new Scale("1,2m,3m,4,5,6m,7m");
    }
    public static Scale GetLocrian()
    {
        return new Scale("1,2m,3m,4,5dim,6m,7m");
    }
}
