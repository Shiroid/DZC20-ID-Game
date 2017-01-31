using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactor  {
    public override void doInteraction(GameObject intPlayer)
    {
        interactingPlayer.transform.position = transform.position;
        if (onSucceed) onSucceed.doInteraction(interactingPlayer);
    }

    public override void doPassive()
    {

    }
}
