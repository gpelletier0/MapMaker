using System;
using UnityEngine;

namespace Map
{
    [Serializable]
    public class MapTile : MonoBehaviour
    {
        public MapTileType type;
        public int owner;
        public float hp;
    }
}