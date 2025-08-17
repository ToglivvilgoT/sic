class RelativeInterval
{
    /// <summary>
    /// Step encodes interval step.
    /// 0 = Unison, 1 = Second, 2 = Third and so on.
    /// </summary>
    private int Steps { get; set; }
    /// <summary>
    /// How many octaves the interval reaches rounded down.
    /// </summary>
    private int Octaves
    {
        get { return Math.Abs(Steps) / 7; }
    }
    /// <summary>
    /// The interval size disregarding octave and direction.
    /// </summary>
    private int Interval
    {
        get { return Math.Abs(Steps) % 7; }
    }
    /// <summary>
    /// The direction of the interval. 1 = up, -1 = down.
    /// </summary>
    private int Direction
    {
        get { return Math.Sign(Steps); }
    }
    public IntervalKind Kind
    {
        get
        {
            if (Interval == 0 || Interval == 3 || Interval == 4)
            {
                return IntervalKind.Perfect;
            }
            else
            {
                return IntervalKind.NonPerfect;
            }
        }
    }

    public RelativeInterval(int step)
    {
        Steps = step;
    }

    /// <summary>
    /// Returns the amount of semitones in the interval.
    /// Interval going down will have negative semitones.
    /// Semitones are based on the major scale.
    /// </summary>
    /// <returns> The semitones in the interval. </returns>
    public int GetSemitones()
    {
        int intervalSemitones = Interval switch
        {
            0 => 0, // Unison
            1 => 2, // Second
            2 => 4, // Third
            3 => 5, // Fourth
            4 => 7, // Fifth
            5 => 9, // Sixth
            6 => 11, // Seventh
        };
        return 12 * Octaves + intervalSemitones;
    }

    public static RelativeInterval operator +(RelativeInterval a, RelativeInterval b)
    {
        return new RelativeInterval(a.Steps + b.Steps);
    }

    public static RelativeInterval operator -(RelativeInterval a, RelativeInterval b)
    {
        return new RelativeInterval(a.Steps - b.Steps);
    }

    public static RelativeInterval operator -(RelativeInterval interval)
    {
        return new RelativeInterval(-interval.Steps);
    }

    public override string ToString()
    {
        string intervalString = Interval switch
        {
            0 => "Unison ",
            1 => "Second ",
            2 => "Thrid ",
            3 => "Fourth ",
            4 => "Fifth ",
            5 => "Sixth ",
            6 => "Seventh ",
        };
        string octave = Octaves == 0 ? "" : "and " + Octaves.ToString() + " Octaves ";
        string direction = Direction == 1 ? "Up" : "Down";

        return intervalString + octave + direction;
    }
}