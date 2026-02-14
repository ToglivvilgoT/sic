using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Avalonia;
using Avalonia.Controls.Primitives.PopupPositioning;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class VisualNode(Node node, Point position)
{
    private Node Node { get; } = node;
    private Point Position { get; } = position;
    private Size Size { get; } = new Size(width, CalculateNodeHight(node));
    private Rect Collider { get { return new(Position, Size); } }
    private readonly List<Rect> inputColliders = GetInputColliders(node, position);
    private readonly List<Rect> outputColliders = GetOutputColliders(node, position + new Point (width - ioSize, 0));
    private static readonly double width = 300;
    private static readonly double ioSize = 32;
    private static readonly double ioSpacing = ioSize;

    public void Render(DrawingContext ctx)
    {
        ctx.FillRectangle(
            Brushes.Purple,
            Collider
        );

        foreach (var input in inputColliders)
        {
            ctx.FillRectangle(Brushes.Orange, input);
        }

        foreach (var output in outputColliders)
        {
            ctx.FillRectangle(Brushes.Green, output);
        }
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