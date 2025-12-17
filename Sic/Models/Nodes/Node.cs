namespace Sic.Models.Nodes;

public class Node(int inputs, int outputs)
{
    public List<NodeInput> Inputs { get; } = [.. Enumerable.Range(0, inputs).Select((_) => new NodeInput())];
    public List<NodeOutput> Outputs { get; } = [.. Enumerable.Range(0, outputs).Select((_) => new NodeOutput())];
}