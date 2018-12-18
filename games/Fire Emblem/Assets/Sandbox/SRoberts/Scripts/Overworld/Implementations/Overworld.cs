using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Overworld : MonoBehaviour
{
    // Local Points are grid points.
    // World Points are your transform position.

    // Singleton Reference
    private static Overworld instance;

    // List of tilemaps to check for tiles. ORDER MATTERS IN LIST!!
    [SerializeField]
    private Tilemap[] tilemaps;
    [SerializeField]
    private BoxCollider2D playableCollider;

    // (Grid location / tile)
    private Dictionary<Vector3, OverworldTile> tiles;
    
    private void Awake()
    {
        SetInstance();
        //GetMyComponents();

        GenerateOverworldTiles();
        Change15and1();
    }

    public static Overworld GetInstance() { return instance; }

    // Private on purpose.
    private void SetInstance() 
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    //private void GetMyComponents()
    //{
    //    var index = 0;
    //    foreach(Tilemap map in tilemaps)
    //    {
    //    }
    //}

    public Dictionary<Vector3, OverworldTile> GetTiles() { return tiles; }

    // Use this for initialization
    private void GenerateOverworldTiles()
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
                    Name = OverworldTileTypes.Plain,
                    Cost = 1, // TODO: Change this with the proper cost from ruletile
                };

                tile = SetTileBoundaries(map, localPlace, tile);

                //if (!tile.IsMoveable)
                    //print("Immovable x:" + localPlace.x + " y: " + localPlace.y);

                // Update or Add new tiles to running list
                if (tiles.ContainsKey(tile.WorldLocation))
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

    private OverworldTile SetTileBoundaries(Tilemap map, Vector3Int localPlace, OverworldTile tile)
    {
        var playableBoundary = playableCollider.bounds;
        // Determine if Tile is outside of boundaries
        if(localPlace.x >= playableBoundary.min.x && localPlace.x < playableBoundary.max.x &&
          localPlace.y >= playableBoundary.min.y && localPlace.y < playableBoundary.max.y)
        {
            tile.IsMoveable = true;
        }
        else
        {
            tile.IsMoveable = false;
        }
        return tile;
    }

    private void Change15and1() {
        var localPoint = new Vector3Int(15, 1, 0);
        tiles[localPoint].IsMoveable = false;
    }

    public bool IsMovable(Vector3Int localPoint)
    {
        return tiles[localPoint].IsMoveable;
    }
}
