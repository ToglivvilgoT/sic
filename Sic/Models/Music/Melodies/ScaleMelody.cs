namespace Sic.Models.Music.Melodies;

public class ScaleMelody(Scale scale, Melody melody)
{
    private Scale Scale { get; } = scale;
    private Melody Melody { get; } = melody;

    public IEnumerable<TimedNote> GetTimedNotes(Tone root)
    {
        List<TimedNote> timedNotes = [];
        Duration currentOffset = new(0, 1);
        RootedScale rootedScale = new(Scale, root);
        foreach (var (interval, duration) in Melody.Intervals.Zip(Melody.Rhythm.Durations))
        {
            Tone note = rootedScale.GetTone(interval);
            timedNotes.Add(new(new(note, duration), currentOffset));
            currentOffset += duration;
        } 
        return timedNotes;
    }
}