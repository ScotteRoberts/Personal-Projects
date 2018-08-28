using UnityEngine;
using UnityEngine.Tilemaps;

public class OverworldTile : IOverworldTile
{
    // System: information tying tile data to visual tiles
    public Vector3Int LocalPlace { get; set; }

    public Vector3 WorldLocation { get; set; }

    public TileBase TileBase { get; set; }

    public Tilemap TilemapMember { get; set; }

    public string Name { get; set; }

    // Search Algorithm: Breadth First Searching fields
    public bool IsExplored { get; set; }

    public OverworldTile ExploredFrom { get; set; }

    public int Cost { get; set; }

    // Game:
    public int MovementCost { get; set; }

    public int DefenceBonus { get; set; }

    public int AvoidanceBonus { get; set; }

    public string Type
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }
}
