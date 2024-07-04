using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private BallSpawner _ballSpawner;
    [SerializeField] private UIController _uiController;
    [SerializeField] private RoundManager _roundManager;
    
    private void OnEnable()
    {
        RoundManager.OnRoundEnded += _ballSpawner.StopSpawning;
        _uiController.TryAgainButton.onClick.AddListener(_ballSpawner.StartSpawning);
        _uiController.TryAgainButton.onClick.AddListener(_roundManager.StartRound);
    }

    private void OnDisable()
    {
        RoundManager.OnRoundEnded -= _ballSpawner.StopSpawning;
        _uiController.TryAgainButton.onClick.RemoveListener(_ballSpawner.StartSpawning);
        _uiController.TryAgainButton.onClick.RemoveListener(_roundManager.StartRound);
    }
    
    private void Start()
    {
        _roundManager.StartRound();
    }
}
