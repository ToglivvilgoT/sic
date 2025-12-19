using Sic.Models.Nodes;

namespace Sic.Models.App;

public class VisualNodeInput(int x, int y, NodeInput input)
{
    public static readonly int SIZE = 25;
    public Rectangle Rect { get; private set; } = new(x, y, SIZE, SIZE);
    public NodeInput Input { get; } = input;

    public void Move(int x, int y)
    {
        Rect = new(x, y, Rect.Width, Rect.Height);
    }

    public void Paint(PaintEventArgs e)
    {
        e.Graphics.FillRectangle(Brushes.Red, Rect);
    }
}