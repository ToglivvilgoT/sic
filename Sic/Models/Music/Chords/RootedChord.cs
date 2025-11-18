using System.Collections;

namespace Sic.Models.Music.Chords;

public class RootedChord : IEnumerable<Tone>
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

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public IEnumerator<Tone> GetEnumerator()
    {
        return ChordValue.ChordIntervals.Select((interval) => Root + interval).GetEnumerator();
    }

    public override string ToString()
    {
        return Root + ":" + ChordValue;
    }
}