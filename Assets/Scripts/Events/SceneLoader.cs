using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : Interactor {

    public string nextScene;

    public override void doInteraction(GameObject intPlayer)
    {
        SceneManager.LoadScene(nextScene);
    }

    public override void doPassive()
    {
    }
}
