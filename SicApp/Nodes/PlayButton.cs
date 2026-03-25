using Avalonia;
using Avalonia.Media;
using Sic.Models.Nodes;
using SicApp.Widgets;

namespace SicApp.Nodes;

/// <summary>
/// A widget for playing music when clicked.
/// </summary>
/// <param name="position">The position of the widgets top-left corner.</param>
/// <param name="size">The size of the widget.</param>
/// <param name="musicProvider">The music provider to fetch the music data from.</param>
public class PlayButton(Point position, Size size, NodeIOPort musicProvider) : Widget(position, size)
{
    /// <summary>
    /// The music provider providing the music to be played on click.
    /// </summary>
    private readonly NodeIOPort musicProvider = musicProvider;

    /// <summary>
    /// Draws a triangle representing this play button.
    /// </summary>
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

    /// <summary>
    /// Plays the music from this <see cref="musicProvider"/>
    /// </summary>
    protected override void OnClicked(WidgetClickedContext context)
    {
        context.State.PlayMusic(musicProvider.Data);
    }
}