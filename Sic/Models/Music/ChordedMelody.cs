using Sic.Models.Music.Melodies;

namespace Sic.Models.Music;

class ChordedMelody(Chord chord, Melody melody)
{
    private Chord Chord { get; } = chord;
    private Melody Melody { get; } = melody;
}