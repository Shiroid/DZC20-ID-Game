using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlexDialoguer : Dialoguer
{
    public Interactor onDown;
    public Interactor onUp;
    public string text;
    public Interactor onEnd;

    public override void doInteraction()
    {
        Globals.startDialog(text, this);
    }

    public override void doPassive()
    {
        if (Globals.currentDialog == this && Globals.isTalkMode())
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if(onDown) onDown.doInteraction();
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if(onUp) onUp.doInteraction();
            }
            if (Globals.requestDialog)
            {
                Globals.endDialog();
                if (deactivateOnEnd) gameObject.SetActive(false);
                if (onSucceed)
                {
                    if (onSucceed.isActiveAndEnabled) onSucceed.doInteraction();
                    else if (onFail) onFail.doInteraction();
                }
            }
        }
    }
}
