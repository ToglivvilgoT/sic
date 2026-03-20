using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;

namespace SicApp;

public class PlayButton(Point position, Size size, NodeIOPort musicProvider) : Widget(position, size)
{
    private readonly NodeIOPort musicProvider = musicProvider;

    protected override void DrawBase(WidgetDrawingContext context)
    {
        var geometry = new StreamGeometry();

        using (var geoCtx = geometry.Open())
        {
            geoCtx.BeginFigure(new(BoundingBox.X, BoundingBox.Y), true);
            geoCtx.LineTo(new(BoundingBox.X, BoundingBox.Bottom));
            geoCtx.LineTo(new(BoundingBox.Right, BoundingBox.Top + BoundingBox.Height / 2));
            geoCtx.EndFigure(true);
        }

        context.DrawingContext.DrawGeometry(Brushes.White, new Pen(Brushes.Black), geometry);
    }

    protected override void OnClicked(WidgetClickedContext context)
    {
        context.State.PlayMusic(musicProvider.Data);
    }
}