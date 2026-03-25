namespace Sic.Models.Music.Context;

/// <summary>
/// Provides a root note for song generation.
/// </summary>
public interface IRootContext
{
    /// <summary>
    /// The root pitch in this context.
    /// </summary>
    public Pitch Root { get; }
}