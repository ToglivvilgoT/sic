using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Class that can queue and play Notes.
/// </summary>
public class NotePlayer(ITimedNotePlayer timedNotePlayer) : IPlayable
{
    private readonly ITimedNotePlayer timedNotePlayer = timedNotePlayer;

    /// <inheritdoc/>
    public void Queue(Note note)
    {
        Duration duration = new(1, 1);
        TimedNote timedNote = new(note, duration);
        timedNotePlayer.Queue(timedNote);
    }

    /// <inheritdoc/>
    public void Play()
    {
        timedNotePlayer.Play();
    }
}