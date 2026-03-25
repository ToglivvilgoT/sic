namespace Sic.Models.Music.Context;

/// <summary>
/// Provides a scale for song generation.
/// </summary>
public interface IScaleContext
{
    /// <summary>
    /// The scale of this context.
    /// </summary>
    public Scale Scale { get; }
}