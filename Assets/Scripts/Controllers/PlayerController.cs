using DG.Tweening;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float _speed = 300.0f;

    private PlayerInteractions _characterInput;
    private Rigidbody2D _rigidbody2D;
    private float _dirX;

    public float Speed => _speed;
    public Vector3 LocalScale => transform.localScale;

    private void Awake()
    {
        _characterInput = new PlayerInteractions();
        _characterInput.Enable();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        HandleInput();
    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

    private void HandleInput()
    {
        //_dirX = _characterInput.Player.Move.ReadValue<Vector2>().x - Якщо гра кроссплатформенна, PS, PC, ect;
    }

    private void HandleMovement()
    {
        _rigidbody2D.velocity = new Vector2(_dirX * _speed * Time.fixedDeltaTime, 0);
    }

    public void SetSpeed(float speed)
    {
        _speed = speed;
    }

    public void ExpandScale(float expandValue)
    {
        transform.DOScaleX(expandValue, 0.5f);
    }

    public void SetDirection(float dirX)
    {
        _dirX = dirX;
    }
}