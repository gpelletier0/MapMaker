using Map;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(CameraController))]
    public class PlayerController : MonoBehaviour
    {
        public MapInfo mapInfo;

        private CameraController _cameraController;
        
        private void Start()
        {
            _cameraController = GetComponent<CameraController>();

            if (mapInfo)
            {
                _cameraController.moveMaxBounds = mapInfo.GetUpperBounds();
                _cameraController.SetCameraPosition(mapInfo.GetMapMiddlePos());   
            }
        }
    }
}
