using Avalonia;

namespace SicApp;

public record WidgetClickedContext(Point MousePosition, NodeWindowState State)
{
    public Point MousePosition { get; } = MousePosition;
    public NodeWindowState NodeWindowState { get; } = State;
}