using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace Sic.Models.SoundPlayer;

static class NotePlayer
{
    public static SignalGenerator GetNote(Note note) {
        return new(44100, 1)
        {
            Gain = 0.2,
            Frequency = note.GetFrequency(),
            Type = SignalGeneratorType.Sin
        };
    }

    public static ISampleProvider GetNoteWithDuration(SignalGenerator note, double duration) {
        return note.Take(TimeSpan.FromMilliseconds(duration));
    }    
}