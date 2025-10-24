namespace Sic.Models.Music;

public class Note(Tone tone, Duration duration)
{
    public Tone NoteTone { get; } = tone;
    public Duration NoteDuration { get; } = duration;
}