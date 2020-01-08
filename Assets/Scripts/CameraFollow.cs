using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform target;
    public Vector3 offset = new Vector3(4.9f, 1.2f, -0.45f);
    public Vector3 rotation = new Vector3(0, -48, 0);

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = target.position + offset;
        transform.rotation = Quaternion.Euler(rotation);
    }
}
