using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Class that can queue and play TimedNotes.
/// </summary>
public interface ITimedNotePlayer : IPlayable
{
    /// <summary>
    /// Queue a new note to be played.
    /// </summary>
    public void Queue(TimedNote note);
}