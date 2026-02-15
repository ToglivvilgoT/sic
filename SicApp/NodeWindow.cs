using System.Collections.Generic;
using System.Linq;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class NodeWindow
{
    public NodeWindow(List<VisualNode> nodes)
    {
        Nodes = nodes;
        nodeMap = new NodeMap(nodes.Select((node) => (node.Node, node)).ToDictionary());
        nodes.ForEach((node) => node.SetNodeMap(nodeMap));
    }
    private List<VisualNode> Nodes { get; }
    private NodeMap nodeMap;
    private NodeIO selectedInput = new();
    private NodeIO selectedOutput = new();


    public void Render(DrawingContext ctx)
    {
        foreach (var node in Nodes)
        {
            node.Render(ctx);
        }
    }

    public void OnClicked(Point position)
    {
        foreach (var node in Nodes)
        {
            if (node.HasCollision(position))
            {
                if (node.HasInputCollision(position))
                {
                    selectedInput.Select(node, node.GetCollidingInputIndex(position));
                }
                else if (node.HasOutputCollision(position))
                {
                    selectedOutput.Select(node, node.GetCollidingOutputIndex(position));
                }

                if (selectedInput.IsSelected() && selectedOutput.IsSelected())
                {
                    selectedOutput.ToggleOutputConnection(selectedInput);
                    selectedInput.UnSelect();
                    selectedOutput.UnSelect();
                }
            }
        }
    }
}