using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreCounter : MonoBehaviour
{
    public bool alive = true;
    int multiplier = 18;
    Transform player;
    Text score;
    public Text overScore;

    public GameObject goScreen;
    public GameObject gameUI;

    void Start()
    {
        score = GetComponent<Text>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (alive)
        {
            score.text = GetScore();
        }
    }

    string GetScore()
    {
        string cScore = (Mathf.RoundToInt(player.position.z) * multiplier).ToString();
        int iter = 7 - cScore.Length;
        for (int i = 0; i < iter; i++)
        {
            cScore = 0 + cScore;
        }

        return cScore.ToString();
    }

    public void SendScore()
    {
        alive = false;
        overScore.text = "SCORE: " + score.text;
        
        GameData data = new GameData();
        data.LoadData();
        int finalsc = int.Parse(score.text);

        for (int i = 0; i < 10; i++)
        {
            if (int.Parse(data.top10[i].Split(' ')[1]) < finalsc)
            {
                for (int ii = 8; ii > i; ii--)
                {
                    data.top10[ii + 1] = data.top10[ii];
                }

                data.top10[i] = data.player + " " + finalsc.ToString();
                break;
            }
        }
        data.SaveData(data);

        goScreen.SetActive(true);
        gameUI.SetActive(false);
    }
}
