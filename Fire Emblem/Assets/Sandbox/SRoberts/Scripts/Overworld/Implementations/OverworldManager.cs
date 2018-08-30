using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Not sure what I want to do with this yet.
public class OverworldManager : MonoBehaviour {

    // Singleton Reference
    private static OverworldManager instance;

    [SerializeField]
    private Vector3 tilemapAnchor;

    private OverworldTile _tile;

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
    }

    private void OnEnable()
    {
        OverworldCursorMovement.OnCursorMove += DisplayTileData;
    }
    private void OnDisable()
    {
        OverworldCursorMovement.OnCursorMove -= DisplayTileData;
    }

    private void DisplayTileData(Vector3Int localPoint)
    {
        var tiles = Overworld.GetInstance().GetTiles(); // This is our Dictionary of tiles

        if (tiles.TryGetValue(localPoint, out _tile))
        {
            print("Tile " + _tile.Name + " x: " + _tile.LocalPlace.x + " y: "+
                  _tile.LocalPlace.y + " costs: " + _tile.Cost);
            _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
            _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.cyan);
        }
    }

    public static OverworldManager GetInstance() { return instance; }

    public Vector3 GetTilemapAnchor() { return tilemapAnchor; }

    // TODO Method can be improved with extra parameter to define add and subtract
    public Vector3 IncludeTilemapAnchor(Vector3Int point)
    {
        return new Vector3(point.x + tilemapAnchor.x,
                           point.y + tilemapAnchor.y,
                            point.z + tilemapAnchor.z);
    }

    public Vector3 RemoveTilemapAnchor(Vector3 point)
    {
        return point - tilemapAnchor;
    }
}
