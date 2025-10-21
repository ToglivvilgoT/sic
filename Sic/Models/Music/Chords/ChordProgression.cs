namespace Sic.Models.Music.Chords;

public class ChordProgression
{
    private List<RootedChord> Chords { get; }

    public ChordProgression(IEnumerable<RootedChord> chords)
    {
        Chords = [.. chords];
    }
}