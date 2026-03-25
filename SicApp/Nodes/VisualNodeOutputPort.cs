using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// Widget representing an output port.
/// </summary>
public class VisualNodeOutputPort(Point position, NodeOutputPort outputPort) : VisualNodeIOPort(position, brush)
{
    /// <summary>
    /// The color of the port.
    /// </summary>
    private readonly static IImmutableBrush brush = Brushes.Green;

    /// <summary>
    /// The associated output port.
    /// </summary>
    public override NodeOutputPort IOPort { get; } = outputPort;

    /// <summary>
    /// Toggle this as selected.
    /// </summary>
    protected override void OnClicked(WidgetClickedContext context)
    {
        context.NodeWindowState.ToggleSelected(this);
    }
}