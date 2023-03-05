using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Image _gameOverImage;

    [SerializeField]
    private GameObject _resultWindow;

    [SerializeField]
    private GameObject  _retryButtonObject;
    private Image       _retryButtonImage;
    private Button      _retryButton;

    [SerializeField]
    private Image _medalImage;

    private Image ResultWindowImage;

    // Start is called before the first frame update
    void Start()
    {
        // Result Window
        ResultWindowImage = _resultWindow.GetComponent<Image>();
        ResultWindowImage.enabled = false;
        _resultWindow.GetComponent<ResultWindow>().HideScore();

        // Button
        _retryButtonImage = _retryButtonObject.GetComponent<Image>();
        _retryButton = _retryButtonObject.GetComponent<Button>();

        _retryButton.enabled = false;
        _gameOverImage.enabled = false;
        _medalImage.enabled = false;
        Color col = new Color(1, 1, 1, 0);
        _gameOverImage.color = col;
        _retryButtonImage.color = col;  
    }

    public void OnGameOverImage()
    {
        _gameOverImage.enabled = true;
        ResultWindowImage.enabled = true;
        _medalImage.enabled = true;
        StartCoroutine("FadeIn", 1);
    }

    IEnumerator FadeIn(float time)
    {
        float t = 0f;
        Color col = new Color(1, 1, 1, 0);
        _resultWindow.GetComponent<ResultWindow>().ShowScore(time);
        while (time > t)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / time);
            col.a = alpha;
            _gameOverImage.color = ResultWindowImage.color = _retryButtonImage.color = _medalImage.color = col;
            yield return null;
        }
        col.a = 1;
        _gameOverImage.color = ResultWindowImage.color = _retryButtonImage.color = _medalImage.color = col;
        _retryButton.enabled = true;
    }
}
