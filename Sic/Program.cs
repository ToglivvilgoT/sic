using Sic.Models.Intervals;
using Sic.Models;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using Sic.SoundAdaptors;

class Program
{
    static void Main(string[] args)
    {
        var c = new Note(0);
        var d = c + new AbsoluteInterval(new(1), IntervalType.Major);
        var e = c + new AbsoluteInterval(new(2), IntervalType.Major);
        var note1 = (c, 250);
        var note2 = (d, 250);
        var note3 = (e, 500);
        var note4 = (c, 500);

        using var waveOutEvent = new WaveOutEvent();

        var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));
        double currentTime = 0;

        foreach (var (note, duration) in new (Note, int)[12] { note1, note2, note3, note1, note2, note3, note2, note2, note2, note2, note4, note4 })
        {
            var durationWave = new NotePlayer(note).GetISampleProvider(duration);
            var delayed = new OffsetSampleProvider(durationWave)
            {
                DelayBy = TimeSpan.FromMilliseconds(currentTime)
            };

            mixer.AddMixerInput(delayed);

            currentTime += duration;
        }

        waveOutEvent.Init(mixer);
        waveOutEvent.Play();
        while (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1);
        }
    }
}