namespace Sic.Models.Nodes;

/// <summary>
/// Represents a specific input port on a node.
/// This is where Connections go to.
/// </summary>
/// <param name="node">The node.</param>
/// <param name="index">The index of the input port.</param>
/// <param name="type">The expected type of the data going here.</param>
public class NodeInputPort(Node node, int index, NodeDataType type) : NodeIOPort(node, index, type)
{
    /// <summary>
    /// The connected output port. Null if no port is connected to this.
    /// </summary>
    public NodeOutputPort? ConnectedPort { get; internal set; }

    /// <summary>
    /// The data located at this port.
    /// Getting it will fetch the data from the connected output port.
    /// </summary>
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
        Data = ConnectedPort?.Data ?? new NoData();
    }
}