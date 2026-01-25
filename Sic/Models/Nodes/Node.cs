namespace Sic.Models.Nodes;

public abstract class Node(MusicDataType[] inputTypes, MusicDataType[] outputTypes)
{
    MusicDataType[] InputTypes { get; } = inputTypes;
    MusicDataType[] OutputTypes { get; } = outputTypes;
    List<Connection> InputConnections { get; } = [];
    List<Connection> OutputConnections { get; } = [];
    IMusicData[] Inputs { get; } = [.. inputTypes.Select((_) => new NoData())];
    IMusicData[] Outputs { get; } = [.. outputTypes.Select((_) => new NoData())];

    public MusicDataType GetInputTypeAt(int index)
    {
        return InputTypes[index];
    }

    public MusicDataType GetOutputTypeAt(int index)
    {
        return OutputTypes[index];
    }

    public void AddInputConnection(Node from, int fromIndex, int toIndex)
    {
        if (from.GetOutputTypeAt(fromIndex) != GetInputTypeAt(toIndex))
        {
            throw new ArgumentException("Type of from at fromIndex must match with this at toIndex");
        }

        Connection connection = new(from, fromIndex, this, toIndex);
        InputConnections.Add(connection);
        from.AddOutputConnection(connection);
    }

    public void AddInputConnection(Connection connection)
    {
        InputConnections.Add(connection);
    }

    public void AddOutputConnection(int fromIndex, Node to, int toIndex)
    {
        if (GetOutputTypeAt(fromIndex) != to.GetInputTypeAt(toIndex))
        {
            throw new ArgumentException("Type of this at fromIndex must match with to at toIndex");
        }

        Connection connection = new(this, fromIndex, to, toIndex);
        OutputConnections.Add(connection);
        to.AddInputConnection(connection);
    }

    public void AddOutputConnection(Connection connection)
    {
        OutputConnections.Add(connection);
    }

    public void RemoveInputConnection(Connection connection)
    {
        InputConnections.Remove(connection);
    }

    public void RemoveOutputConnection(Connection connection)
    {
        OutputConnections.Remove(connection);
    }

    public IMusicData GetOutputData(int index)
    {
        foreach (var connection in InputConnections)
        {
            connection.RequestData();
        }
        GenerateOutputData();
        return Outputs[index];
    }

    public void SetInputData(int index, IMusicData data)
    {
        if (data.Type != GetInputTypeAt(index))
        {
            throw new ArgumentException("Type mismatch between data type and input type at index");
        }

        Inputs[index] = data;
    }

    protected void SetOutputDataAt(int index, IMusicData data)
    {
        Outputs[index] = data;
    }

    protected IMusicData GetInputDataAt(int index)
    {
        return Inputs[index];
    }

    protected abstract void GenerateOutputData();
}