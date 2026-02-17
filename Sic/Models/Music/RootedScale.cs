using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

public class RootedScale(Scale scale, Pitch root)
{
    private Scale Scale {get;} = scale;
    private Pitch Root {get;} = root;

    public Pitch GetTone(RelativeInterval interval)
    {
        return Root + Scale.GetAbsoluteInterval(interval);
    }
}