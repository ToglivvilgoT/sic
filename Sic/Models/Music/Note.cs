namespace Sic.Models.Music;

public class Note(Tone tone, Duration duration)
{
    public Tone Tone { get; } = tone;
    public Duration Duration { get; } = duration;

    public override string ToString()
    {
        return Tone + ":" + Duration;
    }
}