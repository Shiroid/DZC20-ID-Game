using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
    
    public GameObject player;

    private Vector3 offset = new Vector3(0, 0, -10);
    private Vector3 closeOffset = new Vector3(0, 0, -10);
    private Vector3 farOffset = new Vector3(0, 1.5f, -10);

    // Use this for initialization
    void Start()
    {
        //offset = transform.position - player.transform.position;
        offset = farOffset;
    }

    // Late update is called once per frame
    void LateUpdate()
    {
        transform.position = player.transform.position + offset;
    }

    public void useFar(bool b) { if (b) offset = farOffset; else offset = closeOffset; }
}
