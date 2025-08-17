enum IntervalType
{
    Diminished,
    Minor,
    Perfect,
    Major,
    Augmented,
}

static class IntervalTypeMethods
{
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

    public static IntervalKind GetKind(this IntervalType type)
    {
        return type switch
        {
            IntervalType.Perfect => IntervalKind.Perfect,
            IntervalType.Minor => IntervalKind.NonPerfect,
            IntervalType.Major => IntervalKind.NonPerfect,
            IntervalType.Diminished => IntervalKind.Perfect | IntervalKind.NonPerfect,
            IntervalType.Augmented => IntervalKind.Perfect | IntervalKind.NonPerfect,
        };
    }
}