using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Referencer : Interactor {
    public override void doInteraction()
    {
        onSucceed.doInteraction();
    }

    public override void doPassive()
    {
    }
}
