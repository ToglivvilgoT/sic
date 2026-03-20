using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

public class VisualNodeInputPort(Point position, NodeInputPort inputPort) : VisualNodeIOPort(position, brush)
{
    private readonly static IImmutableBrush brush = Brushes.Orange;
    public override NodeInputPort IOPort { get; } = inputPort;

    protected override void OnClicked(WidgetClickedContext context)
    {
        context.NodeWindowState.ToggleSelected(this);
    }

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