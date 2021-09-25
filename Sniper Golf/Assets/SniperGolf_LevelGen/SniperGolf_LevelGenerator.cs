using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperGolf_LevelGenerator
{
    private SniperGolf_Segment[,] grid;

    [SerializeField] private SniperGolf_Segment[] segmentOptions;

    [SerializeField] private int width = 4;
    [SerializeField] private int height = 3;
    [SerializeField] private float spacing = 1;

    public void Generate()
    {
        grid = new SniperGolf_Segment[width, height];

        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                Vector3 position = new Vector3 (i * spacing, j * spacing, 0);
                Quaternion rotation = Quaternion.Euler(0, 0, Random.Range(0, 4)*90f);
                grid[i, j] = Instantiate(segmentOptions[Random.Range(0, segmentOptions.Length)], position, rotation);
            }
    }
}