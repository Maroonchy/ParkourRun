using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RollButtonScript : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SendRollMessage()
    {
        player.SendMessage("Roll");
    }
}
