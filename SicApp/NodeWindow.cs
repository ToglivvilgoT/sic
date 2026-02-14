using System;
using System.Collections.Generic;
using System.Diagnostics;
using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

class NodeWindow(List<VisualNode> nodes)
{
    private List<VisualNode> Nodes { get; } = nodes;
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