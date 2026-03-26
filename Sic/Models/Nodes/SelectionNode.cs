namespace Sic.Models.Nodes;

/// <summary>
/// Node that allows selection of a set of pre given values.
/// </summary>
/// <param name="possibleValues">The values that can be selected from.</param>
/// <param name="outputType">The type of the values that can be selected.</param>
/// <remarks>
/// possibleValues must all have the same type or be of type NoData.
/// This type must also match the parameter outputType.
/// </remarks>
public class SelectionNode(List<INodeData> possibleValues, NodeDataType outputType)
             : Node([], [outputType])
{
    private readonly Selection selection = new(possibleValues);

    /// <summary>
    /// The currently selected data.
    /// </summary>
    public INodeData Selected
    {
        private get { return selection.Selected; }
        set { selection.Selected = value; }
    }

    /// <summary>
    /// The values that can be selected.
    /// </summary>
    public IReadOnlyList<INodeData> PossibleValues => selection.PossibleValues;

    /// <summary>
    /// Generates output data by setting the one and only output port to the currently selected value.
    /// </summary>
    protected internal override void GenerateOutputData()
    {
        SetOutputDataAt(0, Selected);
    }
}