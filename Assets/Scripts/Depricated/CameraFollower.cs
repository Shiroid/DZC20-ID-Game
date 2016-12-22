using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {

    public GameObject camera;

    private Vector3 offset;

	// Use this for initialization
	void Start () {
        offset = transform.position - camera.transform.position;
	}
	
	// Late update is called once per frame
	void LateUpdate () {
        transform.position = camera.transform.position + offset;
	}
}
