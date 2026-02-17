namespace Sic.Models.Music.Context;

/// <summary>
/// Provides the context for the song generation.
/// 
/// If the song should be in E minor,
/// the song context will provide a minor scale and the root E.
/// </summary>
public class SongContext(Scale scale, Pitch root) : IScaleContext, IRootContext
{
    public Scale Scale { get; } = scale;

    public Pitch Root { get; } = root;
}