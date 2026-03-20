using System;
using System.Collections.Generic;
using Sic.Models.Nodes;

namespace SicApp;

/// <summary>
/// Implementation of <see cref="INodeIOPortMap"/> using a Dictionary.
/// </summary>
/// <param name="lookup"></param>
class NodeIOPortMap(Dictionary<NodeIOPort, Widget> lookup) : INodeIOPortMap
{
    private readonly Dictionary<NodeIOPort, Widget> lookup = lookup;

    public Widget GetAssociatedIOPort(NodeIOPort port)
    {
        lookup.TryGetValue(port, out Widget? result);
        return result ?? throw new ArgumentException("Node IO port has no associated Widget.");
    }
}