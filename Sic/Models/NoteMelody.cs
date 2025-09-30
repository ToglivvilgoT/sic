namespace Sic.Models;

class NoteMelody : IMelody
{
    private List<Note> Notes { get; }
    private Rythm MelodyRythm { get; }

    public NoteMelody(IEnumerable<Note> notes, Rythm rythm)
    {
        Notes = [.. notes];
        MelodyRythm = rythm;
        if (Notes.Count != MelodyRythm.Durations.Count)
        {
            throw new ArgumentException("length of notes and rythm.Durations must be equal.");
        }
    }
}