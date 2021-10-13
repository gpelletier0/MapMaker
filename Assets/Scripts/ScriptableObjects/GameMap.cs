using NaughtyAttributes;
using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(menuName = "MapMaker/GameMap")]
    public class GameMap : ScriptableObject
    {
        [Required]
        public Texture2D terrain;
        public Texture2D territory;
        [Required]
        public MapPalette palette;
    }
}