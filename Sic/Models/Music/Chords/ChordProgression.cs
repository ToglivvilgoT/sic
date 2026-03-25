namespace Sic.Models.Music.Chords;

/// <summary>
/// Represents a chord progression.
/// </summary>
public class ChordProgression(IEnumerable<RootedChord> chords)
{
    /// <summary>
    /// The list of chords in this progression.
    /// </summary>
    private List<RootedChord> Chords { get; } = [.. chords];
}