namespace Sic.Models.Music;

public class Duration : IEquatable<Duration>
{
    private Fraction Length { get; set; }

    public Duration(int beats, int divisions)
    {
        if (divisions <= 0 || beats <= 0)
        {
            throw new ArgumentException("Beats and divisions must be positive integers.");
        }

        Length = new Fraction(beats, divisions);
    }

    public double GetTime(double bpm)
    {
        return Length.AsDouble() * (4 * 60 / bpm);
    }

    public bool Equals(Duration? other)
    {
        return Length == other?.Length;
    }

    public static bool operator ==(Duration a, Duration b) {
        return a.Equals(b);
    }

    public static bool operator !=(Duration a, Duration b) {
        return !a.Equals(b);
    }
}