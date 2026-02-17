namespace Sic.Models.Music;

public class Note(Pitch tone, Duration duration)
{
    public Pitch Tone { get; } = tone;
    public Duration Duration { get; } = duration;

    public override string ToString()
    {
        return Tone + ":" + Duration;
    }
}