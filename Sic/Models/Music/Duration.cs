namespace Sic.Models.Music;

public struct Duration : IEquatable<Duration>
{
    private Fraction Length { get; set; }

    public Duration(int beats, int divisions)
    {
        if (divisions <= 0)
        {
            throw new ArgumentException("divisions must be a positive integer");
        } 
        else if (beats < 0)
        {
            throw new ArgumentException("beats must be zero or a positive integer");
        }

        Length = new Fraction(beats, divisions);
    }

    private Duration(Fraction fraction)
    {
        Length = fraction;
    }

    public double GetTime(double bpm)
    {
        return Length.AsDouble() * (4.0 * 60.0 / bpm);
    }

    public bool Equals(Duration other)
    {
        return Length == other.Length;
    }

    public static bool operator ==(Duration a, Duration b) {
        return a.Equals(b);
    }

    public static bool operator !=(Duration a, Duration b) {
        return !a.Equals(b);
    }

    public static Duration operator +(Duration a, Duration b)
    {
        Fraction sum = a.Length + b.Length;
        return new(sum);
    }

    public override string ToString()
    {
        return Length.ToString();
    }
}