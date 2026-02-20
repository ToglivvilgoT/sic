using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

public class NotePlayer(Note note, int frequency = 44100, int channels = 1, double gain = 0.2, SignalGeneratorType signalType = SignalGeneratorType.SawTooth)
{
    private readonly Note note = note;
    private readonly int frequency = frequency;
    private readonly int channels = channels;
    private readonly double gain = gain;
    private readonly SignalGeneratorType signalType = signalType;

    public SignalGenerator GetSignalGenerator()
    {
        return new(frequency, channels)
        {
            Gain = gain,
            Frequency = note.Pitch.GetFrequency(),
            Type = signalType,
        };
    }

    public ISampleProvider GetISampleProvider(double bpm)
    {
        return GetSignalGenerator().Take(TimeSpan.FromSeconds(note.Duration.GetTime(bpm)));
    }
}