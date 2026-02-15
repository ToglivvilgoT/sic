using System;
using System.Collections.Generic;
using Sic.Models.Nodes;

namespace SicApp;

class NodeMap(Dictionary<Node, VisualNode> lookup) : INodeMap
{
    private readonly Dictionary<Node, VisualNode> lookup = lookup;

    public VisualNode GetAssociatedNode(Node node)
    {
        lookup.TryGetValue(node, out VisualNode? result);
        return result ?? throw new ArgumentException("Node has no associated VisualNode");
    }
}