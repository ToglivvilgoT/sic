using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

/// <summary>
/// Class representing a Pitch of a tone.
/// </summary>
/// <param name="step">
/// step = 0 is middle C.
/// step += 1 will increase the step by one semitone,
/// so step = 1 will be middle C#.
/// </param>
public class Pitch(int step) : IEquatable<Pitch>
{
    private readonly double twelfthRootTwo = Math.Pow(2, 1 / 12);
    private int Step { get; } = step;

    /// <summary>
    /// Return the frequency of the Tone in Hertz.
    /// </summary>
    public double GetFrequency()
    {
        double frequencyOfA = 440; // standard tuning.
        double frequencyOfMiddleC = frequencyOfA * Math.Pow(twelfthRootTwo, 9);
        return frequencyOfMiddleC * Math.Pow(twelfthRootTwo, Step);
    }

    /// <summary>
    /// Get the pitch of this pitch plus an interval.
    /// </summary>
    /// <param name="pitch">The pitch to start from.</param>
    /// <param name="interval">How many steps up/down should be taken</param>
    /// <returns>
    /// A new Pitch with the same step as input pitch,
    /// but offset by interval amount of semitones.
    /// </returns>
    public static Pitch operator +(Pitch pitch, AbsoluteInterval interval)
    {
        return new Pitch(pitch.Step + interval.GetSemitones());
    }

    private static int FloorDivision(int a, int b)
    {
        if (a < 0)
        {
            a = a - b + 1;
        }
        return a / b;
    }

    /// <summary>
    /// Returns a string representation of the Pitch.
    /// </summary>
    /// <returns>
    /// A string representation of the Pitch,
    /// preferring flats over sharp,
    /// So C# would be displayed as Db
    /// </returns>
    public override string ToString()
    {
        string letter = (Step % 12) switch
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
            _ => throw new Exception("This code will not be executed since all int values modulo 12 are covered above")
        };
        int octave = FloorDivision(Step, 12) + 4;
        return letter + octave;
    }

    /// <inheritdoc/>
    public bool Equals(Pitch? other)
    {
        return Step == other?.Step;
    }
    
    /// <summary>
    /// Checks if two Pitches have the same pitch.
    /// </summary>
    public static bool operator ==(Pitch a, Pitch b)
    {
        return a.Equals(b);
    }
    
    /// <summary>
    /// Checks if two Pitches have different pitch.
    /// </summary>
    public static bool operator !=(Pitch a, Pitch b)
    {
        return !a.Equals(b);
    }

    /// <inheritdoc/>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Pitch);
    }

    /// <inheritdoc/>
    public override int GetHashCode()
    {
        return HashCode.Combine(Step);
    }
}