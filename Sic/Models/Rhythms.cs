namespace Sic.Models;

enum RhythmName
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
static class Rhythms
{
    public static Rhythm GetRhythm(RhythmName name)
    {
        return _rhythms[name];
    }
    private static readonly Dictionary<RhythmName, Rhythm> _rhythms = new()
    {
        { RhythmName.Empty, new Rhythm([]) },
        { RhythmName.Whole, new Rhythm([new Duration(1, 1)]) },
        { RhythmName.Half, new Rhythm([new Duration(1, 2)]) },
        { RhythmName.Quarter, new Rhythm([new Duration(1, 4)]) },
        { RhythmName.Eighth, new Rhythm([new Duration(1, 8)]) },
        { RhythmName.Sixteenth, new Rhythm([new Duration(1, 16)]) },
        { RhythmName.Bacon, new Rhythm([
            new Duration(1, 8),
            new Duration(1, 8)
        ]) },
        { RhythmName.Triplet, new Rhythm([
            new Duration(1, 12),
            new Duration(1, 12),
            new Duration(1, 12),
        ]) },
        { RhythmName.Pineapple, new Rhythm([
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 8),
        ]) },
        { RhythmName.PizzaWith, new Rhythm([
            new Duration(1, 16),
            new Duration(1, 8),
            new Duration(1, 16),
        ]) },
        { RhythmName.Meatballs, new Rhythm([
            new Duration(1, 8),
            new Duration(1, 16),
            new Duration(1, 16),
        ]) },
        { RhythmName.Sixteenths, new Rhythm([
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 16),
            new Duration(1, 16),
        ]) },
    };
}