using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public void GameRestart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "Game");
    }
}
