class Rythm
{
    private List<Duration> Durations { get; set; }

    public Rythm(IEnumerable<Duration> durations)
    {
        Durations = [.. durations];
    }

    public static Rythm operator +(Rythm a, Rythm b)
    {
        return new Rythm([.. a.Durations, .. b.Durations]);
    }
}