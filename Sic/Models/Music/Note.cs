namespace Sic.Models.Music;

public class Note
{
    public Tone NoteTone { get; }
    public Duration NoteDuration { get; }

    public Note(Tone tone, Duration duration)
    {
        NoteTone = tone;
        NoteDuration = duration;
    }
}