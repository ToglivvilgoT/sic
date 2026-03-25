using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// Widget representing a <see cref="NodeInputPort"/>
/// </summary>
public class VisualNodeInputPort(Point position, NodeInputPort inputPort) : VisualNodeIOPort(position, brush)
{
    /// <summary>
    /// The color of the port.
    /// </summary>
    private readonly static IImmutableBrush brush = Brushes.Orange;

    /// <summary>
    /// The associated Input Port.
    /// </summary>
    public override NodeInputPort IOPort { get; } = inputPort;

    /// <summary>
    /// Toggles this port as the selected one.
    /// </summary>
    protected override void OnClicked(WidgetClickedContext context)
    {
        context.NodeWindowState.ToggleSelected(this);
    }

    /// <summary>
    /// Draws the base as well as a line representing the connection to a output port
    /// if this port has any connection to one.
    /// </summary>
    protected override void DrawBase(WidgetDrawingContext context)
    {
        base.DrawBase(context);
        if (IOPort.ConnectedPort != null)
        {
            var connected = context.NodeIOPortMap.GetAssociatedIOPort(IOPort.ConnectedPort);
            context.DrawingContext.DrawLine(
                new Pen(Brushes.White, 10),
                BoundingBox.Center,
                connected.BoundingBox.Center
            );
        }
    }
}