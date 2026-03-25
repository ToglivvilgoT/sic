using System.Collections;
using Sic.Models.Music.Context;
using Sic.Models.Music.Intervals;

namespace Sic.Models.Music.Chords;

/// <summary>
/// Represents a chord with a fixed root.
/// The major chord built from the fifth (i.e. a G major chord in the scale of C major)
/// </summary>
public class RootedChord
{
    private Chord Chord { get; set; }
    private AbsoluteInterval Root { get; set; }

    /// <summary>
    /// Create a new rooted chord with a given chord and root.
    /// </summary>
    public RootedChord(Chord chord, AbsoluteInterval root)
    {
        Chord = chord;
        Root = root;
    }

    /// <summary>
    /// Get the notes contained in this chord given a RootContext.
    /// </summary>
    public IEnumerable<Pitch> GetNotes(IRootContext context)
    {
        return Chord.ChordIntervals.Select((interval) => context.Root + Root + interval);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return Root + ":" + Chord;
    }
}