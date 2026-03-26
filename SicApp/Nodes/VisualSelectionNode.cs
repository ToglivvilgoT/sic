using Avalonia;
using Sic.Models.Nodes;

namespace SicApp.Nodes;

/// <summary>
/// Visual node where you can select the output from a pre given set of possible values.
/// </summary>
public class VisualSelectionNode : VisualNode
{
    /// <summary>
    /// Construct a new VisualSelectionNode.
    /// </summary>
    /// <param name="node">The underlying logical selection node.</param>
    /// <param name="position">the position of the top left corner of this node.</param>
    public VisualSelectionNode(SelectionNode node, Point position) : base(node, position)
    {
        SelectionButton button1 = new(position + new Point(Size.Width / 2 - 48, 32), node, node.PossibleValues[0]);
        SelectionButton button2 = new(position + new Point(Size.Width / 2 - 48, 128), node, node.PossibleValues[1]);
        AddChild(button1);
        AddChild(button2);
    }
}