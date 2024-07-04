using System.Collections;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    
    [Header("Slow Buff Settings")]
    [SerializeField] private float _slowBuffDuration;
    [SerializeField] private float _slowBuffValue;
    [Header("Speed Buff Settings")]
    [SerializeField] private float _speedBuffDuration;
    [SerializeField] private float _speedBuffValue;
    [Header("Expand Buff Settings")]
    [SerializeField] private float _expandBuffDuration;
    [SerializeField] private float _expandBuffValue;
    
    public void ApplyEffect(Ball ball)
    {
        switch (ball)
        {
            case SlowBall:
                StartCoroutine(nameof(SlowBuffCoroutine));
                break;
            case SpeedBall:
                StartCoroutine(nameof(SpeedBuffCoroutine));
                break;
            case ExpandBall:
                StartCoroutine(nameof(ExpandBuffCoroutine));
                break;
        }
    }

    private IEnumerator SlowBuffCoroutine()
    {
        float timer = 0;
        Time.timeScale = _slowBuffValue;
        while (timer < _slowBuffDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        Time.timeScale = 1f;
    }

    private IEnumerator SpeedBuffCoroutine()
    {
        float timer = 0;
        float defaultSpeed = _playerController.Speed;
        _playerController.SetSpeed(_speedBuffValue);
        while (timer < _speedBuffDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _playerController.SetSpeed(defaultSpeed);
    }
    
    private IEnumerator ExpandBuffCoroutine()
    {
        float timer = 0;
        float defaultScale = _playerController.LocalScale.x;
        _playerController.ExpandScale(_expandBuffValue);
        while (timer < _expandBuffDuration)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        _playerController.ExpandScale(defaultScale);
    }
}
