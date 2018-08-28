using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Not sure what I want to do with this yet.
public class OverworldManager : MonoBehaviour {
    private OverworldTile _tile;

    private void OnEnable()
    {
        OverworldCursorController.OnCursorMove += DisplayTileData;
    }
    private void OnDisable()
    {
        OverworldCursorController.OnCursorMove -= DisplayTileData;
    }

    private void DisplayTileData(Vector3 worldPoint, Vector2 tileAnchor)
    {
        Vector3Int localPoint = new Vector3Int(Mathf.FloorToInt(worldPoint.x - tileAnchor.x),
                                               Mathf.FloorToInt(worldPoint.y - tileAnchor.y), 0);
        var tiles = Overworld.instance.GetTiles(); // This is our Dictionary of tiles

        Debug.Log(worldPoint);

        if (tiles.TryGetValue(localPoint, out _tile))
        {
            print("Tile " + _tile.Name + " costs: " + _tile.Cost);
            _tile.TilemapMember.SetTileFlags(_tile.LocalPlace, TileFlags.None);
            _tile.TilemapMember.SetColor(_tile.LocalPlace, Color.cyan);
        }
    }
}
