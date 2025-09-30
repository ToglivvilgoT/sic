using Sic.Models.Intervals;
using Sic.Models;
using NAudio.Wave.SampleProviders;
using NAudio.Wave;
using Sic.Models.SoundPlayer;

class Program
{
    static void Main(string[] args)
    {
        var c = new Note(0);
        var d = c + new AbsoluteInterval(new(1), IntervalType.Major);
        var e = c + new AbsoluteInterval(new(2), IntervalType.Major);
        var note1 = NotePlayer.GetNoteWithduration(NotePlayer.GetNote(c), 125);
        var note2 = NotePlayer.GetNoteWithduration(NotePlayer.GetNote(d), 125);
        var note3 = NotePlayer.GetNoteWithduration(NotePlayer.GetNote(e), 250);
        var note4 = NotePlayer.GetNoteWithduration(NotePlayer.GetNote(c), 250);

        using var wo = new WaveOutEvent();
        foreach (var note in new ISampleProvider[12] { note1, note2, note3, note1, note2, note3, note2, note2, note2, note2, note4, note4 })
        {
            wo.Init(note);
            wo.Play();
            while (wo.PlaybackState == PlaybackState.Playing)
            {
                Thread.Sleep(1);
            }
        }
    }
}