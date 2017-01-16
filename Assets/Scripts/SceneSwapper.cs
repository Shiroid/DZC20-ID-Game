using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapper : MonoBehaviour {

    public GameObject enteringPlayer;
    public GameObject exitingPlayer;
    public GameObject camera;

    void OnTriggerStay2D(Collider2D other)
    {
        //Check the provided Collider2D parameter other to see if it is tagged "PickUp", if it is...
        if (other.gameObject.Equals(enteringPlayer))
        {
            enteringPlayer.SetActive(false);
            exitingPlayer.SetActive(true);
            camera.GetComponent<CameraController>().player = exitingPlayer;
        }
    }
}
