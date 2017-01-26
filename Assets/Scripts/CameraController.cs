using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public GameObject player;

    private Vector3 offset = new Vector3(0,0,-10);

    // Use this for initialization
    void Start()
    {
        //offset = transform.position - player.transform.position;
    }

    // Late update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }
}
