using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollParallax : MonoBehaviour {

    public GameObject cameraFocus;
    public float distanceMultiplier;

    private Vector3 basePosition;

	// Use this for initialization
	void Start () {
        basePosition = transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 focusPos = cameraFocus.transform.position;
        if(distanceMultiplier > 1)
            transform.position = (basePosition + focusPos*(distanceMultiplier-1))/distanceMultiplier;
	}
}
