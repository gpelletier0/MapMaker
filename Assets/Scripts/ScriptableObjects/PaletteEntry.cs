using System;
using Map;
using UnityEngine;

namespace ScriptableObjects
{
    [Serializable]
    public struct PaletteEntry
    {
        public MapTileType type;
	    public Color color;
	    public GameObject prefab;
    }
}