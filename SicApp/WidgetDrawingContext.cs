using Avalonia.Media;

namespace SicApp;

public class WidgetDrawingContext(DrawingContext drawingContext, INodeIOPortMap nodeIOPortMap)
{
    public DrawingContext DrawingContext { get; } = drawingContext;
    public INodeIOPortMap NodeIOPortMap { get; } = nodeIOPortMap;
}