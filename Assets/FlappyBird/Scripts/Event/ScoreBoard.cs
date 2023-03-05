using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;
    [SerializeField]
    Score _currentScore;


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCount()
    {
        _currentScore.score++;
        _textMeshPro.text = _currentScore.score.ToString();
    }
    public void HideScoreBoard()
    {
        _textMeshPro.enabled = false;
    }
}
