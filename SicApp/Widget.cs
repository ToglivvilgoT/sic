using System.Collections.Generic;
using Avalonia;

namespace SicApp;

/// <summary>
/// Abstract class representing a widget.
/// </summary>
/// <param name="position">The position of the top-left corner of the widget.</param>
/// <param name="size">The size of this widget.</param>
public abstract class Widget(Point position, Size size)
{
    /// <summary>
    /// The bounding box of this widget used to check for mouse collisions.
    /// The widget could still be drawn outside of this bounding box.
    /// </summary>
    public Rect BoundingBox { get; private set; } = new(position, size);

    /// <summary>
    /// The current position of the widget.
    /// </summary>
    public Point Position => BoundingBox.Position;

    /// <summary>
    /// The size of the widget.
    /// </summary>
    public Size Size => BoundingBox.Size;

    /// <summary>
    /// A list of all child widgets.
    /// </summary>
    private readonly List<Widget> children = [];

    /// <summary>
    /// Adds a new child to this widget.
    /// </summary>
    public void AddChild(Widget child)
    {
        children.Add(child);
    }

    /// <summary>
    /// Draws this widget as well as all its children.
    /// </summary>
    public void Draw(WidgetDrawingContext context)
    {
        DrawBase(context);
        DrawChildren(context);
    }

    /// <summary>
    /// Draws this widget.
    /// Should be overwritten by any non-layout widget inheriting this.
    /// </summary>
    protected virtual void DrawBase(WidgetDrawingContext context)
    {
        // Does nothing by default.
    }

    /// <summary>
    /// Draws all children of this widget.
    /// </summary>
    private void DrawChildren(WidgetDrawingContext context)
    {
        foreach (var child in children)
        {
            child.Draw(context);
        }
    }

    /// <summary>
    /// Triggers <see cref="OnClicked"/> if mouse is inside of this widget.
    /// Also calls Clicked() recursively for all its children.
    /// </summary>
    /// <param name="context"></param>
    public void Clicked(WidgetClickedContext context)
    {
        if (BoundingBox.Contains(context.MousePosition))
        {
            OnClicked(context);
        }

        foreach (var child in children)
        {
            child.Clicked(context);
        }
    }

    /// <summary>
    /// Method called when widget is clicked.
    /// Should be overwritten by classes inheriting this to handle clicked events.
    /// </summary>
    protected virtual void OnClicked(WidgetClickedContext context)
    {
        // Does nothing by default
    }

    /// <summary>
    /// Move this widget and all its children.
    /// </summary>
    public void Move(Vector movement)
    {
        BoundingBox = BoundingBox.Translate(movement);

        foreach (var child in children)
        {
            child.Move(movement);
        }
    }
}