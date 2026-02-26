using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Class that can queue and play TimedNotes.
/// </summary>
public interface ITimedNotePlayer
{
    /// <summary>
    /// Queue a new note to be played.
    /// </summary>
    public void Queue(TimedNote note);

    /// <summary>
    /// Plays all music that has been queued.
    /// </summary>
    public void Play();
}