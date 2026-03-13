namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Defines interface for any Player that can play some type of music.
/// </summary>
public interface IPlayable
{
    /// <summary>
    /// Called to play any music that has previously been queued.
    /// </summary>
    public void Play();
}