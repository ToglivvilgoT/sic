using Sic.Models.Music;
using Sic.Models.Music.Chords;
using Sic.Models.Music.Intervals;
using Sic.Models.Music.Melodies;

namespace Sic.Models.Nodes;

/// <summary>
/// Represents the different types of music data sent between nodes.
/// </summary>
public enum MusicDataType
{
    /// <summary>No data.</summary>
    NoData,
    /// <summary>Note.</summary>
    Note,
    /// <summary>Tone.</summary>
    Tone,
    /// <summary>TimedNote.</summary>
    TimedNote,
    /// <summary>Scale.</summary>
    Scale,
    /// <summary>Rooted scale.</summary>
    RootedScale,
    /// <summary>Rhythm</summary>
    Rhythm,
    /// <summary>Duration</summary>
    Duration,
    /// <summary>Chorded melody</summary>
    ChordedMelody,
    /// <summary>Melody</summary>
    Melody,
    /// <summary>Absolute Interval</summary>
    AbsoluteInterval,
    /// <summary>Relative Interval</summary>
    RelativeInterval,
    /// <summary>Chord</summary>
    Chord,
    /// <summary>Chord progression</summary>
    ChordProgression,
    /// <summary>Rooted chord</summary>
    RootedChord,
}

/// <summary>
/// Represents a single packet of music data being sent between nodes.
/// If the Type is for example Note, then it is always safe to cast this as a NoteData.
/// The same goes for the other types.
/// The pattern is called "tagged unions" in C and is similar to Rust enums.
/// </summary>
public interface IMusicData
{
    /// <summary>
    /// The type of the data.
    /// This marks what the underlying class is.
    /// For example, if Type is Chord, it is always safe to cast this as ChordData.
    /// </summary>
    public MusicDataType Type { get; }
}

/// <summary>No data</summary>
public class NoData() : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.NoData;
}

/// <summary>Note data</summary>
public class NoteData(Note note) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Note;
    /// <summary>The actual data.</summary>
    public Note Note { get; } = note;
}

/// <summary>Tone data</summary>
public class ToneData(Pitch tone) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Tone;
    /// <summary>The actual data.</summary>
    public Pitch Tone { get; } = tone;
}

/// <summary>Timed note data</summary>
public class TimedNoteData(TimedNote timedNote) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.TimedNote;
    /// <summary>The actual data.</summary>
    public TimedNote TimedNote { get; } = timedNote;
}

/// <summary>Scale data</summary>
public class ScaleData(Scale scale) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Scale;
    /// <summary>The actual data.</summary>
    public Scale Scale { get; } = scale;
}

/// <summary>Rhythm data</summary>
public class RhythmData(Rhythm rhythm) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Rhythm;
    /// <summary>The actual data.</summary>
    public Rhythm Rhythm { get; } = rhythm;
}

/// <summary>Duration data</summary>
public class DurationData(Duration duration) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Duration;
    /// <summary>The actual data.</summary>
    public Duration Duration { get; } = duration;
}

/// <summary>Chorded melody data</summary>
public class ChordedMelodyData(ChordedMelody chordedMelody) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.ChordedMelody;
    /// <summary>The actual data.</summary>
    public ChordedMelody ChordedMelody { get; } = chordedMelody;
}

/// <summary>Melody data</summary>
public class MelodyData(Melody melody) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Melody;
    /// <summary>The actual data.</summary>
    public Melody Melody { get; } = melody;
}

/// <summary>Absolute interval data</summary>
public class AbsoluteIntervalData(AbsoluteInterval absoluteInterval) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.AbsoluteInterval;
    /// <summary>The actual data.</summary>
    public AbsoluteInterval AbsoluteInterval { get; } = absoluteInterval;
}

/// <summary>Relative interval data</summary>
public class RelativeIntervalData(RelativeInterval relativeInterval) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.RelativeInterval;
    /// <summary>The actual data.</summary>
    public RelativeInterval RelativeInterval { get; } = relativeInterval;
}

/// <summary>Chord data</summary>
public class ChordData(Chord chord) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.Chord;
    /// <summary>The actual data.</summary>
    public Chord Chord { get; } = chord;
}

/// <summary>Chord progression data</summary>
public class ChordProgressionData(ChordProgression chordProgression) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.ChordProgression;
    /// <summary>The actual data.</summary>
    public ChordProgression ChordProgression { get; } = chordProgression;
}

/// <summary>Rooted chord data</summary>
public class RootedChordData(RootedChord rootedChord) : IMusicData
{
    /// <inheritdoc/>
    public MusicDataType Type { get; } = MusicDataType.RootedChord;
    /// <summary>The actual data.</summary>
    public RootedChord RootedChord { get; } = rootedChord;
}