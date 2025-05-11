using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameData", menuName = "Scriptable Objects/GameData")]
public class GameData : ScriptableObject
{
    public List<int> score = new List<int>();
    public int playerLife;

    public void AddScore(int newScore)
    {
        score.Add(newScore);
    }

    public int GetLastScore()
    {
        if (score.Count == 0)
            return 0;

        return score[score.Count - 1];
    }
}
