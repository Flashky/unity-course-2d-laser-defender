using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Scoreboard : MonoBehaviour
{
    TextMeshProUGUI text;

    GameSession gameSession;

    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        gameSession = FindObjectOfType<GameSession>();
    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(gameSession.GetScore());
        text.text = gameSession.GetScore().ToString();
    }
}
