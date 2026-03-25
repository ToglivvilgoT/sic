using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// A Map from NodeIOPorts to their associated VisualNodeIOPort.
/// </summary>
public interface INodeIOPortMap
{
    /// <summary>
    /// Maps logical NodeIOPorts to their related widget.
    /// </summary>
    /// <returns>The widget belonging to the given port.</returns>
    public Widget GetAssociatedIOPort(NodeIOPort port);
}