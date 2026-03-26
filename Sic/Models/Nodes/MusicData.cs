using Sic.Models.Music;
using Sic.Models.Music.Chords;
using Sic.Models.Music.Intervals;
using Sic.Models.Music.Melodies;

namespace Sic.Models.Nodes;

/// <summary>
/// Represents the different types of music data sent between nodes.
/// </summary>
public enum NodeDataType
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
public interface INodeData
{
    /// <summary>
    /// The type of the data.
    /// This marks what the underlying class is.
    /// For example, if Type is Chord, it is always safe to cast this as ChordData.
    /// </summary>
    public NodeDataType Type { get; }
}

/// <summary>No data</summary>
public class NoData() : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.NoData;
}

/// <summary>Note data</summary>
public class NoteData(Note note) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Note;
    /// <summary>The actual data.</summary>
    public Note Note { get; } = note;
}

/// <summary>Tone data</summary>
public class ToneData(Pitch tone) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Tone;
    /// <summary>The actual data.</summary>
    public Pitch Tone { get; } = tone;
}

/// <summary>Timed note data</summary>
public class TimedNoteData(TimedNote timedNote) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.TimedNote;
    /// <summary>The actual data.</summary>
    public TimedNote TimedNote { get; } = timedNote;
}

/// <summary>Scale data</summary>
public class ScaleData(Scale scale) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Scale;
    /// <summary>The actual data.</summary>
    public Scale Scale { get; } = scale;
}

/// <summary>Rhythm data</summary>
public class RhythmData(Rhythm rhythm) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Rhythm;
    /// <summary>The actual data.</summary>
    public Rhythm Rhythm { get; } = rhythm;
}

/// <summary>Duration data</summary>
public class DurationData(Duration duration) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Duration;
    /// <summary>The actual data.</summary>
    public Duration Duration { get; } = duration;
}

/// <summary>Chorded melody data</summary>
public class ChordedMelodyData(ChordedMelody chordedMelody) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.ChordedMelody;
    /// <summary>The actual data.</summary>
    public ChordedMelody ChordedMelody { get; } = chordedMelody;
}

/// <summary>Melody data</summary>
public class MelodyData(Melody melody) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Melody;
    /// <summary>The actual data.</summary>
    public Melody Melody { get; } = melody;
}

/// <summary>Absolute interval data</summary>
public class AbsoluteIntervalData(AbsoluteInterval absoluteInterval) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.AbsoluteInterval;
    /// <summary>The actual data.</summary>
    public AbsoluteInterval AbsoluteInterval { get; } = absoluteInterval;
}

/// <summary>Relative interval data</summary>
public class RelativeIntervalData(RelativeInterval relativeInterval) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.RelativeInterval;
    /// <summary>The actual data.</summary>
    public RelativeInterval RelativeInterval { get; } = relativeInterval;
}

/// <summary>Chord data</summary>
public class ChordData(Chord chord) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.Chord;
    /// <summary>The actual data.</summary>
    public Chord Chord { get; } = chord;
}

/// <summary>Chord progression data</summary>
public class ChordProgressionData(ChordProgression chordProgression) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.ChordProgression;
    /// <summary>The actual data.</summary>
    public ChordProgression ChordProgression { get; } = chordProgression;
}

/// <summary>Rooted chord data</summary>
public class RootedChordData(RootedChord rootedChord) : INodeData
{
    /// <inheritdoc/>
    public NodeDataType Type { get; } = NodeDataType.RootedChord;
    /// <summary>The actual data.</summary>
    public RootedChord RootedChord { get; } = rootedChord;
}