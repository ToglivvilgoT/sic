namespace Sic.Models.Music.Context;

/// <summary>
/// Provides a root note for song generation.
/// </summary>
public interface IRootContext
{
    public Tone Root { get; }
}