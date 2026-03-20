using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

public class VisualNodeOutputPort(Point position, NodeOutputPort outputPort) : VisualNodeIOPort(position, brush)
{
    private readonly static IImmutableBrush brush = Brushes.Green;
    public override NodeOutputPort IOPort { get; } = outputPort;

    protected override void OnClicked(WidgetClickedContext context)
    {
        context.NodeWindowState.ToggleSelected(this);
    }
}