using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeader : MonoBehaviour
{

    public GameObject camera;

    // Late update is called once per frame
    void LateUpdate()
    {
        camera.transform.position = new Vector3(transform.position.x, transform.position.y, camera.transform.position.z);
    }
}
