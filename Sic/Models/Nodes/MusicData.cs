using Sic.Models.Music;
using Sic.Models.Music.Chords;
using Sic.Models.Music.Intervals;
using Sic.Models.Music.Melodies;

namespace Sic.Models.Nodes;

public enum MusicDataType
{
    Note,
    Tone,
    TimedNote,
    Scale,
    RootedScale,
    Rhythm,
    Duration,
    ChordedMelody,
    Melody,
    AbsoluteInterval,
    RelativeInterval,
    Chord,
    ChordProgression,
    RootedChord,
}

public interface IMusicData
{
    public MusicDataType Type { get; }
}

public class NoteData(Note note) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Note;
    public Note Note { get; } = note;
}

public class ToneData(Tone tone) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Tone;
    public Tone Tone { get; } = tone;
}

public class TimedNoteData(TimedNote timedNote) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.TimedNote;
    public TimedNote TimedNote { get; } = timedNote;
}

public class ScaleData(Scale scale) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Scale;
    public Scale Scale { get; } = scale;
}

public class RhythmData(Rhythm rhythm) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Rhythm;
    public Rhythm Rhythm { get; } = rhythm;
}

public class DurationData(Duration duration) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Duration;
    public Duration Duration { get; } = duration;
}

public class ChordedMelodyData(ChordedMelody chordedMelody) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.ChordedMelody;
    public ChordedMelody ChordedMelody { get; } = chordedMelody;
}

public class MelodyData(Melody melody) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Melody;
    public Melody Melody { get; } = melody;
}

public class AbsoluteIntervalData(AbsoluteInterval absoluteInterval) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.AbsoluteInterval;
    public AbsoluteInterval AbsoluteInterval { get; } = absoluteInterval;
}

public class RelativeIntervalData(RelativeInterval relativeInterval) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.RelativeInterval;
    public RelativeInterval RelativeInterval { get; } = relativeInterval;
}

public class ChordData(Chord chord) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.Chord;
    public Chord Chord { get; } = chord;
}

public class ChordProgressionData(ChordProgression chordProgression) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.ChordProgression;
    public ChordProgression ChordProgression { get; } = chordProgression;
}

public class RootedChordData(RootedChord rootedChord) : IMusicData
{
    public MusicDataType Type { get; } = MusicDataType.RootedChord;
    public RootedChord RootedChord { get; } = rootedChord;
}