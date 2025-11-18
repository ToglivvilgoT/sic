using NAudio.Wave.SampleProviders;
using NAudio.Wave;

using Sic.Models.SoundAdaptors;
using Sic.Models.TextParser;
using Sic.Models.Music;
using Sic.Models.Music.Chords;
using Sic.Art;

class Program
{
    static void Main(string[] args)
    {
        CoolDogPiano.PrintAscii();
        CoolDogPiano.SaveSvgTo("./dog.svg");
        IEnumerable<Note> notes = FileParser.ParseFile("music.txt");
        using var waveOutEvent = new WaveOutEvent();
        /*

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
        */

        var chord = new RootedChordParser().TryParse(new StringReader("CM"));
        var mixer = new ToneSequencePlayer(chord).GetISampleProvider(1000);

        waveOutEvent.Init(mixer);
        waveOutEvent.Play();
        while (waveOutEvent.PlaybackState == PlaybackState.Playing)
        {
            Thread.Sleep(1);
        }
    }
}