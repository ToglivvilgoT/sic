using Sic.Models.Music;

namespace Sic.Models.Nodes;

/// <summary>
/// Node that can select from two different notes. Used for testing.
/// </summary>
public class NoteSelectionNode() : SelectionNode(
    [
        new NoteData(new Note(new Pitch(0), new Duration(1, 4))),
        new NoteData(new Note(new Pitch(4), new Duration(1, 4))),
    ],
    NodeDataType.AbsoluteInterval)
{
}