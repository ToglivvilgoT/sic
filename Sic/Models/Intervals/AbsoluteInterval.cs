class AbsoluteInterval {
    public RelativeInterval Interval { get; }
    public IntervalType Type { get; }

    public AbsoluteInterval(RelativeInterval interval, IntervalType type)
    {
        if ((interval.Kind & type.GetKind()) == 0)
        {
            throw new ArgumentException("Provided interval and type are not compatible.");
        }
        Interval = interval;
        Type = type;
    }

    public int GetSemitones()
    {
        return Interval.GetSemitones() + Type.GetSemitones(Interval.Kind);
    }
}