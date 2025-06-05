class Chord
{
    public List<IInterval> ChordIntervals { get; private set; }

    public Chord(IEnumerable<IInterval> intervals)
    {
        ChordIntervals = [.. intervals];
    }

    public Chord(string chord)
    {
        ChordIntervals = chord switch
        {
            "m" => [.. Intervals.GetAbsoluteIntervals("1,3m,5")],
            "M" => [.. Intervals.GetAbsoluteIntervals("1,3M,5")],
            "dim" => [.. Intervals.GetAbsoluteIntervals("1,3m,5dim")],
            "aug" => [.. Intervals.GetAbsoluteIntervals("1,3M,5aug")],
            _ => throw new ArgumentException("Chord not supported.")
        };
    }
}