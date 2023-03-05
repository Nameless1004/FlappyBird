using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    [SerializeField]
    private Image GameOverImage;
    [SerializeField]
    private GameObject ResultWindow;

    private Image ResultWindowImage;

    [SerializeField] 
    private float _fadeInTime = 1f;

    // Start is called before the first frame update
    void Start()
    {
        ResultWindowImage = ResultWindow.GetComponent<Image>();
        ResultWindowImage.enabled = false;
        ResultWindow.GetComponent<ResultWindow>().HideScore();

        GameOverImage.enabled = false;
        Color col = new Color(1, 1, 1, 0);
        GameOverImage.color = col;
    }

    public void OnGameOverImage()
    {
        GameOverImage.enabled = true;
        ResultWindowImage.enabled = true;
        StartCoroutine("FadeIn", 1);
    }

    IEnumerator FadeIn(float time)
    {
        float t = 0f;
        Color col = new Color(1, 1, 1, 0);
        while (time > t)
        {
            t += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, t / time);
            col.a = alpha;
            GameOverImage.color = ResultWindowImage.color = col;
            yield return null;
        }
        col.a = 1;
        GameOverImage.color = ResultWindowImage.color = col;
        ResultWindow.GetComponent<ResultWindow>().ShowScore();
    }
}
