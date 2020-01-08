using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardManager : MonoBehaviour
{
    public Text[] names;
    public Text[] scores;

    void UpdateScoreboard()
    {
        GameData data = new GameData();
        data.LoadData();

        for (int i = 0; i < 10; i++)
        {
            names[i].text = data.top10[i].Split(' ')[0];
            scores[i].text = data.top10[i].Split(' ')[1];
        }
    }
}
