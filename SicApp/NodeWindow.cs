using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using Sic.Models.SoundAdaptors;

namespace SicApp;

class NodeWindow(List<VisualNode> nodes)
{
    private List<VisualNode> Nodes { get; } = nodes;
    private NodeWindowState State { get; } = new(new MusicPlayer(new TimedNotePlayer()));
    private INodeIOPortMap IOPortMap { get; } = new NodeIOPortMap(new Dictionary<NodeIOPort, Widget>(
        nodes
            .SelectMany(node => node.InputPorts.Cast<VisualNodeIOPort>().Concat(node.OutputPorts.Cast<VisualNodeIOPort>()))
            .Select(port => new KeyValuePair<NodeIOPort, Widget>(port.IOPort, port))));


    public void Render(DrawingContext drawingContext)
    {
        var context = new WidgetDrawingContext(drawingContext, IOPortMap);
        foreach (var node in Nodes)
        {
            node.Draw(context);
        }
    }

    public void OnMouseClicked(Point position)
    {
        var context = new WidgetClickedContext(position, State);
        foreach (var node in Nodes)
        {
            node.Clicked(context);
        }
    }

    public void OnMouseMoved(Vector movement)
    {
        if (State.SelectedNode == null)
        {
            return;
        }

        State.SelectedNode.Move(movement);
    }

    public void OnMouseReleased()
    {
        State.UnSelectVisualNode();
    }
}