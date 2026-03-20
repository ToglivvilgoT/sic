using Sic.Models.Nodes;
using Sic.Models.SoundAdaptors;

namespace SicApp;

public class NodeWindowState(MusicPlayer musicPlayer)
{
    public VisualNode? SelectedNode { get; private set; }
    public VisualNodeInputPort? SelectedInputPort { get; private set; } 
    public VisualNodeOutputPort? SelectedOutputPort { get; private set; }
    private MusicPlayer MusicPlayer { get; } = musicPlayer;

    public void ToggleSelected(VisualNode node)
    {
        if (SelectedNode == node)
        {
            SelectedNode = null;
        }
        else
        {
            SelectedNode = node;
        }
    }

    public void ToggleSelected(VisualNodeInputPort inputPort)
    {
        if (SelectedInputPort == inputPort)
        {
            SelectedInputPort = null;
        }
        else
        {
            SelectedInputPort = inputPort;
        }
        ToggleConnectionIfNeeded();
    }

    public void ToggleSelected(VisualNodeOutputPort outputPort)
    {
        if (SelectedOutputPort == outputPort)
        {
            SelectedOutputPort = null;
        }
        else
        {
            SelectedOutputPort = outputPort;
        }
        ToggleConnectionIfNeeded();
    }

    private void ToggleConnectionIfNeeded()
    {
        if (SelectedInputPort != null && SelectedOutputPort != null)
        {
            Connection.Toggle(SelectedOutputPort.IOPort, SelectedInputPort.IOPort);
            SelectedInputPort = null;
            SelectedOutputPort = null;
        }
    }

    public void UnSelectVisualNode()
    {
        SelectedNode = null;
    }

    public void PlayMusic(IMusicData music)
    {
        MusicPlayer.Queue(music);
    }
}