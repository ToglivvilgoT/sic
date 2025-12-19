using Sic.Models.Nodes;

namespace Sic.Models.App;

public class ConnectionPositionProvider
{
    private Dictionary<NodeInput, VisualNodeInput> inputDict = [];
    private Dictionary<NodeOutput, VisualNodeOutput> outputDict = [];

    public void AddInput(VisualNodeInput input)
    {
        inputDict[input.Input] = input;
    }

    public void AddOutput(VisualNodeOutput output)
    {
        outputDict[output.Output] = output;
    }

    private static Point GetCenter(Rectangle rect)
    {
        return new(rect.Left + rect.Width / 2, rect.Top + rect.Height / 2);
    }

    public Point GetPosition(NodeInput input)
    {
        return GetCenter(inputDict[input].Rect);
    }

    public Point GetPosition(NodeOutput output)
    {
        return GetCenter(outputDict[output].Rect);
    }
}