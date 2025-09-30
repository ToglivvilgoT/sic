using System.Reflection.Metadata;
using Microsoft.Extensions.FileProviders.Physical;
using Sic.Models.Intervals;

namespace Sic.Models;

class Note
{
    const float twelthRootTwo = 1.0594631f;
    private int Pitch { get; }

    public Note(int pitch)
    {
        Pitch = pitch;
    }

    public double GetFrequency()
    {
        return 440 * Math.Pow(twelthRootTwo, Pitch + 4);
    }

    public static Note operator +(Note note, AbsoluteInterval interval)
    {
        return new Note(note.Pitch + interval.GetSemitones());
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
}