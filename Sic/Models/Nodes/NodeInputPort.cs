namespace Sic.Models.Nodes;

/// <summary>
/// Represents a specific input port on a node.
/// This is where Connections go to.
/// </summary>
/// <param name="node">The node.</param>
/// <param name="index">The index of the input port.</param>
public class NodeInputPort(Node node, int index, MusicDataType type) : NodeIOPort(node, index, type)
{
    public NodeOutputPort? ConnectedPort { get; internal set; }

    /// <summary>
    /// Sets the data of this port.
    /// </summary>
    public override IMusicData Data
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