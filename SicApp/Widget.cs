using System;
using System.Collections.Generic;
using Avalonia;

namespace SicApp;

public abstract class Widget(Point position, Size size)
{
    public Rect BoundingBox { get; private set; } = new(position, size);
    public Size Size => BoundingBox.Size;
    private readonly List<Widget> children = [];

    public void AddChild(Widget child)
    {
        children.Add(child);
    }

    public void Draw(WidgetDrawingContext context)
    {
        DrawBase(context);
        DrawChildren(context);
    }

    protected virtual void DrawBase(WidgetDrawingContext context)
    {
        // Does nothing by default.
    }

    private void DrawChildren(WidgetDrawingContext context)
    {
        foreach (var child in children)
        {
            child.Draw(context);
        }
    }

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

    protected virtual void OnClicked(WidgetClickedContext context)
    {
        // Does nothing by default
    }

    public void Move(Vector movement)
    {
        BoundingBox = BoundingBox.Translate(movement);

        foreach (var child in children)
        {
            child.Move(movement);
        }
    }
}