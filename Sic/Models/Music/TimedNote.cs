namespace Sic.Models.Music;

public class TimedNote(Note note, Duration offset)
{
    public Note Note {get;} = note;
    /// <summary>
    /// How long from start until the note should play.
    /// When start is depends on context.
    /// </summary>
    public Duration Offset {get;} = offset;
}