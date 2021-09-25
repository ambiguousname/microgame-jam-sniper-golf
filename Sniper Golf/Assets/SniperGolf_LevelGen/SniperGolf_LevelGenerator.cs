using System.Collections;
using UnityEngine;

class SniperGolf_LevelGenerator
{
    // Adjacency List representation of the level
    private List<Node> adj = new List<Node>();

    private Node[,] grid;

    [SerializeField] private int width = 4;
    [SerializeField] private int height = 3;

    public void Generate()
    {
        // Generate random grid
        grid = new Node[width, height];
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
            {
                Node newNode = new Node(GetRandomTerrainType());
                grid[i, j] = newNode;
                adj.Add(newNode);
            }

        // Add edges to adjacency list
        int listIndex = 0;
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                grid[i, j].edges = GetNeighbors(i, j);

        PrintGrid();
    }

    private SniperGolf_TerrainType GetRandomTerrainType()
    {
        return (SniperGolf_TerrainType) Random.Range(0, SniperGolf_TerrainType.COUNT);
    }

    private List<Node> GetNeighbors(int i, int j)
    {
        List<Node> neighbors = new List<Node>();

        // Walls have no neighbors
        if (grid[i, j].terrain == SniperGolf_TerrainType.Wall)
            return neighbors;

        for (int y = i - 1; y <= i + 1; y++)
            if (y >= 0 && y < height) // check y bounds
                for (int x = j - 1; x <= j + 1; x++)
                    if (x >= 0 && x < width) // check x bounds
                        if (!(y == i && x == j)) // check that it's not looking at itself
                        {
                            Node neighbor = grid[x, y];
                            if (neighbor.terrain != SniperGolf_TerrainType.Wall)
                                neighbors.add(neighbor);
                        }

        return neighbors;
    }

    private void PrintGrid()
    {
        for (int i = 0; i < height; i++)
            for (int j = 0; j < width; j++)
                Console.WriteLine("X");
            Console.WriteLine();
    }
}