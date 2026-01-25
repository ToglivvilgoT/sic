namespace Sic.Models.Nodes;

public class TwoNoteNode() : Node([MusicDataType.Note, MusicDataType.Note], [MusicDataType.Note, MusicDataType.Note])
{
    protected override void GenerateOutputData()
    {
        SetOutputDataAt(0, GetInputDataAt(1));
        SetOutputDataAt(1, GetInputDataAt(0));
    }
}