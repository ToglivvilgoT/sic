using Sic.Models.Nodes;

namespace Sic.Models.App;

public class VisualNode(Node node, int x, int y)
{
    private static int width = 200;
    private static int height = 100;
    private Rectangle Rect { get; set; } = new(x, y, width, height);
    private Node Node { get; } = node;
    private static Point GetPositionOffsetForIO(bool isInput, int index, int total)
    {
        int ioSize = isInput ? VisualNodeInput.SIZE : VisualNodeOutput.SIZE;  // the size of the io node
        int spaceAround = (height - ioSize * total) / (total + 1);  // the empty space between the io nodes.
        int yOffset = (index + 1) * spaceAround + index * ioSize;
        int xOffset = isInput ? 0 : width;
        int centerOffset = ioSize / 2;  // set position based on top left corner instead of center of node.
        xOffset -= centerOffset;
        return new(xOffset, yOffset);
    }
    public List<VisualNodeInput> Inputs { get; } = [.. node.Inputs.Select((input, index) => {
        Point offset = GetPositionOffsetForIO(true, index, node.Inputs.Count);
        return new VisualNodeInput(x + offset.X, y + offset.Y, input);
    })];
    public List<VisualNodeOutput> Outputs { get; } = [.. node.Outputs.Select((output, index) => {
        Point offset = GetPositionOffsetForIO(false, index, node.Outputs.Count);
        return new VisualNodeOutput(x + offset.X, y + offset.Y, output);
    })];

    public void Paint(PaintEventArgs e, ConnectionPositionProvider conPos)
    {
        e.Graphics.FillRectangle(Brushes.BlueViolet, Rect);
        foreach (var input in Inputs)
        {
            input.Paint(e);
        }
        foreach (var output in Outputs)
        {
            output.Paint(e, conPos);
        }
    }
}