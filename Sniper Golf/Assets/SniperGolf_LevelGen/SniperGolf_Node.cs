using System.Collections;
using UnityEngine;

public enum SniperGolf_TerrainType
{
    Grass,
    Wall,
    Sand,
    Goal,
    COUNT
}

public class SniperGolf_Node
{
    public TerrainType terrain;
    public List<Node> edges;

    public SniperGolf_Node(TerrainType _terrain)
    {
        terrain = _terrain;
        edges = new List<Node>;
    }
}