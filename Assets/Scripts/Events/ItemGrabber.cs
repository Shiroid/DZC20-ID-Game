using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrabber : Interactor {

    public int item;

    public override void doInteraction()
    {
        Globals.findItem(item);
        if (onSucceed) onSucceed.doInteraction();
    }

    public override void doPassive()
    {
        //Do Nothing
    }
}
