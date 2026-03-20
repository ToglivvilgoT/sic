using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

public abstract class VisualNodeIOPort(Point position, IImmutableBrush brush) : Widget(position, iOSize)
{
    public abstract NodeIOPort IOPort { get; }
    public static readonly Size iOSize = new(32, 32);
    private readonly IImmutableBrush brush = brush;

    protected override void DrawBase(WidgetDrawingContext context)
    {
        context.DrawingContext.FillRectangle(brush, BoundingBox);
    }
}