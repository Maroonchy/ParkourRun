using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Rigidbody rg;
    Animator an;
    CapsuleCollider cl;
    public bool isGrounded = true;
    int jumpFatigue = 0;
    bool gDetection = true;
    bool isAtomic = false;

    float distToGround;

    public float jumpStrength = 15000f;
    public float speedIncr = 1000f;
    public float maxSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody>();
        an = GetComponent<Animator>();
        cl = GetComponent<CapsuleCollider>();
        rg.AddForce(new Vector3(0, 0, maxSpeed));
        distToGround = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GroundedRC())
        {
            if (!isAtomic)
            {
                if (Input.GetButtonDown("Jump"))
                {
                    Jump();
                }

                if (Input.GetKeyDown(KeyCode.LeftShift))
                {
                    Roll();
                }
            }

            if (rg.velocity.z < maxSpeed)
            {
                rg.AddForce(new Vector3(0, 0, speedIncr));
            }
        }
        
        if (jumpFatigue > 0)
        {
            jumpFatigue--;
        }

        if (Input.GetKey(KeyCode.X))
        {
            transform.position = new Vector3(0, 11.25f, 0);
        }

        if (gameObject.transform.position.y < 0)
        {
            transform.position = new Vector3(0, 0.01f, transform.position.z);
            GameOver();
        }
    }

    public void RollTrue()
    {
        an.applyRootMotion = true;
        rg.isKinematic = true;
        cl.height = 0.82f;
    }

    public void RollFalse()
    {
        an.applyRootMotion = false;
        rg.isKinematic = false;
        cl.height = 2.15f;
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        GameObject.Find("Score").transform.GetChild(0).SendMessage("SendScore");
    }

    bool GroundedRC()
    {
        bool grc = Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.15f);

        if (!isGrounded)
        {
            if (grc)
            {
                isGrounded = true;
                an.CrossFade("metarig_Run", 0.1f, -1);
            }
        }
        else
        {
            if (!grc)
            {
                isGrounded = false;
            }
        }

        return grc;
    }

    void Jump()
    {
        if (jumpFatigue == 0)
        {
            rg.AddForce(new Vector3(0, jumpStrength, 0));
            an.CrossFade("metarig_Jump", 0.1f, -1);
            jumpFatigue = 5;
        }
    }

    void Roll()
    {
        if (gDetection)
        {
            RollTrue();
            an.CrossFade("metarig_Roll", 0.1f, -1);
        }
    }

    void RotationCleanUp()
    {
        transform.rotation = new Quaternion(0, 0, 0, 0);
    }

    public void Atomizer(bool b)
    {
        isAtomic = b;
    }
}
