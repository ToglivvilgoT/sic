using Sic.Models.Music;
using Sic.Models.Nodes;

namespace Sic.Models.SoundAdaptors;

/// <summary>
/// Handles playing of any type of musicData
/// </summary>
/// <param name="timedNotePlayer">The underlying player handling the actual playing.</param>
public class MusicPlayer(ITimedNotePlayer timedNotePlayer)
{
    private readonly ITimedNotePlayer timedNotePlayer = timedNotePlayer;
    private readonly NotePlayer notePlayer = new(timedNotePlayer);

    /// <inheritdoc/>
    public void Queue(IMusicData musicData)
    {
        switch (musicData.Type)
        {
            case MusicDataType.NoData:
                break;
            case MusicDataType.Note:
                notePlayer.Queue(((NoteData)musicData).Note);
                break;
            case MusicDataType.TimedNote:
                timedNotePlayer.Queue(((TimedNoteData)musicData).TimedNote);
                break;
            default:
                throw new NotImplementedException("The given music data " + musicData + " could not be played.");
        }
    }
}