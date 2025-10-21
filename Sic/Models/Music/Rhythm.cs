namespace Sic.Models.Music;

public class Rhythm
{
    public List<Duration> Durations { get; }

    public Rhythm(IEnumerable<Duration> durations)
    {
        Durations = [.. durations];
    }

    public static Rhythm operator +(Rhythm a, Rhythm b)
    {
        return new Rhythm([.. a.Durations, .. b.Durations]);
    }
}