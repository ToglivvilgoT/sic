using Avalonia.Media;
using SicApp.Nodes;

namespace SicApp.Widgets;

/// <summary>
/// Context for drawing a widget.
/// </summary>
public class WidgetDrawingContext(DrawingContext drawingContext, INodeIOPortMap nodeIOPortMap)
{
    /// <summary>
    /// The DrawingContext
    /// </summary>
    public DrawingContext DrawingContext { get; } = drawingContext;

    /// <summary>
    /// A map from NodeIOPorts to their associated VisualNodeIOPort.
    /// </summary>
    public INodeIOPortMap NodeIOPortMap { get; } = nodeIOPortMap;
}