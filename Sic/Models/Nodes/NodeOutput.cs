namespace Sic.Models.Nodes;

public class NodeOutput
{
    public List<NodeInput> Connections { get; private set; } = [];

    public void AddConnection(NodeInput node)
    {
        Connections.Add(node);
    }

    public void RemoveConnection(NodeInput node)
    {
        Connections.Remove(node);
    }
}