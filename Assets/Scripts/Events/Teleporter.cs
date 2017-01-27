using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : Interactor  {
    public override void doInteraction()
    {
        interactingPlayer.transform.position = transform.position;
        if (onSucceed) onSucceed.doInteraction();
    }

    public override void doPassive()
    {

    }
}
