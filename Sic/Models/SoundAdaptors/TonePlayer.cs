using NAudio.Wave;
using NAudio.Wave.SampleProviders;

using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

public class TonePlayer(Tone tone, int frequency = 44100, int channels = 1, double gain = 0.2, SignalGeneratorType signalType = SignalGeneratorType.Sin)
{
    private readonly Tone tone = tone;
    private readonly int frequency = frequency;
    private readonly int channels = channels;
    private readonly double gain = gain;
    private readonly SignalGeneratorType signalType = signalType;

    public SignalGenerator GetSignalGenerator()
    {
        return new(frequency, channels)
        {
            Gain = gain,
            Frequency = tone.GetFrequency(),
            Type = signalType,
        };
    }

    public ISampleProvider GetISampleProvider(double duration)
    {
        return GetSignalGenerator().Take(TimeSpan.FromMilliseconds(duration));
    }
}