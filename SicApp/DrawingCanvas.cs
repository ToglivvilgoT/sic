using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Media;
using Sic.Models.Music;
using Sic.Models.Nodes;
using System.Collections.Generic;
using System.Globalization;

namespace SicApp;

public class DrawingCanvas : Control
{
    private Point mousePos;
    private Point previousMousePos;
    private readonly NodeWindow nodeWindow = new([
        new VisualNode(new NoteNode(new Note(new Pitch(0), new Duration(1, 1))), new Point(100, 100)),
        new VisualNode(new NoteNode(new Note(new Pitch(1), new Duration(1, 2))), new Point(100, 310)),
        new VisualNode(new TwoNoteNode(), new Point(600, 200)),
    ]);

    public DrawingCanvas()
    {
        PointerMoved += OnPointerMoved;
        PointerPressed += OnPointerPressed;
        PointerReleased += OnPointerReleased;
    }

    private void OnPointerMoved(object? sender, PointerEventArgs e)
    {
        previousMousePos = mousePos;
        mousePos = e.GetPosition(this);
        Vector movement = new(
            mousePos.X - previousMousePos.X,
            mousePos.Y - previousMousePos.Y
        );
        nodeWindow.OnMouseMoved(movement);
        InvalidateVisual(); // force redraw
    }

    private void OnPointerPressed(object? sender, PointerPressedEventArgs args)
    {
        var point = args.GetCurrentPoint(sender as Control);
        nodeWindow.OnMouseClicked(point.Position);
    }

    private void OnPointerReleased(object? sender, PointerReleasedEventArgs args)
    {
        nodeWindow.OnMouseReleased();
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
        nodeWindow.Render(ctx);

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
