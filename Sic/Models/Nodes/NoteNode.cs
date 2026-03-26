using Sic.Models.Music;

namespace Sic.Models.Nodes;

/// <summary>
/// A Node with a single hard coded note. Used for testing.
/// </summary>
public class NoteNode(Note note) : Node([], [NodeDataType.Note])
{
    private NoteData Note { get; } = new(note);

    /// <inheritdoc/>
    protected internal override void GenerateOutputData()
    {
        SetOutputDataAt(0, Note);
    }
}