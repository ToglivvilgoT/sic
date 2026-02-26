using NAudio.Mixer;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Default implementation of ITimedNotePlayer using the NAudio library.
/// </summary>
public class TimedNotePlayer : ITimedNotePlayer
{
    private MixingSampleProvider mixer = GetNewMixer();

    /// <inheritdoc/>
    public void Play()
    {
        using WaveOutEvent waveOutEvent = new();
        waveOutEvent.Init(mixer);
        waveOutEvent.Play();
        while (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1);
        }
    }

    /// <inheritdoc/>
    public void Queue(TimedNote note)
    {
        Console.WriteLine(note.Note.Pitch.GetFrequency());
        double bpm = 100;  // should be made dynamic in the future, not a constant.

        mixer.AddMixerInput(
            new OffsetSampleProvider(
                new SignalGenerator()
                {
                    Gain = 0.2,
                    Frequency = note.Note.Pitch.GetFrequency(),
                    Type = SignalGeneratorType.SawTooth,
                }
                .Take(TimeSpan.FromSeconds(note.Note.Duration.GetTime(bpm)))
            )
            {
                DelayBy = TimeSpan.FromSeconds(note.Offset.GetTime(bpm))
            }
        );
    }

    private static MixingSampleProvider GetNewMixer()
    {
        return new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 2));
    }
}