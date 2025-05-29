class Duration
{
    private Fraction Length { get; set; }

    public Duration(int beats, int divisions)
    {
        if (divisions <= 0 || beats <= 0)
        {
            throw new ArgumentException("Beats and divisions must be positive integers.");
        }

        Length = new Fraction(beats, divisions);
    }
}