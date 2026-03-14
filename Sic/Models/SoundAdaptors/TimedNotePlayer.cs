using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Sic.Models.Music;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Default implementation of IPlayable&lt;TimedNote&gt; using the NAudio library.
/// </summary>
public class TimedNotePlayer : ITimedNotePlayer
{
    private readonly MixingSampleProvider mixer;
    private readonly WasapiOut output;
    private const int sampleRate = 44100;
    private const int chanels = 2;

    /// <summary>
    /// Create a new TimedNotePlayer.
    /// </summary>
    public TimedNotePlayer()
    {
        mixer = new MixingSampleProvider(
            WaveFormat.CreateIeeeFloatWaveFormat(sampleRate, chanels))
        {
            ReadFully = true,
        };

        output = new WasapiOut(NAudio.CoreAudioApi.AudioClientShareMode.Shared, true, 20);

        output.Init(mixer);
        output.Play();
    }

    /// <inheritdoc/>
    public void Queue(TimedNote note)
    {
        double bpm = 100;  // should be made dynamic in the future, not a constant.

        mixer.AddMixerInput(
            new OffsetSampleProvider(
                new SignalGenerator(sampleRate, chanels)
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
}