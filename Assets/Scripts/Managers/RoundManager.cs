using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class RoundManager : MonoBehaviour
{
    public static event Action OnRoundEnded;
    
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _timeRemaining = 120f;

    private float _timer;

    public void StartRound()
    {
        _timer = _timeRemaining;
        StartCoroutine(nameof(RoundCoroutine));
    }

    private IEnumerator RoundCoroutine()
    {
        while (_timer > 0.5)
        {
            _timer -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(_timer / 60);
            int seconds = Mathf.FloorToInt(_timer % 60);
            _timerText.text = $"{minutes}:{seconds:00}";
            yield return null;
        }
        
        OnRoundEnded?.Invoke();
    }
}
