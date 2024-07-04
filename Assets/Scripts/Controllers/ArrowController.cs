using UnityEngine;
using UnityEngine.EventSystems;

public class ArrowController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private float _xDir;

    public void OnPointerDown(PointerEventData eventData)
    {
        _playerController.SetDirection(_xDir);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _playerController.SetDirection(0);
    }
}
