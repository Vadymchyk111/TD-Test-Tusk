using UnityEngine;

public class DeviceAdjuster : MonoBehaviour
{
    [SerializeField] private Transform _barrier1;
    [SerializeField] private Transform _barrier2;
    [SerializeField] private Camera _mainCamera;
    
    private void Awake()
    {
        Vector3 screenPosition = _mainCamera.WorldToScreenPoint(_barrier1.transform.position);
        Vector3 newBarrier1Position = _mainCamera.ScreenToWorldPoint(new Vector3(0, screenPosition.y, screenPosition.z));
        Vector3 newBarrier2Position = _mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, screenPosition.y, screenPosition.z));
        _barrier1.transform.position = newBarrier1Position;
        _barrier2.transform.position = newBarrier2Position;
    }
}
