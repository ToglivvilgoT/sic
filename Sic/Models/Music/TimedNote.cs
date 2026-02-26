namespace Sic.Models.Music;

/// <summary>
/// Represent a Note with a certain timing.
/// </summary>
/// <param name="note">The actual Note.</param>
/// <param name="offset">How long from start until the note will play</param>
public class TimedNote(Note note, Duration offset)
{
    /// <summary>
    /// The actual Note.
    /// </summary>
    public Note Note {get;} = note;
    /// <summary>
    /// How long from start until the note should play.
    /// When start is depends on context.
    /// </summary>
    public Duration Offset {get;} = offset;

    /// <inheritdoc/>
    public override string ToString()
    {
        return Note + " " + Offset;
    }
}