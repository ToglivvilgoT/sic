namespace Sic.Models.Nodes;

public abstract class Node
{
    public Node(MusicDataType[] inputTypes, MusicDataType[] outputTypes)
    {
        InputPorts = [.. inputTypes.Select((type, index) => new NodeInputPort(this, index, type))];
        OutputPorts = [.. outputTypes.Select((type, index) => new NodeOutputPort(this, index, type))];
    }
    public List<NodeInputPort> InputPorts { get; }
    public List<NodeOutputPort> OutputPorts { get; } = [];

    internal protected abstract void GenerateOutputData();

    protected void SetOutputDataAt(int index, IMusicData data)
    {
        OutputPorts[index].Data = data;
    }

    protected IMusicData GetInputDataAt(int index)
    {
        return InputPorts[index].Data;
    }
}