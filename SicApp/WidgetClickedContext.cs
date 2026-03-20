using Avalonia;

namespace SicApp;

/// <summary>
/// Provided context for when a widget is clicked.
/// </summary>
public record WidgetClickedContext(Point MousePosition, NodeWindowState State)
{
    /// <summary>
    /// The position of the mouse.
    /// </summary>
    public Point MousePosition { get; } = MousePosition;

    /// <summary>
    /// The state of the NodeWindow where the widget lies.
    /// </summary>
    public NodeWindowState NodeWindowState { get; } = State;
}