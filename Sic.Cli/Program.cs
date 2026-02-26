using Sic.Models.Music;
using Sic.Models.Nodes;
using Sic.Models.SoundAdaptors;

TimedNotePlayer player = new();

Console.WriteLine("start");

int offset = 0;
foreach ((int pitch, int duration) in (List<(int, int)>)[(0, 1), (2, 1), (4, 1), (0, 1), (-1, 2), (-5, 2)]) {
    player.Queue(
        new TimedNote(
            new Note(
                new Pitch(pitch),
                new Duration(duration, 4)
            ),
            new Duration(offset, 4)
        )
    );
    offset += duration;
}

Console.WriteLine("play");

player.Play();

Console.WriteLine("end");