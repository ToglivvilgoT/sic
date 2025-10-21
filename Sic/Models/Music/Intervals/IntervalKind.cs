namespace Sic.Models.Music.Intervals;

[Flags]
public enum IntervalKind
{
    Perfect = 1,
    NonPerfect = 2,
}

public static class IntervalKindMethods
{
    public static IntervalKind FromSemitones(int semitones)
    {
        semitones = Math.Abs(semitones) % 12; // "Normalize" the interval to be in one (positive) octave.
        bool isUnison = semitones == 0;
        bool isFourthOrFifth = semitones >= 5 && semitones <= 7;
        if (isUnison || isFourthOrFifth)
        {
            return IntervalKind.Perfect;
        }
        else
        {
            return IntervalKind.NonPerfect;
        }
    }
}