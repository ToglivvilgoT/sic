using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Class that can queue and play Notes.
/// </summary>
public class NotePlayer(ITimedNotePlayer timedNotePlayer)
{
    private readonly ITimedNotePlayer timedNotePlayer = timedNotePlayer;

    /// <inheritdoc/>
    public void Queue(Note note)
    {
        Duration offset = new(0, 1);
        TimedNote timedNote = new(note, offset);
        timedNotePlayer.Queue(timedNote);
    }
}