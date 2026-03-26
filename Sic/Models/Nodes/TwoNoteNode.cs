namespace Sic.Models.Nodes;

/// <summary>
/// Node that switches two notes. Used for testing.
/// </summary>
public class TwoNoteNode() : Node([NodeDataType.Note, NodeDataType.Note], [NodeDataType.Note, NodeDataType.Note])
{
    /// <inheritdoc/>
    protected internal override void GenerateOutputData()
    {
        SetOutputDataAt(0, GetInputDataAt(1));
        SetOutputDataAt(1, GetInputDataAt(0));
    }
}