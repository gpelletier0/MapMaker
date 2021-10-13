using NaughtyAttributes;
using ScriptableObjects;
using UnityEngine;

namespace Map
{
    [ExecuteInEditMode]
    public class MapMaker : MonoBehaviour
    {
        [BoxGroup("Map")]
        [HorizontalLine]
        [Required]
        public GameMap gameMap;
        
        private Color32[] _terrainPixels;
        private Color32[] _territoryPixels;
        
        /// <summary>
        /// Create Map Editor Button
        /// </summary>
        [Button("Create New Map")]
        private void CreateMap()
        {
            if (gameMap == null)
            {
                Debug.LogError("Game Map is not set!");
                return;
            }
            
            if (gameMap.terrain == null)
            {
                Debug.LogError($"No terrain info!");
                return;
            }
            
            _terrainPixels = gameMap.terrain.GetPixels32();
            
            if(gameMap.territory != null)
                _territoryPixels = gameMap.territory.GetPixels32();

            GameObject parentGo = new GameObject(nameof(gameMap));
            AddMapInfo(parentGo);

            for (int z = 0; z < gameMap.terrain.height; z++)
            {
                for (int x = 0; x < gameMap.terrain.width; x++)
                {
                    int tileIndex = x + z * gameMap.terrain.width;

                    int owner = -1;
                    if(_territoryPixels.Length > 0)
                        owner = gameMap.palette.GetPlayerNumber(_territoryPixels[tileIndex]); // 0 is player 1

                    MapTileType mapTileType = gameMap.palette.GetMapTileType(_terrainPixels[tileIndex]);
                    if (owner > -1)
                        mapTileType = GetOwnedMapTileType(gameMap.palette.GetMapTileType(_terrainPixels[tileIndex]));

                    GameObject go = gameMap.palette.GetPaletteEntryPrefab(mapTileType);

                    CreateTile(go, parentGo.transform, new Vector3(x, 0, z), mapTileType, owner);
                }
            }
        }

        /// <summary>
        /// Adds MapInfo component to parent game object
        /// </summary>
        /// <param name="parentGo">parent map game object</param>
        private void AddMapInfo(GameObject parentGo)
        {
            MapInfo mapInfo = parentGo.gameObject.AddComponent<MapInfo>();
            mapInfo.SetTerrainSize(gameMap.terrain.width, gameMap.terrain.height);
        }

        /// <summary>
        /// Changes MapTileType of territory owned to tiles or walls
        /// </summary>
        /// <param name="mapTileType">current map tile type</param>
        /// <returns></returns>
        private MapTileType GetOwnedMapTileType(MapTileType mapTileType)
        {
            switch (mapTileType)
            {
                case MapTileType.Empty:
                    mapTileType = MapTileType.Tile;
                    break;
                case MapTileType.Earth:
                    mapTileType = MapTileType.Wall;
                    break;
            }

            return mapTileType;
        }

        /// <summary>
        /// Creates a new tile from prefab
        /// </summary>
        /// <param name="go">prefab GameObject</param>
        /// <param name="parent">parent transform</param>
        /// <param name="pos">Vector3 position</param>
        /// <param name="tileType">map tile type</param>
        /// <param name="owner">owner of tile</param>
        private void CreateTile(GameObject go, Transform parent, Vector3 pos, MapTileType tileType, int owner)
        {
            if (!go) return;

            Instantiate(go, parent);

            go.name = $"{tileType}({pos.x},{pos.z})";
            go.transform.position = new Vector3(
                pos.x + go.transform.localScale.x / 2,
                go.transform.position.y,
                pos.z + go.transform.localScale.z / 2);

            MapTile mapTile = go.GetComponent<MapTile>();
            if (mapTile)
                mapTile.owner = owner;
        }
    }
}