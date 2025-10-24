using NAudio.Wave.SampleProviders;
using NAudio.Wave;

using Sic.Models.SoundAdaptors;
using Sic.Models.TextParser;
using Sic.Models.Music;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<Note> notes = FileParser.ParseFile("music.txt");
        using var waveOutEvent = new WaveOutEvent();

        double currentTime = 0;
        var mixer = new MixingSampleProvider(WaveFormat.CreateIeeeFloatWaveFormat(44100, 1));

        foreach (var note in notes)
        {
            Console.WriteLine(note.NoteDuration.GetTime(120));
            var durationWave = new NotePlayer(note).GetISampleProvider(120);
            var delayed = new OffsetSampleProvider(durationWave)
            {
                DelayBy = TimeSpan.FromMilliseconds(currentTime)
            };

            mixer.AddMixerInput(delayed);

            currentTime += note.NoteDuration.GetTime(120) * 1000;
        }

        waveOutEvent.Init(mixer);
        waveOutEvent.Play();
        while (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1);
        }
    }
}