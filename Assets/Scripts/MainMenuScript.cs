using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MainMenuScript : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject scores;
    public GameObject credits;
    public GameObject active;
    public GameObject settings;

    public InputField nameinput;
    public Text namesaved;

    GameData data;

    void Start()
    {
        active = mainMenu;
        data = new GameData();
    }

    public void PressPlay()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName: "Game");
    }

    public void PressScores()
    {
        MenuSwitch(scores);
        scores.SendMessage("UpdateScoreboard");
    }

    public void PressCredits()
    {
        MenuSwitch(credits);
    }

    public void PressSettings()
    {
        data.LoadData();
        namesaved.text = data.player;
        MenuSwitch(settings);
    }

    public void PressExit()
    {
        Application.Quit();
    }

    public void PressReturn()
    {
        MenuSwitch(mainMenu);
    }

    void MenuSwitch(GameObject o)
    {
        active.SetActive(false);
        active = o;
        active.SetActive(true);
    }

    public void ConfirmNameChange()
    {
        namesaved.text = nameinput.text;
        data.player = nameinput.text;
        nameinput.text = null;
        data.SaveData(data);
    }
}

[Serializable]
public class GameData
{
    public string player;
    public string[] top10;

    public void SaveData(GameData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream fl = File.Create(Application.persistentDataPath + "/data.dat");
        bf.Serialize(fl, data);
        fl.Close();
    }

    public void LoadData()
    {
        if (File.Exists(Application.persistentDataPath + "/data.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fl = File.Open(Application.persistentDataPath + "/data.dat", FileMode.Open);
            GameData data = (GameData)bf.Deserialize(fl);
            fl.Close();
            this.player = data.player;
            this.top10 = data.top10;
        }
        else
        {
            this.player = "Player";
            this.top10 = new String[] { "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0", "- 0"};
        }
    }
}

