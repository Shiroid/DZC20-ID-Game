using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapper : MonoBehaviour {

    public GameObject enteringPlayer;
    public GameObject exitingPlayer;
    public GameObject camera;

    private bool canInteract;

    void Start()
    {
        canInteract = false;
    }

    void Update()
    {
        if (canInteract && Input.GetKey("space"))
        {
            enteringPlayer.SetActive(false);
            exitingPlayer.SetActive(true);
            camera.GetComponent<CameraController>().player = exitingPlayer;
        }
        canInteract = false;
    }

    void OnTriggerStay2D(Collider2D other)
    { 
        if (other.gameObject.Equals(enteringPlayer))
        {
            canInteract = true;
        }
    }
}
