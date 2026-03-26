using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// Widget for <see cref="VisualSelectionNode"/> to handle a specific selectable item.
/// </summary>
internal class SelectionButton(Point position, SelectionNode selectionNode, INodeData data) : Widget(position, size)
{
    private static readonly Size size = new(96, 64);

    /// <summary>
    /// The data that will be selected when clicked.
    /// </summary>
    private readonly INodeData data = data;

    private readonly SelectionNode selectionNode = selectionNode;

    /// <summary>
    /// Set the selected data to this data.
    /// </summary>
    protected override void OnClicked(WidgetClickedContext context)
    {
        selectionNode.Selected = data;
    }

    protected override void DrawBase(WidgetDrawingContext context)
    {
        context.DrawingContext.FillRectangle(Brushes.LightSalmon, BoundingBox, 8);
    }
}