using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportController : MonoBehaviour {

	public GameObject objecttotp;
	public Transform target;

	// Use this for initialization
	void Start () {
		
	}

	void OnTrigger(Collider other) {
		if (other.gameObject.CompareTag ("Player")) {
			objecttotp.gameObject.transform.position = target.transform.position;
		}
	}
}
