using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencer : Interactor {
    public override void doInteraction(GameObject intPlayer)
    {
        onSucceed.doInteraction(interactingPlayer);
    }

    public override void doPassive()
    {
    }
}
