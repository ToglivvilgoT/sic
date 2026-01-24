using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;

using System.Globalization;

namespace SicApp;

public class DrawingCanvas : Control
{
    private Point mousePos;
    private Point previousMousePos;

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

        // A rectangle
        ctx.DrawRectangle(
            Brushes.Transparent,
            new Pen(Brushes.White, 2),
            new Rect(50, 50, 200, 120)
        );

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