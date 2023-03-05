using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoard : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _textMeshPro;

    int _currentScore = 0;

    public int CurrentScore { get { return _currentScore; } }


    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseCount()
    {
        _currentScore++;
        _textMeshPro.text = _currentScore.ToString();
    }
    public void HideScoreBoard()
    {
        _textMeshPro.enabled = false;
    }
}
