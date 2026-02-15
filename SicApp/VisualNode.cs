using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Controls.Shapes;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class VisualNode(Node node, Point position)
{
    public Node Node { get; } = node;
    private Point Position { get; } = position;
    private Size Size { get; } = new Size(width, CalculateNodeHight(node));
    private Rect Collider { get { return new(Position, Size); } }
    private readonly List<Rect> inputColliders = GetInputColliders(node, position);
    private readonly List<Rect> outputColliders = GetOutputColliders(node, position + new Point (width - ioSize, 0));
    private readonly List<Line> outputConnections = [];
    private INodeMap? nodeMap = null;
    private static readonly double width = 300;
    private static readonly double ioSize = 32;
    private static readonly double ioSpacing = ioSize;

    public void Render(DrawingContext ctx)
    {
        RenderBody(ctx);
        RenderIO(ctx);
        RenderConnections(ctx);
    }

    private void RenderBody(DrawingContext ctx)
    {
        ctx.FillRectangle(
            Brushes.Purple,
            Collider
        );
    }

    private void RenderIO(DrawingContext ctx)
    {
        RenderRectList(ctx, inputColliders, Brushes.Orange);
        RenderRectList(ctx, outputColliders, Brushes.Green);
    }

    private static void RenderRectList(DrawingContext ctx, List<Rect> rects, IImmutableBrush brush)
    {
        foreach (var rect in rects)
        {
            ctx.FillRectangle(brush, rect);
        }
    }

    private void RenderConnections(DrawingContext ctx)
    {
        Debug.Assert(nodeMap != null, "nodeMap must be set before trying to render connections.");

        foreach (var con in Node.OutputConnections)
        {
            VisualNode inputNode = nodeMap.GetAssociatedNode(con.To);
            ctx.DrawLine(
                new Pen(Brushes.White),
                GetOutputPosition(con.FromIndex),
                inputNode.GetInputPosition(con.ToIndex)
            );
        }
    }

    private Point GetInputPosition(int index)
    {
        return inputColliders[index].Position;
    }

    private Point GetOutputPosition(int index)
    {
        return outputColliders[index].Position;
    }

    public void SetNodeMap(INodeMap nodeMap)
    {
        this.nodeMap = nodeMap;
    }

    public bool HasCollision(Point position)
    {
        return Collider.Contains(position);
    }

    public bool HasInputCollision(Point position)
    {
        return HasIOCollision(position, inputColliders);
    }

    public bool HasOutputCollision(Point position)
    {
        return HasIOCollision(position, outputColliders);
    }

    private static bool HasIOCollision(Point position, List<Rect> ioColliders)
    {
        return ioColliders.Any((output) => output.Contains(position));

    }
    
    public int GetCollidingInputIndex(Point position)
    {
        return GetCollidingIOIndex(position, inputColliders);
    }

    public int GetCollidingOutputIndex(Point position)
    {
        return GetCollidingIOIndex(position, outputColliders);
    }

    private static int GetCollidingIOIndex(Point position, List<Rect> ioColliders)
    {
        return ioColliders.Select((output, index) => (output, index))
                              .FirstOrDefault((e) => e.output.Contains(position))
                              .index;
    }

    public void ToggleOutputConnection(int outputIndex, VisualNode inputNode, int inputIndex)
    {
        Node.ToggleOutputConnection(outputIndex, inputNode.Node, inputIndex);
    }

    private static List<Rect> GetInputColliders(Node node, Point position)
    {
        int inputAmount = node.GetInputAmount();
        double inputSpacing = CalculateIOSpacing(inputAmount);
        return Enumerable.Range(0, inputAmount)
                         .Select(i => CalculateIORect(position, inputSpacing, i))
                         .ToList();
    }

    private static Rect CalculateIORect(Point position, double ioSpacing, int index)
    {
        double x = position.X;
        double y = position.Y + ioSpacing * (index + 1) + ioSize * index;
        double width = ioSize;
        double height = ioSize;
        
        return new Rect(x, y, width, height);
    }

    private static List<Rect> GetOutputColliders(Node node, Point topLeft)
    {
        int outputAmount = node.GetOutputAmount();
        double outputSpacing = CalculateIOSpacing(outputAmount);
        return Enumerable.Range(0, outputAmount)
                         .Select(i => CalculateIORect(topLeft, outputSpacing, i))
                         .ToList();
    }

    private static double CalculateIOSpacing(int ioAmount)
    {
        double totalHeight = CalculateTotalIOHight(ioAmount);
        double totalSpace = totalHeight - ioAmount * ioSize;
        return totalSpace / (ioAmount + 1);
    }

    private static double CalculateNodeHight(Node node)
    {
        int maxIO = Math.Max(node.GetInputAmount(), node.GetOutputAmount());
        return CalculateTotalIOHight(maxIO);
    }

    private static double CalculateTotalIOHight(int ioAmount)
    {
        return CalculateTotalIOSize(ioAmount) + CalculateTotalIOSpacing(ioAmount);
    }

    private static double CalculateTotalIOSpacing(int ioAmount)
    {
        return (ioAmount + 1) * ioSpacing;
    }

    private static double CalculateTotalIOSize(int ioAmount)
    {
        return ioAmount * ioSize;
    }
}