using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseButtonScript : MonoBehaviour
{
    Button pb;
    bool paused = false;

    public GameObject pauseScreen;
    
    void Start()
    {
        pb = GetComponent<Button>();
    }

    public void OnClick()
    {
        if (!paused)
        {
            Time.timeScale = 0;
            paused = true;
            pauseScreen.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            paused = false;
            pauseScreen.SetActive(false);
        }
    }

    public void ReturnToMenu()
    {      
        SceneManager.LoadScene(sceneName: "MainMenu");
    }
}
