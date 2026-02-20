namespace Sic.Models.Music;

/// <summary>
/// A Note with a pitch and duration.
/// </summary>
/// <param name="pitch">The pitch of the note.</param>
/// <param name="duration">The duration of the note.</param>
public class Note(Pitch pitch, Duration duration)
{
    /// <summary>
    /// The Pitch of the Note.
    /// </summary>
    public Pitch Pitch { get; } = pitch;
    /// <summary>
    /// The Duration of the Note.
    /// </summary>
    public Duration Duration { get; } = duration;

    /// <inheritdoc/>
    public override string ToString()
    {
        return Pitch + ":" + Duration;
    }
}