using System.Text.RegularExpressions;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    [SerializeField] private CanvasGroup _resultCanvasGroup;
    [SerializeField] private TextMeshProUGUI _mainResultText;
    [SerializeField] private TextMeshProUGUI _lastResultText;
    [SerializeField] private Image _leftArrow;
    [SerializeField] private Image _rightArrow;
    [SerializeField] private Button _tryAgainButton;

    public Button TryAgainButton => _tryAgainButton;

    private void OnEnable()
    {
        RoundManager.OnRoundEnded += ShowResult;
        RoundManager.OnRoundEnded += DeactivateControls;
        _tryAgainButton.onClick.AddListener(ActivateControls);
        _tryAgainButton.onClick.AddListener(HideResult);
    }

    private void OnDisable()
    {
        RoundManager.OnRoundEnded -= ShowResult;
        RoundManager.OnRoundEnded -= DeactivateControls;
        _tryAgainButton.onClick.RemoveListener(ActivateControls);
        _tryAgainButton.onClick.RemoveListener(HideResult);
    }

    private void ShowResult()
    {
        _resultCanvasGroup.DOFade(1, 1f);
        _lastResultText.text = $"Last result: {Regex.Replace(_mainResultText.text, @"[^\d]", "")}";
        _mainResultText.text = $"Your result: {Regex.Replace(ScoreManager.Instance.Score.text, @"[^\d]", "")}";
    }

    private void HideResult()
    {
        _resultCanvasGroup.DOFade(0, .5f);
        ScoreManager.Instance.ResetScore();
    }

    private void DeactivateControls()
    {
        _leftArrow.raycastTarget = false;
        _rightArrow.raycastTarget = false;
    }
    
    private void ActivateControls()
    {
        _leftArrow.raycastTarget = true;
        _rightArrow.raycastTarget = true;
    }
}
