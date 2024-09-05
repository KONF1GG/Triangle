using UnityEngine;
using UnityEngine.Tilemaps;

public class ObstacleGenerator : MonoBehaviour
{
    public Tilemap tilemap;  // Reference to the Tilemap
    public Tile[] obstacleTiles;  // Array of obstacle tiles
    public Vector2Int mapSize;  // Map size (width and height)
    public int obstacleCount;  // Number of obstacles

    void Start()
    {
        GenerateObstacles();
    }

    void GenerateObstacles()
    {
        // Determine positions for obstacles
        for (int i = 0; i < obstacleCount; i++)
        {
            int x = Random.Range(-10, mapSize.x);
            int y = Random.Range(0, mapSize.y);

            // Check if the position is free
            if (tilemap.GetTile(new Vector3Int(x, y, 0)) == null)
            {
                // Select a random obstacle tile
                Tile randomObstacle = obstacleTiles[Random.Range(0, obstacleTiles.Length)];
                tilemap.SetTile(new Vector3Int(x, y, 0), randomObstacle);
            }
        }
    }

    // Method to clear all obstacles
    void ClearObstacles()
    {
        // Iterate over the entire map size and clear tiles
        for (int x = -10; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), null);
            }
        }
    }

    // Method to regenerate the world after death
    public void RegenerateWorld()
    {
        ClearObstacles();  // Clear existing obstacles
        GenerateObstacles();  // Generate new obstacles
    }
}
