using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

public class VisualNode : Widget
{
    public Node Node { get; }
    public List<VisualNodeInputPort> InputPorts { get; }
    public List<VisualNodeOutputPort> OutputPorts { get; }
    private static readonly double width = 300;

    public VisualNode(Node node, Point position) : base(position, new(width, CalculateNodeHight(node)))
    {
        Node = node;

        var inputYPositions =
            SpaceBetween.CalculatePositions(
                [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, node.InputPorts.Count)],
                Size.Height);
        
        InputPorts = inputYPositions
            .Select(y => new Point(position.X, position.Y + y))
            .Zip(node.InputPorts)
            .Select(inp => new VisualNodeInputPort(inp.First, inp.Second))
            .ToList();

        InputPorts.ForEach(AddChild);

        double margin = VisualNodeIOPort.iOSize.Width / 2;
        double playButtonX = position.X + VisualNodeIOPort.iOSize.Width + margin;

        inputYPositions
            .Select(y => new Point(playButtonX, position.Y + y))
            .Zip(node.InputPorts)
            .Select(inp => new PlayButton(inp.First, VisualNodeIOPort.iOSize, inp.Second))
            .ToList()
            .ForEach(AddChild);

        var outputYPositions =
            SpaceBetween.CalculatePositions(
                [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, node.OutputPorts.Count)],
                Size.Height);

        double outputPortX = position.X + Size.Width - VisualNodeIOPort.iOSize.Width;

        OutputPorts = outputYPositions
            .Select(y => new Point(outputPortX, position.Y + y))
            .Zip(node.OutputPorts)
            .Select(inp => new VisualNodeOutputPort(inp.First, inp.Second))
            .ToList();

        OutputPorts.ForEach(AddChild);
    }

    private static double CalculateNodeHight(Node node)
    {
        int maxIO = Math.Max(node.InputPorts.Count, node.OutputPorts.Count);

        List<double> heights = [.. Enumerable.Repeat(VisualNodeIOPort.iOSize.Height, maxIO)];
        double spacing = VisualNodeIOPort.iOSize.Height;

        return SpaceBetween.CalculateTotalSpace(heights, spacing);
    }

    protected override void DrawBase(WidgetDrawingContext context)
    {
        context.DrawingContext.FillRectangle(Brushes.Purple, BoundingBox);
    }

    protected override void OnClicked(WidgetClickedContext context)
    {
        context.State.ToggleSelected(this);
    }
}