using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroller : MonoBehaviour {

    public float vertSpeed;
    public float horSpeed;
	
	// Update is called once per frame
	void Update () {

        transform.Translate(new Vector3(horSpeed, vertSpeed, 0) * Time.deltaTime);
    }
}
