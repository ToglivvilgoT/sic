using System.Collections;
using Sic.Models.Music.Context;
using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Chords;

public class RootedChord
{
    private Chord Chord { get; set; }
    private AbsoluteInterval Root { get; set; }

    public RootedChord(Chord chord, AbsoluteInterval root)
    {
        Chord = chord;
        Root = root;
    }

    public IEnumerable<Pitch> GetNotes(IRootContext context)
    {
        return Chord.ChordIntervals.Select((interval) => context.Root + Root + interval);
    }

    public override string ToString()
    {
        return Root + ":" + Chord;
    }
}