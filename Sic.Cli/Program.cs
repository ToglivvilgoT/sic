using Sic.Models.Nodes;

Console.WriteLine("Hello World");
NoteNode node1 = new(new(new(0), new(1, 4)));
NoteNode node2 = new(new(new(7), new(1, 2)));
TwoNoteNode node3 = new();
Console.WriteLine(node3.GetOutputData(0).Type);
Console.WriteLine(node3.GetOutputData(1).Type);
node1.AddOutputConnection(0, node3, 0);
node2.AddOutputConnection(0, node3, 1);
Console.WriteLine(((NoteData)node3.GetOutputData(0)).Note);
Console.WriteLine(((NoteData)node3.GetOutputData(1)).Note);
        