using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level : MonoBehaviour
{
    private const string START_MENU_SCENE = "Start Menu";
    private const string GAME_SCENE = "Game";
    private const string GAME_OVER_SCENE = "Game Over";

    [SerializeField] float gameOverLoadDelay = 1f;

    public void LoadStartMenu()
    {
        SceneManager.LoadScene(START_MENU_SCENE);
    }

    public void LoadGameScene()
    {
        SceneManager.LoadScene(GAME_SCENE);
    }

    public void LoadGameOver()
    {
        StartCoroutine(WaitAndLoad());
    }

    private IEnumerator WaitAndLoad()
    {
        yield return new WaitForSeconds(gameOverLoadDelay);
        SceneManager.LoadScene(GAME_OVER_SCENE);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
