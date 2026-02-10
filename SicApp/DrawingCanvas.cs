using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Sic.Models.Nodes;
using System.Collections.Generic;
using System.Globalization;

namespace SicApp;

public class DrawingCanvas : Control
{
    private Point mousePos;
    private Point previousMousePos;
    private List<VisualNode> Nodes { get; } = [
        new(new NoteNode(new(new(0), new(1, 1))), new(100, 100)),
        new(new NoteNode(new(new(1), new(1, 2))), new(100, 310)),
        new(new TwoNoteNode(), new(600, 200)),
    ];

    public DrawingCanvas()
    {
        PointerMoved += OnPointerMoved;
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        previousMousePos = mousePos;
        mousePos = e.GetPosition(this);
        InvalidateVisual(); // force redraw
    }

    public override void Render(DrawingContext ctx)
    {
        base.Render(ctx);

        // Background
        ctx.FillRectangle(
            Brushes.Black,
            new Rect(Bounds.Size)
        );

        // Draw Nodes
        foreach (var node in Nodes)
        {
            node.Render(ctx);
        }

        // Circle at mouse position
        ctx.DrawEllipse(
            Brushes.Red,
            null,
            2 * mousePos - previousMousePos,
            10,
            10
        );

        // Mouse coordinates text
        var text = new FormattedText(
            $"Mouse: {mousePos.X:0}, {mousePos.Y:0}",
            CultureInfo.InvariantCulture,
            FlowDirection.LeftToRight,
            Typeface.Default,
            14,
            Brushes.White
        );

        ctx.DrawText(text, new Point(10, 10));
    }
}