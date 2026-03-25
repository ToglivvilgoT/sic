namespace Sic.Models.Music;

/// <summary>
/// Represents a rational number with a numerator and denominator.
/// </summary>
internal class Fraction : IEquatable<Fraction>
{
    private int Numerator { get; set; }
    private int Denominator { get; set; }

    /// <summary>
    /// Create a new Fraction.
    /// </summary>
    /// <exception cref="ArgumentException">Throws if denominator is 0</exception>
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        Numerator = numerator;
        Denominator = denominator;
    }

    public double AsDouble()
    {
        return (double)Numerator / Denominator;
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        int newNumerator = a.Numerator * b.Denominator + b.Numerator * a.Denominator;
        int newDenominator = a.Denominator * b.Denominator;
        Fraction result = new(newNumerator, newDenominator);
        result.Simplify();
        return result;
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        int newNumerator = a.Numerator * b.Numerator;
        int newDenominator = a.Denominator * b.Denominator;
        Fraction result = new(newNumerator, newDenominator);
        result.Simplify();
        return result;
    }

    public static Fraction operator *(Fraction a, int b)
    {
        int newNumerator = a.Numerator * b;
        Fraction result = new(newNumerator, a.Denominator);
        result.Simplify();
        return result;
    }

    public static Fraction operator /(Fraction a, int b)
    {
        if (b == 0)
        {
            throw new ArgumentException("Cannot divide by zero.");
        }
        int newDenominator = a.Denominator * b;
        Fraction result = new(a.Numerator, newDenominator);
        result.Simplify();
        return result;
    }

    /// <summary>
    /// Simplify this by dividing numerator and denominator with their greatest common denominator.
    /// </summary>
    private void Simplify()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    /// <summary>
    /// Calculate the greatest common denominator of two integers.
    /// </summary>
    private static int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }

    public bool Equals(Fraction? other)
    {
        Simplify();
        other?.Simplify();
        return Numerator == other?.Numerator && Denominator == other?.Denominator;
    }

    public override bool Equals(object? other)
    {
        return Equals(other as Fraction);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Numerator, Denominator);
    }

    public static bool operator ==(Fraction a, Fraction b)
    {
        return a.Equals(b);
    }

    public static bool operator !=(Fraction a, Fraction b)
    {
        return !a.Equals(b);
    }

    public override string ToString()
    {
        return Numerator + "/" + Denominator;
    }
}