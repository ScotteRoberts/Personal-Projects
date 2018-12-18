using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

/// <summary>
/// Tilemap extensions. Add static methods to the original Tilemap API.
/// </summary>
public static class TilemapExtensions
{
    /// <summary>
    /// Generic Collection of any custom tiles inheriting from TileBase
    /// </summary>
    /// <returns>Generic collection of tiles.</returns>
    /// <param name="tilemap">Current tilemap.</param>
    /// <typeparam name="T">Generic subclass of TileBase</typeparam>
    /// <remarks>Reference: https://gamedev.stackexchange.com/questions/150917/how-to-get-all-tiles-from-a-tilemap</remarks>
    /// <author>Dmitry Tabokov</author>
    public static T[] GetTiles<T>(this Tilemap tilemap) where T : TileBase
    {
        List<T> tiles = new List<T>();

        for (int y = tilemap.origin.y; y < (tilemap.origin.y + tilemap.size.y); y++)
        {
            for (int x = tilemap.origin.x; x < (tilemap.origin.x + tilemap.size.x); x++)
            {
                T tile = tilemap.GetTile<T>(new Vector3Int(x, y, 0));
                if (tile != null)
                {
                    tiles.Add(tile);
                }
            }
        }
        return tiles.ToArray();
    }

}