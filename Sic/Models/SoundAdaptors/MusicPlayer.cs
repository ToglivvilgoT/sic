using Sic.Models.Music;
using Sic.Models.Nodes;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Handles playing of any type of musicData
/// </summary>
/// <param name="timedNotePlayer">The underlying player handling the actual playing.</param>
public class MusicPlayer(ITimedNotePlayer timedNotePlayer) : IPlayable
{
    private readonly ITimedNotePlayer timedNotePlayer = timedNotePlayer;
    private readonly NotePlayer notePlayer = new(timedNotePlayer);

    private readonly List<IPlayable> queuedToPlay = [];

    /// <inheritdoc/>
    public void Queue(IMusicData musicData)
    {
        IPlayable? player;

        switch (musicData.Type)
        {
            case MusicDataType.NoData:
                player = null;
                break;
            case MusicDataType.Note:
                notePlayer.Queue(((NoteData)musicData).Note);
                player = notePlayer;
                break;
            case MusicDataType.TimedNote:
                timedNotePlayer.Queue(((TimedNoteData)musicData).TimedNote);
                player = timedNotePlayer;
                break;
            default:
                throw new NotImplementedException("The given music data " + musicData + " could not be played.");
        }

        if (player != null && !queuedToPlay.Contains(player))
        {
            queuedToPlay.Add(player);
        }
    }

    /// <inheritdoc/>
    public void Play() {
        foreach (var player in queuedToPlay)
        {
            player.Play();
        }
    }
}