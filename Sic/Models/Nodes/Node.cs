namespace Sic.Models.Nodes;

/// <summary>
/// Represents a logical node used to receive, send and process music data.
/// </summary>
public abstract class Node
{
    /// <summary>
    /// Construct a new Node with a given set of inputs and outputs.
    /// </summary>
    public Node(NodeDataType[] inputTypes, NodeDataType[] outputTypes)
    {
        InputPorts = [.. inputTypes.Select((type, index) => new NodeInputPort(this, index, type))];
        OutputPorts = [.. outputTypes.Select((type, index) => new NodeOutputPort(this, index, type))];
    }
    /// <summary>
    /// A List of all the inputs of the node.
    /// </summary>
    public List<NodeInputPort> InputPorts { get; }
    /// <summary>
    /// A List of all the outputs of the node.
    /// </summary>
    public List<NodeOutputPort> OutputPorts { get; } = [];

    /// <summary>
    /// Generates and sets the data at the output ports.
    /// </summary>
    internal protected abstract void GenerateOutputData();

    /// <summary>
    /// Sets the data of a given output port.
    /// </summary>
    /// <param name="index">The index of the output port to set the data at.</param>
    /// <param name="data">The data to set.</param>
    protected void SetOutputDataAt(int index, INodeData data)
    {
        OutputPorts[index].Data = data;
    }

    /// <summary>
    /// Gets the data at a given input port.
    /// </summary>
    /// <param name="index">The index of the port to get the data from.</param>
    /// <returns>The data.</returns>
    protected INodeData GetInputDataAt(int index)
    {
        return InputPorts[index].Data;
    }
}