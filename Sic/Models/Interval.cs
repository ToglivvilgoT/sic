interface IInterval
{
    public int GetSemitones();
    public bool IsLength(IntervalLength length);
}

abstract class AbsoluteInterval : IInterval
{
    protected IntervalLength Length { get; init; }
    protected abstract int GetTypeSemitones(); 
    public int GetSemitones()
    {
        return (int)Length + GetTypeSemitones();
    }

    public bool IsLength(IntervalLength length)
    {
        return Length == length;
    }
}

class PerfectAbsoluteInterval : AbsoluteInterval
{
    private PerfectIntervalType Type { get; set; }

    public PerfectAbsoluteInterval(IntervalLength length, PerfectIntervalType type)
    {
        Length = length;
        Type = type;
    }
    public PerfectAbsoluteInterval(string interval)
    {
        Length = interval[0] switch
        {
            '1' => IntervalLength.Prime,
            '4' => IntervalLength.Fourth,
            '5' => IntervalLength.Fifth,
            '8' => IntervalLength.Octave,
            _ => throw new ArgumentException("First char in interval must be a valid digit.")
        };
        if (interval.Length == 1)
        {
            Type = PerfectIntervalType.Perfect;
            return;
        }
        Type = interval.Substring(1, 3) switch
        {
            "dim" => PerfectIntervalType.Diminished,
            "aug" => PerfectIntervalType.Augmented,
            _ => throw new ArgumentException("interval must be on form 'x', 'xdim' or 'xaug' where x is digit.")
        };
    }

    protected override int GetTypeSemitones()
    {
        return (int)Type;
    }
}

enum PerfectIntervalType
{
    Diminished = -1,
    Perfect = 0,
    Augmented = 1,
}

class NonPerfectAbsoluteInterval : AbsoluteInterval
{
    private NonPerfectIntervalType Type { get; set; }

    public NonPerfectAbsoluteInterval(IntervalLength length, NonPerfectIntervalType type)
    {
        Length = length;
        Type = type;
    }
    public NonPerfectAbsoluteInterval(string interval)
    {
        Length = interval[0] switch
        {
            '2' => IntervalLength.Second,
            '3' => IntervalLength.Third,
            '6' => IntervalLength.Sixth,
            '7' => IntervalLength.Seventh,
            _ => throw new ArgumentException("First char in interval must be a valid digit.")
        };
        if (interval.Length == 2)
        {
            if (interval[1] == 'M')
            {
                Type = NonPerfectIntervalType.Major;
            }
            else if (interval[1] == 'm')
            {
                Type = NonPerfectIntervalType.Minor;
            }
            else
            {
                throw new ArgumentException("interval of length 2 must end with 'M' (for major) or 'm' (for minor)");
            }
        }
        else if (interval.Length == 4)
        {
            if (interval.Substring(1, 3) == "dim")
            {
                Type = NonPerfectIntervalType.Diminished;
            }
            else if (interval.Substring(1, 3) == "aug")
            {
                Type = NonPerfectIntervalType.Augmented;
            }
            else
            {
                throw new ArgumentException("interval of length 4 must end with 'dim' (for diminished) or 'aug' (for augmented)");
            }
        }
        else
        {
            throw new ArgumentException("interval must be of length 2 or 4.");
        }
    }

    protected override int GetTypeSemitones()
    {
        return (int)Type;
    }
}

enum NonPerfectIntervalType
{
    Diminished = -2,
    Minor = -1,
    Major = 0,
    Augmented = 1,
}

class RelativeInterval : IInterval
{
    private Scale IntervalScale { get; }
    private IntervalLength Length { get; }

    public RelativeInterval(Scale intervalScale, IntervalLength length)
    {
        if (!intervalScale.GetIntervalsMatchingLength(length).Any())
        {
            throw new ArgumentException("length must be an interval in intervalScale.");
        }
        IntervalScale = intervalScale;
        Length = length;
    }

    public int GetSemitones()
    {
        return IntervalScale.GetIntervalsMatchingLength(Length).First().GetSemitones();
    }

    public bool IsLength(IntervalLength length)
    {
        return Length == length;
    }
}

enum IntervalLength {
    Prime = 0,
    Second = 2,
    Third = 4,
    Fourth = 5,
    Fifth = 7,
    Sixth = 9,
    Seventh = 11,
    Octave = 12,
}