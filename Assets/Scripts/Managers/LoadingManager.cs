using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using DG.Tweening;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _resultText;
    [SerializeField] private Image _loadingImage;
    [SerializeField] private Slider _slider;
    
    [Header("Start Settings")]
    [SerializeField] private bool _needToStartGame;
    [SerializeField] private string _requestURL;
    
    private void Start()
    {
        _loadingImage.transform.DOLocalRotate(new Vector3(0, 0, -360), 1f, RotateMode.FastBeyond360).SetRelative(true).SetEase(Ease.InOutCubic).SetLoops(-1);
        _slider.DOValue(1, 3f).onComplete += () =>
        {
            if (_needToStartGame)
            {
                StartGame();
                return;
            }
            StartCoroutine(GetRequest());
        };
    }

    private IEnumerator GetRequest()
    {
        UnityWebRequest startRequest = UnityWebRequest.Get(_requestURL);
        
        if (Application.internetReachability == NetworkReachability.NotReachable)
        {
            StartGame();
        }
        else
        {
            yield return startRequest.SendWebRequest();

            if (startRequest.result != UnityWebRequest.Result.Success)
            {
                StartGame();
            }
            else
            {
                _resultText.gameObject.SetActive(true);
                _resultText.text = startRequest.downloadHandler.text;;
            }
        }
    }

    private void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}