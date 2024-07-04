using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;
    
    public static ScoreManager Instance { get; private set; }
    public TextMeshProUGUI Score => _scoreText;

    private void Awake()
    {
        Instance = this;
    }

    public void AddScore(float points)
    {
        _scoreText.text = (float.Parse(_scoreText.text) + points).ToString();
    }

    public void ResetScore()
    {
        _scoreText.text = "0";
    }
}
