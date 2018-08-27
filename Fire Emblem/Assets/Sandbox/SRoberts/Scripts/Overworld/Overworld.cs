using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Overworld : MonoBehaviour
{
    // Singleton Reference
    public static Overworld instance;

    // List of tilemaps to check for tiles. ORDER MATTERS IN LIST!!
    [SerializeField]
    private Tilemap[] tilemaps;

    // Dictionary of (Grid location / tile)
    public Dictionary<Vector3, OverworldTile> tiles;

    // Singleton Logic
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }

        GetOverworldTiles();
    }

    // Use this for initialization
    private void GetOverworldTiles()
    {
        tiles = new Dictionary<Vector3, OverworldTile>();
        foreach (Tilemap map in tilemaps)
        {
            foreach (Vector3Int pos in map.cellBounds.allPositionsWithin)
            {
                var localPlace = new Vector3Int(pos.x, pos.y, pos.z);

                if (!map.HasTile(localPlace)) continue;

                // TODO: Create factory that allows for different types of terrain.
                var tile = new OverworldTile
                {
                    LocalPlace = localPlace,
                    WorldLocation = map.CellToWorld(localPlace),
                    TileBase = map.GetTile(localPlace),
                    TilemapMember = map,
                    Name = localPlace.x + "," + localPlace.y,
                    Cost = 1 // TODO: Change this with the proper cost from ruletile
                };

                // Update or Add new tiles to running list
                if(tiles.ContainsKey(tile.WorldLocation))
                {
                    tiles[tile.WorldLocation] = tile;
                }
                else
                {
                    tiles.Add(tile.WorldLocation, tile);
                }
            }
        }

    }
}
