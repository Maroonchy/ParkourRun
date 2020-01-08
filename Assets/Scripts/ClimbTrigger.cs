using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbTrigger : MonoBehaviour
{
    public bool activated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "ClimbRoot" && !activated)
        {
            GameObject.FindGameObjectsWithTag("Player")[0].SendMessage("Climbing", transform);
        }
    }
}
