using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBoard : SingletonMonoBehaviour
{
    [SerializeField] int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int points)
    {
        this.score += points;
    }

    public void ResetScore()
    {
        this.score = 0;
    }
}
