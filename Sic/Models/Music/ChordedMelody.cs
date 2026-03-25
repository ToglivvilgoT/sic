using Sic.Models.Music.Chords;
using Sic.Models.Music.Melodies;

namespace Sic.Models.Music;

/// <summary>
/// Represents a melody with an underlying chord.
/// </summary>
public class ChordedMelody(Chord chord, Melody melody)
{
    private Chord Chord { get; } = chord;
    private Melody Melody { get; } = melody;
}