using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talker : Dialoguer
{
    public string text;

    public override void doInteraction(GameObject intPlayer)
    {
        Globals.startDialog(text, this);
    }

    public override void doPassive()
    {
        if (Globals.currentDialog == this && Globals.isTalkMode())
        {
            if (Globals.requestDialog)
            {
                Globals.endDialog();
                if (deactivateOnEnd) gameObject.SetActive(false);
                if (onSucceed)
                {
                    if (onSucceed.isActiveAndEnabled) onSucceed.doInteraction(interactingPlayer);
                    else if (onFail) onFail.doInteraction(interactingPlayer);
                }
            }
        }
    }
}
