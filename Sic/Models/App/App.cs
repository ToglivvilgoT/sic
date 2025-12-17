using Sic.Models.Music.Intervals;

namespace Sic.Models.App;

class App : Form
{
    private readonly List<VisualNode> nodes = [new(new(2, 3), 400, 300), new(new(0, 1), 100, 100)];
    private readonly ConnectionPositionProvider connectionPositionProvider = new();

    public App()
    {
        Text = "Sic";
        Width = 800;
        Height = 600;
        DoubleBuffered = true;

        System.Windows.Forms.Timer timer = new() { Interval = 16 };
        timer.Tick += (_, _) => AppUpdate();
        timer.Start();

        nodes[1].Outputs[0].Output.AddConnection(nodes[0].Inputs[0].Input);
        foreach (var input in nodes[0].Inputs)
        {
            connectionPositionProvider.AddInput(input);
        }
        foreach (var output in (List<VisualNodeOutput>)[.. nodes[0].Outputs, .. nodes[1].Outputs])
        {
            connectionPositionProvider.AddOutput(output);
        }
    }

    private void AppUpdate()
    {
        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        e.Graphics.Clear(Color.Black);
        foreach (var node in nodes)
        {
            node.Paint(e, connectionPositionProvider);
        }
    }

}