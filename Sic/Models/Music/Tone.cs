using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

public class Tone : IEquatable<Tone>
{
    const float twelfthRootTwo = 1.0594631f;
    private int Pitch { get; }

    public Tone(int pitch)
    {
        Pitch = pitch;
    }

    public double GetFrequency()
    {
        return 440 * Math.Pow(twelfthRootTwo, Pitch - 9);
    }

    public static Tone operator +(Tone note, AbsoluteInterval interval)
    {
        return new Tone(note.Pitch + interval.GetSemitones());
    }

    private static int FloorDivision(int a, int b)
    {
        if (a < 0)
        {
            a = a - b + 1;
        }
        return a / b;
    }

    public override string ToString()
    {
        string letter = (Pitch % 12) switch
        {
            0 => "C",
            1 => "Db",
            2 => "D",
            3 => "Eb",
            4 => "E",
            5 => "F",
            6 => "Gb",
            7 => "G",
            8 => "Ab",
            9 => "A",
            10 => "Bb",
            11 => "B",
        };
        int octave = FloorDivision(Pitch, 12) + 4;
        return letter + octave;
    }

    public bool Equals(Tone? other)
    {
        return Pitch == other?.Pitch;
    }
    
    public static bool operator ==(Tone a, Tone b)
    {
        return a.Equals(b);
    }
    
    public static bool operator !=(Tone a, Tone b)
    {
        return !a.Equals(b);
    }
}