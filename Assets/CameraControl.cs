using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    Transform playerTF;
    public float distance;

    // Start is called before the first frame update
    void Start()
    {
        playerTF = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = playerTF.position + new Vector3(-distance, distance, -distance);
    }
}
