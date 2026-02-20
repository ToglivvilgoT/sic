using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

class TimedNoteSequencePlayer(IEnumerable<TimedNote> notes)
{
    private readonly IEnumerable<TimedNote> notes = notes;

    public ISampleProvider GetISampleProvider(int bpm)
    {
        var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        foreach (TimedNote note in notes) {
            mixer.AddMixerInput(
                new OffsetSampleProvider(
                    new TonePlayer(note.Note.Pitch)
                        .GetSignalGenerator()
                        .Take(TimeSpan.FromSeconds(note.Note.Duration.GetTime(bpm))
                    )
                )
                {
                    DelayBy = TimeSpan.FromSeconds(note.Offset.GetTime(bpm))
                }
            );
        };
        return mixer;
    }
    
}