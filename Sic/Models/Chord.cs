class Chord
{
    private List<IInterval> ChordIntervals { get; set; }

    public Chord(IEnumerable<IInterval> intervals)
    {
        ChordIntervals = [.. intervals];
    }

    public Chord(string chord)
    {
        ChordIntervals = chord switch
        {
            "m" => [.. Intervals.GetIntervals("1,3m,5")],
            "M" => [.. Intervals.GetIntervals("1,3M,5")],
            "dim" => [.. Intervals.GetIntervals("1,3m,5dim")],
            "aug" => [.. Intervals.GetIntervals("1,3M,5aug")],
            _ => throw new ArgumentException("Chord not supported.")
        };
    }
}