namespace Sic.Models;

enum RythmName
{
    Empty,
    Whole,
    Half,
    Quarter,
    Eighth,
    Sixteenth,
    Bacon,
    Triplet,
    Pineapple,
    PizzaWith,
    Meatballs,
    Sixteenths,
}
static class Rythms
{
    public static Rythm GetRythm(RythmName name)
    {
        return _rythms[name];
    }
    private static readonly Dictionary<RythmName, Rythm> _rythms = new()
    {
        { RythmName.Empty, new Rythm([]) },
        { RythmName.Whole, new Rythm([new Duration(1, 1)]) },
        { RythmName.Half, new Rythm([new Duration(1, 2)]) },
        { RythmName.Quarter, new Rythm([new Duration(1, 4)]) },
        { RythmName.Eighth, new Rythm([new Duration(1, 8)]) },
        { RythmName.Sixteenth, new Rythm([new Duration(1, 16)]) },
        { RythmName.Bacon, new Rythm([
            new Duration(1, 8),
            new Duration(1, 8)
        ]) },
        { RythmName.Triplet, new Rythm([
            new Duration(1, 12),
            new Duration(1, 12),
            new Duration(1, 12),
        ]) },
        { RythmName.Pineapple, new Rythm([
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 8),
        ]) },
        { RythmName.PizzaWith, new Rythm([
            new Duration(1, 16),
            new Duration(1, 8),
            new Duration(1, 16),
        ]) },
        { RythmName.Meatballs, new Rythm([
            new Duration(1, 8),
            new Duration(1, 16),
            new Duration(1, 16),
        ]) },
        { RythmName.Sixteenths, new Rythm([
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 16),
        ]) },
    };
}