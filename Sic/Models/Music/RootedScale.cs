using Sic.Models.Music.Intervals;

namespace Sic.Models.Music;

public class RootedScale(Scale scale, Tone root)
{
    private Scale Scale {get;} = scale;
    private Tone Root {get;} = root;

    public Tone GetTone(RelativeInterval interval)
    {
        return Root + Scale.GetAbsoluteInterval(interval);
    }
}