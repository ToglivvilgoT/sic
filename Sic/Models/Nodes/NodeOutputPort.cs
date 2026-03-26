namespace Sic.Models.Nodes;

/// <summary>
/// Represents a specific output port on a node.
/// This is where Connections go from.
/// </summary>
/// <param name="node">The node.</param>
/// <param name="index">The index of the output port.</param>
/// <param name="type">The expected type of the music data going through here.</param>
public class NodeOutputPort(Node node, int index, NodeDataType type) : NodeIOPort(node, index, type)
{
    private readonly List<NodeInputPort> connectedPorts = [];
    internal void AddConnectedPort(NodeInputPort port)
    {
        connectedPorts.Add(port);
    }
    internal void RemoveConnectedPort(NodeInputPort port)
    {
        connectedPorts.Remove(port);
    }

    /// <inheritdoc/>
    public override INodeData Data
    {
        get
        {
            Update();
            return base.Data;
        }
        internal set => base.Data = value;
    }

    private void Update()
    {
        Node.GenerateOutputData();
    }
}