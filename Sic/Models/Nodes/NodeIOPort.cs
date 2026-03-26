namespace Sic.Models.Nodes;

/// <summary>
/// Represents a node IO port.
/// Could be either an input or an output port.
/// </summary>
/// <param name="node">The node the port belongs to.</param>
/// <param name="index">The index of the port.</param>
/// <param name="type">The expected type of the music data being sent through here.</param>
public abstract class NodeIOPort(Node node, int index, NodeDataType type)
{
    /// <summary>
    /// The node the port belongs to.
    /// </summary>
    protected Node Node { get; } = node;
    /// <summary>
    /// The index of the port.
    /// </summary>
    protected int Index { get; } = index;
    /// <summary>
    /// The data stored at this port.
    /// </summary>
    public virtual INodeData Data { get; internal set; } = new NoData();
    /// <summary>
    /// The type of the data accepted at this port.
    /// </summary>
    public NodeDataType Type { get; } = type;
}