using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSwapper : Interactor {
    
    public GameObject newPlayer;
    public GameObject newFocus;
    public GameObject newFocusY;
    public Camera mainCamera;

    override
    public void doInteraction(GameObject intPlayer)
    {
        interactingPlayer.SetActive(false);
        newPlayer.SetActive(true);
        mainCamera.GetComponent<CameraController>().player = newFocus ? newFocus : newPlayer;
        mainCamera.GetComponent<CameraController>().focusY = newFocusY ? newFocusY : null;
    }

    override
    public void doPassive()
    {

    }
}
