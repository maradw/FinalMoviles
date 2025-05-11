using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static event Action OnGameStart;
    public static event Action OnGameOver;
    public static event Action<int> OnScoreChanged;
    public static event Action OnGamePaused;
    public static event Action OnGameResumed;

    private int score = 0;
    private bool isGameRunning = false;
    private bool isPaused = false;
    [SerializeField] private GameData gameData;

    private void Awake()
    {
       
    }

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        isGameRunning = true;
        isPaused = false;
        score = 0;
        Time.timeScale = 1f; 
        Debug.Log("Game Started");
        OnGameStart?.Invoke();
    }

    public void AddScore(int amount)
    {
        if (!isGameRunning || isPaused) return;

        score += amount;
        Debug.Log("Score: " + score);
        OnScoreChanged?.Invoke(score);
    }

    public void EndGame()
    {
        isGameRunning = false;
        Time.timeScale = 1f;
        gameData.AddScore(score);

        Debug.Log("Game Over");
        OnGameOver?.Invoke();
    }

    public void PauseGame()
    {
        if (!isGameRunning || isPaused) return;

        isPaused = true;
        Time.timeScale = 0f;
        Debug.Log("Game Paused");
        OnGamePaused?.Invoke();
    }

    public void ResumeGame()
    {
        if (!isGameRunning || !isPaused) return;

        isPaused = false;
        Time.timeScale = 1f;
        Debug.Log("Game Resumed");
        OnGameResumed?.Invoke();
    }

    public bool IsPaused()
    {
        return isPaused;
    }

    public int GetScore()
    {
        return score;
    }
}
