namespace Sic.Models.Nodes;

public static class Connection
{
    public static void Create(NodeOutputPort from, NodeInputPort to)
    {
        if (to.ConnectedPort != null)
        {
            Remove(to.ConnectedPort, to);
        }
        to.ConnectedPort = from;
        from.AddConnectedPort(to);
    }

    public static void Remove(NodeOutputPort from, NodeInputPort to)
    {
        to.ConnectedPort = null;
        from.RemoveConnectedPort(to);
    }

    public static void Toggle(NodeOutputPort from, NodeInputPort to)
    {
        if (to.ConnectedPort == from)
        {
            Remove(from, to);
        }
        else
        {
            Create(from, to);
        }
    }
}