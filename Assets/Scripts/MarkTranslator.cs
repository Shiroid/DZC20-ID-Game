using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTranslator : MonoBehaviour
{
    //Assumes (0,0) is the world center

    public float mapWidth;
    public float mapHeight;

    public float worldWidth;
    public float worldHeight;

    public GameObject worldMarker;
	
	// Update is called once per frame
	void LateUpdate () {
        //Take in-world position
        Vector3 newPos = worldMarker.transform.localPosition;
        //Convert to position on unit square
        newPos.x /= worldWidth;
        newPos.y /= worldHeight;
        newPos.z = 0;
        //Convert to map coordinates
        newPos.x *= mapWidth;
        newPos.y *= mapHeight;
        transform.localPosition = newPos;
    }
}
