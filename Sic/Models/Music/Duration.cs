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

    /// <summary>
    /// Returns how long the duration is i seconds.
    /// </summary>
    /// <param name="bpm">Beats per minute</param>
    public double GetTime(double bpm)
    {
        const int beatsPerWholeNote = 4;
        const int secondsPerMinute = 60;

        double secondsPerBeat = secondsPerMinute / bpm;
        double secondsPerWholeNote = beatsPerWholeNote * secondsPerBeat;

        return Length.AsDouble() * secondsPerWholeNote;
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