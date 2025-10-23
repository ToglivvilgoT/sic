namespace Sic.Models.Music.Chords;

public class RootedChord
{
    private Chord ChordValue { get; set; }
    private Tone Root { get; set; }

    public RootedChord(Chord chord, Tone root)
    {
        ChordValue = chord;
        Root = root;
    }

    public IEnumerable<Tone> GetNotes()
    {
        return ChordValue.ChordIntervals.Select((interval) => Root + interval);
    }
}