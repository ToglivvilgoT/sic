using NAudio.Wave.SampleProviders;
using NAudio.Wave;

using Sic.Models.SoundAdaptors;
using Sic.Models.TextParser;
using Sic.Models.Music;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<Tone> notes = FileParser.ParseFile("music.txt");
        using var waveOutEvent = new WaveOutEvent();

        double currentTime = 0;
        var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));

        foreach (var (note, duration) in notes.Zip([500, 500, 177, 177, 177, 500, 500, 177, 177, 177, 500, 500, 177, 177, 177, 1000]))
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