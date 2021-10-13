using System.Collections.Generic;
using System.Linq;
using Extensions;
using Map;
using NaughtyAttributes;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "MapMaker/MapPalette")]
    public class MapPalette : ScriptableObject
    {
        public List<PaletteEntry> paletteEntries;
        public List<Color32> playerColors;

        /// <summary>
        /// Gets Pallet entry prefab from enum MapTileType
        /// </summary>
        /// <param name="tileType">MapTileType of pallet entry</param>
        /// <returns>Prefab GameObject or null</returns>
        public GameObject GetPaletteEntryPrefab(MapTileType tileType) =>
            paletteEntries.FirstOrDefault(p => p.type.Equals(tileType)).prefab;
        
        /// <summary>
        /// Gets Pallet entry prefab from color
        /// </summary>
        /// <param name="color">Color of pallet entry</param>
        /// <returns>Prefab GameObject or null</returns>
        public GameObject GetPaletteEntryPrefab(Color32 color) =>
            paletteEntries.FirstOrDefault(p => p.color.Equals(color)).prefab;

        /// <summary>
        /// Gets map tile type from color
        /// </summary>
        /// <param name="color">color of pallet</param>
        /// <returns>enum MapTileType</returns>
        public MapTileType GetMapTileType(Color32 color) => 
            paletteEntries[paletteEntries.FindIndex(p => p.color.Equals(color)).ZeroCheck()].type;

        /// <summary>
        /// Gets player number from player colors
        /// </summary>
        /// <param name="color">color fo player</param>
        /// <returns>index of player color</returns>
        public int GetPlayerNumber(Color32 color) => playerColors.FindIndex(c => c.Equals(color));
    }
}