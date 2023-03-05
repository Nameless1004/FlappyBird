using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _playerPrefab;
    [SerializeField]
    private GameObject _resultWindow;

    [SerializeField]
    private float ReadyTime = 1f;
    public bool IsGameOver;
    public Action GameOverAnimation;
    public Transform initPos;

    public Score BestScore;

    // Start is called before the first frame update
    void Start()
    {
        IsGameOver = false;
        TimeManager.Instance.TimeScale = 1;
        GameObject obj = Instantiate(_playerPrefab, initPos.position, Quaternion.identity);
        StartCoroutine("WaitReady");
    }

    public void GameStart()
    {

    }

    public IEnumerator WaitReady()
    {
        Time.timeScale = 0;
        float t = 0f;
        while(ReadyTime > t)
        {
            t += Time.unscaledDeltaTime;
            yield return null;
        }
        Time.timeScale = 1;
    }

    public void GameOver()
    {
        IsGameOver = true;
        int curScore = GetComponent<ScoreBoard>().CurrentScore;
        BestScore.score = Math.Max(BestScore.score, curScore);
        _resultWindow.GetComponent<ResultWindow>().SetScoreText(curScore, BestScore.score);
    }

    public void GameResume()
    {

    }

    public void Retry()
    {
        SceneManager.LoadScene(1);
    }

}
