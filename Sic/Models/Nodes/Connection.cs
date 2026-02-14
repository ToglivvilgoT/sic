namespace Sic.Models.Nodes;

public class Connection(Node from, int fromIndex, Node to, int toIndex)
{
    public Node From { get; } = from;
    public int FromIndex { get; } = fromIndex;
    public Node To { get; } = to;
    public int ToIndex { get; } = toIndex;

    public void RequestData()
    {
        IMusicData data = From.GetOutputData(FromIndex);
        To.SetInputData(ToIndex, data);
    }

    public void RemoveConnection()
    {
        From.RemoveOutputConnection(this);
        To.RemoveInputConnection(this);
    }
}