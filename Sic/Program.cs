using NAudio.Wave;

using Sic.Models.SoundAdaptors;
using Sic.Models.TextParser;
using Sic.Models.Music;
using Sic.Models.Music.Melodies;
using Sic.Models.App;

class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Application.Run(new App());
        /*
        Melody melody = FileParser.ParseFile("music.txt");
        ScaleMelody scaleMelody = new(Scale.GetMajor(), melody);
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

        var mixer = new TimedNoteSequencePlayer(scaleMelody.GetTimedNotes(new(0))).GetISampleProvider(120);

        waveOutEvent.Init(mixer);
        waveOutEvent.Play();
        while (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1);
        }
        */
    }
}