using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using Sic.Models.SoundAdaptors;

namespace SicApp;

/// <summary>
/// Represents a window of connected nodes.
/// Shows all nodes and connections as well as managing them by creating, moving
/// or connecting them based on user input.
/// Song creation is split up into multiple NodeWindows to separate different
/// parts of the song. The NodeWindows are later connected to create the full
/// song. Not that nodes can not be connected between NodeWindows.
/// </summary>
public class NodeWindow(List<VisualNode> nodes)
{
    /// <summary>
    /// All the nodes in this NodeWindow
    /// </summary>
    private List<VisualNode> Nodes { get; } = nodes;

    /// <summary>
    /// The state of this NodeWindow.
    /// </summary>
    private NodeWindowState State { get; } = new(new MusicPlayer(new TimedNotePlayer()));

    /// <summary>
    /// A map from the Nodes input and output ports to their visual counterpart.
    /// </summary>
    private INodeIOPortMap IOPortMap { get; } = new NodeIOPortMap(new Dictionary<NodeIOPort, Widget>(
        nodes
            .SelectMany(node => node.InputPorts.Cast<VisualNodeIOPort>().Concat(node.OutputPorts.Cast<VisualNodeIOPort>()))
            .Select(port => new KeyValuePair<NodeIOPort, Widget>(port.IOPort, port))));

    /// <summary>
    /// Render all Nodes of this Window.
    /// </summary>
    public void Render(DrawingContext drawingContext)
    {
        var context = new WidgetDrawingContext(drawingContext, IOPortMap);
        foreach (var node in Nodes)
        {
            node.Draw(context);
        }
    }

    /// <summary>
    /// Updates all Nodes with information about the mouse being clicked.
    /// </summary>
    public void OnMouseClicked(Point mousePosition)
    {
        var context = new WidgetClickedContext(mousePosition, State);
        foreach (var node in Nodes)
        {
            node.Clicked(context);
        }
    }

    /// <summary>
    /// Moves the selected Node if any is selected, nothing happens otherwise.
    /// </summary>
    public void OnMouseMoved(Vector movement)
    {
        if (State.SelectedNode == null)
        {
            return;
        }

        State.SelectedNode.Move(movement);
    }

    /// <summary>
    /// Unselects the currently selected Node.
    /// </summary>
    public void OnMouseReleased()
    {
        State.SelectedNode = null;
    }
}