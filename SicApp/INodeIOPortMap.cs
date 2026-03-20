using Sic.Models.Nodes;

namespace SicApp;

public interface INodeIOPortMap
{
    /// <summary>
    /// Maps logical NodeIOPorts to their related widget.
    /// </summary>
    /// <returns>The widget belonging to the given port.</returns>
    public Widget GetAssociatedIOPort(NodeIOPort port);
}