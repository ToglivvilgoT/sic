using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Class that can queue and play Notes.
/// </summary>
public class NotePlayer(ITimedNotePlayer timedNotePlayer)
{
    private readonly ITimedNotePlayer timedNotePlayer = timedNotePlayer;

    /// <summary>
    /// Queue a Note to be played.
    /// </summary>
    public void Queue(Note note)
    {
        Duration duration = new(1, 1);
        TimedNote timedNote = new(note, duration);
        timedNotePlayer.Queue(timedNote);
    }

    /// <summary>
    /// Play all queued notes.
    /// </summary>
    public void Play()
    {
        timedNotePlayer.Play();
    }
}