using System;
using System.ComponentModel.DataAnnotations;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class VisualNode(Node node, Point position)
{
    private Node Node { get; } = node;
    private Point Position { get; } = position;
    private Size Size { get; } = new Size(300, CalculateHight(node));
    private static readonly double ioSize = 32;
    private static readonly double ioSpacing = ioSize;

    public void Render(DrawingContext ctx)
    {
        ctx.FillRectangle(
            Brushes.Purple,
            new Rect(Position, Size)
        );

        double inputSpacing = (Size.Height - Node.GetInputAmount() * ioSize) / (Node.GetInputAmount() + 1);
        for (int i = 0; i < Node.GetInputAmount(); i++)
        {
            ctx.FillRectangle(
                Brushes.Orange,
                new Rect(
                    Position.X - ioSize / 2,
                    Position.Y + (i + 1) * inputSpacing + i * ioSize,
                    ioSize,
                    ioSize
                )
            );
        }
        double outputSpacing = (Size.Height - Node.GetOutputAmount() * ioSize) / (Node.GetOutputAmount() + 1);
        for (int i = 0; i < Node.GetOutputAmount(); i++)
        {
            ctx.FillRectangle(
                Brushes.Green,
                new Rect(
                    Position.X + Size.Width - ioSize / 2,
                    Position.Y + (i + 1) * outputSpacing + i * ioSize,
                    ioSize,
                    ioSize
                )
            );
        }
    }

    private static double CalculateIOHight(int ioAmount)
    {
        double totalIOSize = ioAmount * ioSize;
        double totalIOSpacing = (ioAmount + 1) * ioSpacing;

        return totalIOSize + totalIOSpacing;
    }

    private static double CalculateHight(Node node)
    {
        int maxIO = Math.Max(node.GetInputAmount(), node.GetOutputAmount());
        return CalculateIOHight(maxIO);
    }
}