using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Authentication;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// Represents the visual aspects of a <see cref="Sic.Models.Nodes.Node"/>
/// </summary>
public class VisualNode : Widget
{
    /// <summary>
    /// The associated Node.
    /// </summary>
    public Node Node { get; }

    /// <summary>
    /// A List of this nodes input ports.
    /// </summary>
    public List<VisualNodeInputPort> InputPorts { get; }

    /// <summary>
    /// A list of this nodes output ports.
    /// </summary>
    public List<VisualNodeOutputPort> OutputPorts { get; }

    /// <summary>
    /// The width of a VisualNode.
    /// </summary>
    private const double width = 300;

    /// <summary>
    /// Construct a new VisualNode.
    /// </summary>
    /// <param name="node">The associated Node.</param>
    /// <param name="position">The position of the top-left corner of this Node.</param>
    public VisualNode(Node node, Point position) : base(position, new(width, CalculateNodeHight(node)))
    {
        Node = node;

        InputPorts = CreateInputPorts();
        CreateInputPlayButtons();
        OutputPorts = CreateOutputPorts();
    }

    /// <summary>
    /// Creates and returns a column of input ports on the left side of the node.
    /// </summary>
    private List<VisualNodeInputPort> CreateInputPorts()
    {
        List<VisualNodeInputPort> visualInputPorts =
            SpaceBetween.CalculatePositions(
                [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, Node.InputPorts.Count)],
                Size.Height)        
            .Select(y => new Point(Position.X, Position.Y + y))
            .Zip(Node.InputPorts)
            .Select(inp => new VisualNodeInputPort(inp.First, inp.Second))
            .ToList();

        visualInputPorts.ForEach(AddChild);
        
        return visualInputPorts;
    }

    /// <summary>
    /// Creates a column of play buttons just right of every input port.
    /// </summary>
    private void CreateInputPlayButtons()
    {
        double margin = VisualNodeIOPort.iOSize.Width / 2;
        double xOffset = VisualNodeIOPort.iOSize.Width + margin;

        InputPorts
            .Select(port => (port, position : port.Position + new Point(xOffset, 0)))
            .Select(inp => new PlayButton(inp.position, VisualNodeIOPort.iOSize, inp.port.IOPort))
            .ToList()
            .ForEach(AddChild);
    }

    /// <summary>
    /// Creates and returns a column of output ports on the right side of the node.
    /// </summary>
    private List<VisualNodeOutputPort> CreateOutputPorts()
    {
        double xPosition = Position.X + Size.Width - VisualNodeIOPort.iOSize.Width;

        List<VisualNodeOutputPort> outputPorts =
            SpaceBetween.CalculatePositions(
                [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, Node.OutputPorts.Count)],
                Size.Height)
            .Select(y => new Point(xPosition, Position.Y + y))
            .Zip(Node.OutputPorts)
            .Select(inp => new VisualNodeOutputPort(inp.First, inp.Second))
            .ToList();

        outputPorts.ForEach(AddChild);

        return outputPorts;
    }

    /// <summary>
    /// Calculates and returns the height this node should have to fit all its content.
    /// </summary>
    private static double CalculateNodeHight(Node node)
    {
        int maxIO = Math.Max(node.InputPorts.Count, node.OutputPorts.Count);

        List<double> heights = [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, maxIO)];
        double spacing = VisualNodeIOPort.iOSize.Height;

        return SpaceBetween.CalculateTotalSpace(heights, spacing);
    }

    /// <summary>
    /// Draws a rectangle representing this node.
    /// </summary>
    protected override void DrawBase(WidgetDrawingContext context)
    {
        context.DrawingContext.FillRectangle(Brushes.Purple, BoundingBox);
    }

    /// <summary>
    /// Set this node as selected.
    /// </summary>
    protected override void OnClicked(WidgetClickedContext context)
    {
        context.State.SelectedNode = this;
    }
}