using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// Abstract class representing either a <see cref="VisualNodeInputPort"/> or a <see cref="VisualNodeOutputPort"/>
/// </summary>
public abstract class VisualNodeIOPort(Point position, IImmutableBrush brush) : Widget(position, iOSize)
{
    /// <summary>
    /// The associated port.
    /// </summary>
    public abstract NodeIOPort IOPort { get; }

    /// <summary>
    /// The size of the port.
    /// </summary>
    public static readonly Size iOSize = new(32, 32);

    /// <summary>
    /// The color of this port.
    /// </summary>
    private readonly IImmutableBrush brush = brush;

    /// <summary>
    /// Draws this port as a rectangle.
    /// </summary>
    protected override void DrawBase(WidgetDrawingContext context)
    {
        context.DrawingContext.FillRectangle(brush, BoundingBox);
    }
}