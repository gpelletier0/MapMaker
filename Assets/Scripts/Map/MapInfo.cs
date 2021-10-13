using UnityEngine;

namespace Map
{
    public class MapInfo : MonoBehaviour
    { 
        public Vector2 terrainSize;

        /// <summary>
        /// Sets terrain size of map
        /// </summary>
        /// <param name="terrainWidth">width of map</param>
        /// <param name="terrainHeight">height of map</param>
        public void SetTerrainSize(float terrainWidth, float terrainHeight) =>
            terrainSize = new Vector2(terrainWidth, terrainHeight);

        /// <summary>
        /// Terrain size upper bounds
        /// </summary>
        /// <returns>Vector2 terrain size</returns>
        public Vector2 GetUpperBounds() => terrainSize;
        
        /// <summary>
        /// Terrain middle point
        /// </summary>
        /// <returns>Vector3 middle point</returns>
        public Vector3 GetMapMiddlePos() => 
            new Vector3(terrainSize.x / 2, 0, terrainSize.y / 2);
    }
}
