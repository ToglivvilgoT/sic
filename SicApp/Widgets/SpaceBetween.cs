using System.Collections.Generic;
using System.Linq;

namespace SicApp.Widgets;

/// <summary>
/// Helper class providing functionality for layout of a row/column of widgets with space between them.
/// </summary>
public static class SpaceBetween
{
    /// <summary>
    /// Calculates the total space required to fit all sizes as well as having spacing amount of spacing between them.
    /// </summary>
    /// <param name="sizes">The sizes of all widgets to layout. Should be their hights if the layout is vertical, otherwise their width.</param>
    /// <param name="spacing">How much space to add around the widgets.</param>
    /// <returns>The total space required to fit all widgets including the spacing.</returns>
    public static double CalculateTotalSpace(List<double> sizes, double spacing)
    {
        return sizes.Sum() + spacing * (sizes.Count + 1);
    }

    /// <summary>
    /// Makes a layout for widgets that occupy totalSpace.
    /// If the widgets take up less space than totalSpace, space is added around widgets.
    /// </summary>
    /// <param name="sizes">The sizes of all widgets to layout. Should be their hights if the layout is vertical, otherwise their width.</param>
    /// <param name="totalSpace">The total amount of space available.</param>
    /// <returns>A list of positions for each widget to be placed on.</returns>
    public static List<double> CalculatePositions(List<double> sizes, double totalSpace)
    {
        double totalEmpty = totalSpace - sizes.Sum();
        double emptyAround = totalEmpty / (sizes.Count + 1);

        double currentPosition = emptyAround;
        List<double> positions = [];

        foreach (double size in sizes)
        {
            positions.Add(currentPosition);
            currentPosition += size;
            currentPosition += emptyAround;
        }

        return positions;
    }
}