using Sic.Models.Nodes;
using Sic.Models.SoundAdaptors;

namespace SicApp.Nodes;

/// <summary>
/// Represents the state of a <see cref="NodeWindow"/>
/// </summary>
public class NodeWindowState(MusicPlayer musicPlayer)
{
    /// <summary>
    /// The Node currently selected.
    /// </summary>
    public VisualNode? SelectedNode { get; set; }

    /// <summary>
    /// The VisualNodeInputPort currently selected.
    /// </summary>
    public VisualNodeInputPort? SelectedInputPort { get; private set; } 

    /// <summary>
    /// The VisualNodeOutputPort currently selected.
    /// </summary>
    public VisualNodeOutputPort? SelectedOutputPort { get; private set; }

    /// <summary>
    /// The MusicPlayer used in the Node Window.
    /// </summary>
    private MusicPlayer MusicPlayer { get; } = musicPlayer;

    /// <summary>
    /// Toggles the selected VisualNodeInputPort.
    /// </summary>
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

    /// <summary>
    /// Toggles the selected VisualNodeOutputPort.
    /// </summary>
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

    /// <summary>
    /// If an input and output port is selected, a connection is toggled between them
    /// and afterwards both ports are unselected.
    /// Otherwise nothing happens.
    /// </summary>
    private void ToggleConnectionIfNeeded()
    {
        if (SelectedInputPort != null && SelectedOutputPort != null)
        {
            Connection.Toggle(SelectedOutputPort.IOPort, SelectedInputPort.IOPort);
            SelectedInputPort = null;
            SelectedOutputPort = null;
        }
    }

    /// <summary>
    /// Play some music.
    /// </summary>
    public void PlayMusic(INodeData music)
    {
        MusicPlayer.Queue(music);
    }
}