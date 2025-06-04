interface IInterval
{
    public int GetSemitones();
}

abstract class LengthTypeInterval : IInterval
{
    protected abstract int GetLengthSemitones(); 
    protected abstract int GetTypeSemitones(); 
    public int GetSemitones()
    {
        return GetLengthSemitones() + GetTypeSemitones();
    }
}

class PerfectInterval : LengthTypeInterval
{
    private PerfectIntervalLength Length { get; set; }
    private PerfectIntervalType Type { get; set; }

    public PerfectInterval(PerfectIntervalLength length, PerfectIntervalType type)
    {
        Length = length;
        Type = type;
    }
    public PerfectInterval(string interval)
    {
        Length = interval[0] switch
        {
            '1' => PerfectIntervalLength.Prime,
            '4' => PerfectIntervalLength.Fourth,
            '5' => PerfectIntervalLength.Fifth,
            '8' => PerfectIntervalLength.Octave,
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

    protected override int GetLengthSemitones()
    {
        return (int)Length;
    }

    protected override int GetTypeSemitones()
    {
        return (int)Type;
    }
}

enum PerfectIntervalLength
{
    Prime = 0,
    Fourth = 5,
    Fifth = 7,
    Octave = 12,
}

enum PerfectIntervalType
{
    Diminished = -1,
    Perfect = 0,
    Augmented = 1,
}

class NonPerfectInterval : LengthTypeInterval
{
    private NonPerfectIntervalLength Length { get; set; }
    private NonPerfectIntervalType Type { get; set; }

    public NonPerfectInterval(NonPerfectIntervalLength length, NonPerfectIntervalType type)
    {
        Length = length;
        Type = type;
    }
    public NonPerfectInterval(string interval)
    {
        Length = interval[0] switch
        {
            '2' => NonPerfectIntervalLength.Second,
            '3' => NonPerfectIntervalLength.Third,
            '6' => NonPerfectIntervalLength.Sixth,
            '7' => NonPerfectIntervalLength.Seventh,
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

    protected override int GetLengthSemitones()
    {
        return (int)Length;
    }

    protected override int GetTypeSemitones()
    {
        return (int)Type;
    }
}

enum NonPerfectIntervalLength
{
    Second = 2,
    Third = 4,
    Sixth = 9,
    Seventh = 11,
}

enum NonPerfectIntervalType
{
    Diminished = -2,
    Minor = -1,
    Major = 0,
    Augmented = 1,
}