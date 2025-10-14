namespace Sic.Models;

class NoteMelody : IMelody
{
    private List<Note> Notes { get; }
    private Rhythm MelodyRythm { get; }

    public NoteMelody(IEnumerable<Note> notes, Rhythm rythm)
    {
        Notes = [.. notes];
        MelodyRythm = rythm;
        if (Notes.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("length of notes and rythm.Durations must be equal.");
        }
    }
}