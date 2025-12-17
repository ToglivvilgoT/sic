using Sic.Models.Nodes;

namespace Sic.Models.App;

public class VisualNodeOutput(int x, int y, NodeOutput output)
{
    private static readonly int size = 25;
    public Rectangle Rect { get; private set; } = new(x, y, size, size);
    public NodeOutput Output { get; } = output;

    public void Move(int x, int y)
    {
        Rect = new(x, y, Rect.Width, Rect.Height);
    }

    public void Paint(PaintEventArgs e, ConnectionPositionProvider conPos)
    {
        e.Graphics.FillRectangle(Brushes.Red, Rect);
        foreach (var connection in Output.Connections)
        {
            e.Graphics.DrawLine(Pens.Green, conPos.GetPosition(connection), conPos.GetPosition(output));
        }
    }
}