using Sic.Models.Music;

namespace Sic.Models.Nodes;

public class NoteNode(Note note) : Node([], [MusicDataType.Note])
{
    private NoteData Note { get; } = new(note);

    protected internal override void GenerateOutputData()
    {
        SetOutputDataAt(0, Note);
    }
}