using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

// Reference: https://gamedev.stackexchange.com/questions/150917/how-to-get-all-tiles-from-a-tilemap
public class TilemapInformation : MonoBehaviour
{
    void Start()
    {
        Tilemap tilemap = GetComponent<Tilemap>();

        BoundsInt bounds = tilemap.cellBounds;
        TileBase[] allTiles = tilemap.GetTilesBlock(bounds);
        OverworldTile[] overworldTiles = tilemap.GetTiles<OverworldTile>();

        foreach (OverworldTile tile in overworldTiles)
        {
            Debug.Log(tile.m_Walkable);
        }

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    if (tile.name == "DeadPlains")
                    {

                        // Invalid Cast: OverworldTile overworldTile = (OverworldTile) tile;
                        //Debug.Log(overworldTile);
                        //Debug.Log("Hello");
                        //overworldTiles.Add(overworldTile);
                        //Debug.Log(overworldTiles.Count);



                        //Debug.Log(tile.name);
                    }
                }
                else
                {
                    //Debug.Log("x:" + x + " y:" + y + " tile: (other)");
                }
            }
        }
    }
}
