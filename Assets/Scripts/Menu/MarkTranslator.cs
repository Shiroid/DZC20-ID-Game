using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarkTranslator : MonoBehaviour
{
    //Assumes (0,0) is the world center

    public float mapWidth;
    public float mapHeight;

    public GameObject worldMarker;
    public GameObject worldWrapper;

    // Update is called once per frame
    void LateUpdate () {
        //Take in-world position
        Vector3 newPos = worldMarker.transform.position;
        //Convert to position on unit square
        newPos.x -= worldWrapper.GetComponent<WorldWrapScript>().worldCenterX;
        newPos.y -= worldWrapper.GetComponent<WorldWrapScript>().worldCenterY;
        newPos.x /= worldWrapper.GetComponent<WorldWrapScript>().worldWidth;
        newPos.y /= worldWrapper.GetComponent<WorldWrapScript>().worldHeight;
        //Fill in z
        newPos.z = 0;
        //Convert to map coordinates
        newPos.x *= mapWidth;
        newPos.y *= mapHeight;
        transform.localPosition = newPos;
    }
}
