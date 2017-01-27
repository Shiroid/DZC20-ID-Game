using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapper : Interactor {
    
    public GameObject newPlayer;
    public GameObject newFocus;
    public Camera mainCamera;

    override
    public void doInteraction()
    {
        interactingPlayer.SetActive(false);
        newPlayer.SetActive(true);
        mainCamera.GetComponent<CameraController>().player = newFocus?newFocus:newPlayer;
    }

    override
    public void doPassive()
    {

    }
}
