using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public interface IOverworldTile{

    // System: information tying tile data to visual tiles
    Vector3Int LocalPlace { get;}

    Vector3 WorldLocation { get;}

    TileBase TileBase { get; }

    Tilemap TilemapMember { get; }

    string Name { get; }

    // Search Algorithm: Breadth First Searching fields
    bool IsExplored { get; }

    OverworldTile ExploredFrom { get; }

    int Cost { get; }

    // Game:
    int MovementCost { get; }

    int DefenceBonus { get; }

    int AvoidanceBonus { get; }

    string Type { get; }
}
