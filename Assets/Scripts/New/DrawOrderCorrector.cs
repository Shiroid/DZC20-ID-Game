using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawOrderCorrector : MonoBehaviour {
    //Requires the object to have a box collider
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<BoxCollider2D>())
        {
            Debug.Log(transform.position.z);
            transform.position = new Vector3(
            transform.position.x,
            transform.position.y,
            (transform.position.y + GetComponent<BoxCollider2D>().offset.y) / 1000);
        }
	}
}
