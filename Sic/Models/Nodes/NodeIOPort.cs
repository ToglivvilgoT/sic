namespace Sic.Models.Nodes;

/// <summary>
/// Represents a node IO port.
/// Could be either an input or an output port.
/// </summary>
/// <param name="node">The node the port belongs to.</param>
/// <param name="index">The index of the port.</param>
public abstract class NodeIOPort(Node node, int index, MusicDataType type)
{
    /// <summary>
    /// The node the port belongs to.
    /// </summary>
    protected Node Node { get; } = node;
    /// <summary>
    /// The index of the port.
    /// </summary>
    protected int Index { get; } = index;
    public virtual IMusicData Data { get; internal set; } = new NoData();
    public MusicDataType Type { get; } = type;
}