namespace Sic.Models.Nodes;

public class Connection(Node from, int fromIndex, Node to, int toIndex)
{
    Node From { get; } = from;
    int FromIndex { get; } = fromIndex;
    Node To { get; } = to;
    int ToIndex { get; } = toIndex;

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