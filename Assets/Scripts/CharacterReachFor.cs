using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterReachFor : MonoBehaviour
{
    public bool activated = false;
    private void OnTriggerEnter(Collider other)
    {
        if (!activated)
        {
            GameObject.Find("Player").GetComponent<Animator>().CrossFade("metarig_Reach", 0.5f, -1);
            activated = true;
        }
    }
}
