using Sic.Models.Nodes;

namespace SicApp;

interface INodeMap
{
    public VisualNode GetAssociatedNode(Node node);
}