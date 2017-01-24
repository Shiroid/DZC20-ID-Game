using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapper : Interactor {
    
    public GameObject newPlayer;
    public Camera mainCamera;

    override
    public void doInteraction()
    {
        interactingPlayer.SetActive(false);
        newPlayer.SetActive(true);
        mainCamera.GetComponent<CameraController>().player = newPlayer;
    }

    override
    public void doPassive()
    {

    }
}
