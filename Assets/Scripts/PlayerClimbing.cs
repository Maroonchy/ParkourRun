using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbing : MonoBehaviour
{
    Animator an;
    Rigidbody rg;
    Vector3 offset = new Vector3(0f, -2.35f, -0.26f);

    void Start()
    {
        an = GetComponentsInChildren<Animator>()[0];
        rg = GetComponent<Rigidbody>();
    }

    public void Climbing(Transform gp)
    {
        gameObject.SendMessage("Atomizer", true);
        rg.useGravity = false;
        rg.isKinematic = true;
        transform.position = gp.position + offset;
        an.applyRootMotion = true;
        
        an.CrossFade("metarig_Climb", 0.1f, -1);
        GetComponent<CapsuleCollider>().enabled = false;
    }

    public void PostClimbing()
    {
        rg.useGravity = true;
        rg.isKinematic = false;
        an.applyRootMotion = false;
        GetComponent<CapsuleCollider>().enabled = true;
        gameObject.SendMessage("Atomizer", false);
    }
}
