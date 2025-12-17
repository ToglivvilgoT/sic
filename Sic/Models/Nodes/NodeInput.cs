namespace Sic.Models.Nodes;

public class NodeInput
{
    public NodeOutput? Connection { get; private set; } = null;
    public void AddConnection(NodeOutput node)
    {
        Connection?.RemoveConnection(this);
        Connection = node;
    }

    public void RemoveConnection()
    {
        Connection?.RemoveConnection(this);
        Connection = null;
    }
}