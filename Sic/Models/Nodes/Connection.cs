using System.Diagnostics;

namespace Sic.Models.Nodes;

/// <summary>
/// Manages connections between NodeOutputPors and NodeInputPorts.
/// </summary>
public static class Connection
{
    /// <summary>
    /// Create a new connection.
    /// If a previous connection existed that ended in to, it is first removed.
    /// This also means creating a connection that already exists does nothing.
    /// </summary>
    public static void Create(NodeOutputPort from, NodeInputPort to)
    {
        if (to.ConnectedPort != null)
        {
            Remove(to.ConnectedPort, to);
        }
        to.ConnectedPort = from;
        from.AddConnectedPort(to);
    }

    /// <summary>
    /// Remove a connection.
    /// Removing a connection that doesn't exist does nothing.
    /// </summary>
    public static void Remove(NodeOutputPort from, NodeInputPort to)
    {
        if (to.ConnectedPort != from)
        {
            return;
        }
        to.ConnectedPort = null;
        from.RemoveConnectedPort(to);
    }

    /// <summary>
    /// Toggle a connection.
    /// </summary>
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