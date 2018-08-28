using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: @Error Pick a error handling approach.

/// <summary>
/// NOT CURRENTLY USED.
/// </summary>
public class OverworldTileFactory : IOverworldTileFactory
{
    public string Type
    {
        get
        {
            throw new System.NotImplementedException();
        }
    }

    public IOverworldTile Create(string type)
    {
        switch (type)
        {
            case OverworldTileTypes.Arena:
                return new ArenaOverworldTile();

            case OverworldTileTypes.Miscellaneous:
            case null:
            case "":
            default:
                return new MiscelllaneousOverworldTile();
        }
    }
}
