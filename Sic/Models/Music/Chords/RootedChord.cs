namespace Sic.Models.Music.Chords;

public class RootedChord
{
    private Chord ChordValue { get; set; }
    private Note Root { get; set; }

    public RootedChord(Chord chord, Note root)
    {
        ChordValue = chord;
        Root = root;
    }

    public IEnumerable<Note> GetNotes()
    {
        return ChordValue.ChordIntervals.Select((interval) => Root + interval);
    }
}