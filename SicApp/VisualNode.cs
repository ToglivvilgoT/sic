using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class VisualNode(Node node, Point position)
{
    public Node Node { get; } = node;
    private Point Position { get; set; } = position;
    private Size Size { get; } = new Size(width, CalculateNodeHight(node));
    private Rect Collider { get { return new(Position, Size); } }
    private readonly List<Rect> inputColliders = GetInputColliders(node, position);
    private readonly List<Rect> outputColliders = GetOutputColliders(node, position + new Point (width - ioSize, 0));
    private IEnumerable<Rect> PlayButtonColliders => outputColliders.Select((rect) => rect.Translate(new(-ioSize - 8, 0)));
    private INodeMap? nodeMap = null;
    private static readonly double width = 300;
    private static readonly double ioSize = 32;
    private static readonly double ioSpacing = ioSize;

    public void RenderBase(DrawingContext ctx)
    {
        RenderBody(ctx);
        RenderIO(ctx);
    }

    public void RenderTop(DrawingContext ctx)
    {
        RenderConnections(ctx);
        RenderPlayButton(ctx);
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
                new Pen(Brushes.White, 8),
                GetOutputPosition(con.FromIndex),
                inputNode.GetInputPosition(con.ToIndex)
            );
        }
    }

    private void RenderPlayButton(DrawingContext ctx)
    {
        foreach (Rect collider in PlayButtonColliders)
        {
            var geometry = new StreamGeometry();

            using (var geoCtx = geometry.Open())
            {
                geoCtx.BeginFigure(new(collider.X, collider.Y), true);
                geoCtx.LineTo(new(collider.X, collider.Y + ioSize));
                geoCtx.LineTo(new(collider.X + ioSize, collider.Y + ioSize / 2));
                geoCtx.EndFigure(true);
            }

            ctx.DrawGeometry(Brushes.White, new Pen(Brushes.Black), geometry);
        }
    }

    private Point GetInputPosition(int index)
    {
        return inputColliders[index].Center;
    }

    private Point GetOutputPosition(int index)
    {
        return outputColliders[index].Center;
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
        return HasAnyCollision(position, inputColliders);
    }

    public bool HasOutputCollision(Point position)
    {
        return HasAnyCollision(position, outputColliders);
    }

    public bool HasPlayButtonCollision(Point position)
    {
        return HasAnyCollision(position, PlayButtonColliders);
    }

    private static bool HasAnyCollision(Point position, IEnumerable<Rect> colliders)
    {
        return colliders.Any((collider) => collider.Contains(position));

    }
    
    public int GetCollidingInputIndex(Point position)
    {
        return GetCollidingIndex(position, inputColliders);
    }

    public int GetCollidingOutputIndex(Point position)
    {
        return GetCollidingIndex(position, outputColliders);
    }

    public int GetCollidingPlayButtonIndex(Point position)
    {
        return GetCollidingIndex(position, PlayButtonColliders);
    }

    private static int GetCollidingIndex(Point position, IEnumerable<Rect> colliders)
    {
        return colliders.Select((collider, index) => (collider, index))
                              .FirstOrDefault((e) => e.collider.Contains(position))
                              .index;
    }

    public void ToggleOutputConnection(int outputIndex, VisualNode inputNode, int inputIndex)
    {
        Node.ToggleOutputConnection(outputIndex, inputNode.Node, inputIndex);
    }

    public void Move(Vector movement)
    {
        Position += movement;
        for (int i = 0; i < inputColliders.Count; i++)
        {
            inputColliders[i] = inputColliders[i].Translate(movement);
        }
        for (int i = 0; i < outputColliders.Count; i++)
        {
            outputColliders[i] = outputColliders[i].Translate(movement);
        }
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