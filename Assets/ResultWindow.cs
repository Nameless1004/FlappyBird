using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultWindow : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI _bestScoreTmp;

    [SerializeField]
    TextMeshProUGUI _currentScoreTmp;

    public void ShowScore(float time)
    {
        _bestScoreTmp.enabled = true;
        _currentScoreTmp.enabled = true;
        StartCoroutine("FadeInTmp",time);
    }

    IEnumerator FadeInTmp(float time)
    {
        float t = 0f;
        Color col = new Color(1, 1, 1, 0);
        _bestScoreTmp.color = col;
        _currentScoreTmp.color = col;
        while (time > t) 
        {
            t += Time.deltaTime;
            col.a = Mathf.Lerp(0, 1, t / time);
            _bestScoreTmp.color = _currentScoreTmp.color = col;
            yield return null;
        }
        col.a = 1f;
        _bestScoreTmp.color = _currentScoreTmp.color = col;
    }

    public void HideScore()
    {
        _bestScoreTmp.enabled = false;
        _currentScoreTmp.enabled = false;
    }
    public void SetScoreText(int current, int best)
    {
        _currentScoreTmp.text = current.ToString();
        _bestScoreTmp.text = best.ToString();
    }

}
