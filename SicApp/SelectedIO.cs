using System;
using System.Diagnostics;

namespace SicApp;

class NodeIO
{
    public VisualNode? Node { get; private set; }
    public int Index { get; private set; }

    public NodeIO()
    {
        UnSelect();
    }

    public void Select(VisualNode node, int index)
    {
        Console.WriteLine("Selected node: " + node + ", and index: " + index);
        Node = node;
        Index = index;
    }

    public void UnSelect()
    {
        Node = null;
        Index = -1;
    }

    public bool IsSelected()
    {
        return Node != null;
    }

    public void ToggleOutputConnection(NodeIO input)
    {
        Debug.Assert(Node != null);
        Debug.Assert(input.Node != null);
        Node.ToggleOutputConnection(Index, input.Node, input.Index);
        Console.WriteLine("Toggled node: " + Node + ", to: " + input.Node);
    }
}