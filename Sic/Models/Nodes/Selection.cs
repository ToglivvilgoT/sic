namespace Sic.Models.Nodes;

/// <summary>
/// Select a value from a list of possible values.
/// </summary>
public class Selection(List<INodeData> possibleValues)
{
    /// <summary>
    /// A list of the possible values to select from.
    /// </summary>
    public IReadOnlyList<INodeData> PossibleValues { get; } = possibleValues;

    private INodeData _Selected = new NoData();
    /// <summary>
    /// The currently selected value.
    /// Must be one of the <see cref="PossibleValues"/>.
    /// </summary>
    public INodeData Selected
    {
        get => _Selected;
        set {
            if (PossibleValues.Contains(value))
            {
                _Selected = value;
            }
            else
            {
                throw new ArgumentException("Selected must be one of the values in PossibleValues");
            }
        }
    }
}