using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLeader : MonoBehaviour
{

    public GameObject mainCamera;

    // Late update is called once per frame
    void LateUpdate()
    {
        mainCamera.transform.position = new Vector3(transform.position.x, transform.position.y, mainCamera.transform.position.z);
    }
}
