namespace Sic.Models.Music.Melodies;

public class NoteMelody
{
    private List<Tone> Notes { get; }
    private Rhythm MelodyRythm { get; }

    public NoteMelody(IEnumerable<Tone> notes, Rhythm rythm)
    {
        Notes = [.. notes];
        MelodyRythm = rythm;
        if (Notes.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("length of notes and rythm.Durations must be equal.");
        }
    }

    public IEnumerable<TimedNote> GetTimedNotes()
    {
        throw new NotImplementedException();
    }
}