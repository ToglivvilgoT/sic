using System.Collections.Generic;
using System.Linq;

namespace SicApp;

public static class SpaceBetween
{
    public static double CalculateTotalSpace(List<double> sizes, double spacing)
    {
        return sizes.Sum() + spacing * (sizes.Count + 1);
    }

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