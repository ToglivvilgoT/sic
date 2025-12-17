using Sic.Models.Nodes;

namespace Sic.Models.App;

public class VisualNode(Node node, int x, int y)
{
    private static int width = 200;
    private static int height = 100;
    private Rectangle Rect { get; set; } = new(x, y, width, height);
    private Node Node { get; } = node;
    public List<VisualNodeInput> Inputs { get; } = [.. node.Inputs.Select((input) => new VisualNodeInput(x, y + height / 2, input))];
    public List<VisualNodeOutput> Outputs { get; } = [.. node.Outputs.Select((output) => new VisualNodeOutput(x + width, y + height / 2, output))];

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