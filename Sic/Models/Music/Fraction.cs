namespace Sic.Models.Music;

class Fraction
{
    private int Numerator { get; set; }
    private int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }

        Numerator = numerator;
        Denominator = denominator;
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

    private void Simplify()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

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
}