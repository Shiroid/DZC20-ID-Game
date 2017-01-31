using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public GameObject player;
    public GameObject focusY;
    public GameObject[] farObjects;

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
        useFar(false);
        for (int i = 0; i < farObjects.Length; i++) if (player.Equals(farObjects[i])) useFar(true);

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, 0) + offset;
        if (focusY)
            transform.position = new Vector3(player.transform.position.x, focusY.transform.position.y, 0) + offset;
    }

    public void useFar(bool b) { if (b) offset = farOffset; else offset = closeOffset; }
}
