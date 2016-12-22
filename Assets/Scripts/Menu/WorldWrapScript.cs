using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldWrapScript : MonoBehaviour {

    public GameObject[] wrapees;
    //Whether or not dimensions should be wrapped
    public bool wrapHorizontal;
    public bool wrapVertical;
    //Dimensions of the world
    public float worldHeight;
    public float worldWidth;
    //Center coordinates of the world
    public float worldCenterX;
    public float worldCenterY;
	
	// Update is called once per frame
	void Update () {
		for (int i = wrapees.Length-1; i >= 0; i--)
        {
            if (wrapHorizontal)
            {
                if (wrapees[i].transform.position.x > worldCenterX + 0.5f * worldWidth) wrapees[i].transform.Translate(new Vector3(-worldWidth, 0, 0), Space.World);
                if (wrapees[i].transform.position.x < worldCenterX - 0.5f * worldWidth) wrapees[i].transform.Translate(new Vector3(worldWidth, 0, 0), Space.World);
            }
            if (wrapVertical)
            {
                if (wrapees[i].transform.position.y > worldCenterY + 0.5f * worldHeight) wrapees[i].transform.Translate(new Vector3(0,-worldHeight, 0), Space.World);
                if (wrapees[i].transform.position.y < worldCenterY - 0.5f * worldHeight) wrapees[i].transform.Translate(new Vector3(0,worldHeight, 0), Space.World);
            }
        }
	}
}
