using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButtonScript : MonoBehaviour
{
    GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public void SendJumpMessage()
    {
        player.SendMessage("Jump");
    }
}
