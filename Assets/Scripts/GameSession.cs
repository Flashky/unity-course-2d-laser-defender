using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSession : SingletonMonoBehaviour
{
    [SerializeField] int score = 0;

    public void IncreaseScore(int points)
    {
        this.score += points;
    }

    public void ResetGame()
    {
        Destroy(gameObject);
    }

    public int GetScore()
    {
        return score;
    }
}
