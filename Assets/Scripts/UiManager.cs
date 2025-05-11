using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI healthText;

    private void OnEnable()
    {
        GameManager.OnGameStart += ShowGame;
        GameManager.OnGameOver += ShowGameOver;
        GameManager.OnScoreChanged += UpdateScore;
    }

    private void OnDisable()
    {
        GameManager.OnGameStart -= ShowGame;
        GameManager.OnGameOver -= ShowGameOver;
        GameManager.OnScoreChanged -= UpdateScore;
    }

    void ShowGame()
    {
        Debug.Log(" Game Started");
    }

    void ShowGameOver()
    {
        Debug.Log(" Game Over");
    }

    void UpdateScore(int newScore)
    {
        scoreText.text = "Score: " + newScore;
       
    }
}