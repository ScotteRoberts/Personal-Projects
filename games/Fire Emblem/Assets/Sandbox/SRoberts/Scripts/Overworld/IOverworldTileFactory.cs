using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Specific contract for OverworldTileFactory
/// </summary>
public interface IOverworldTileFactory : IFactory<IOverworldTile> {

    string Type { get; }
}
