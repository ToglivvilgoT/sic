namespace Sic.Models.Music;

/// <summary>
/// Represents a physical note without abstractions.
/// </summary>
/// <remarks>
/// This class should never be used internally to create music,
/// for that use the abstract classes Pitch, Note, TimedNote etc.
/// This class is only used to easier produce the actual sound
/// when the song should be played.
/// </remarks>
public class PhysicalNote
{
    /// <summary>
    /// The frequency of the note.
    /// </summary>
    public double Frequency { get; }

    /// <summary>
    /// The duration of the note in milliseconds.
    /// </summary>
    public double Duration { get; }

    /// <summary>
    /// The offset until the note starts playing in milliseconds.
    /// </summary>
    public double Offset { get; }
}