using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

public class ToneSequencePlayer(IEnumerable<Pitch> tones)
{
    private readonly IEnumerable<Pitch> tones = tones;

    public ISampleProvider GetISampleProvider(double duration)
    {
        var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        foreach (Pitch tone in tones) {
            mixer.AddMixerInput(new TonePlayer(tone)
                                    .GetSignalGenerator()
                                    .Take(TimeSpan.FromMilliseconds(duration)));
        };
        return mixer;
    }
}