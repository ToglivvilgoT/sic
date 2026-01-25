using Sic.Models.Music;

namespace Sic.Models.Nodes;

public class NoteNode(Note note) : Node([], [MusicDataType.Note])
{
    NoteData Note { get; } = new(note);

    protected override void GenerateOutputData()
    {
        SetOutputDataAt(0, Note);
    }
}