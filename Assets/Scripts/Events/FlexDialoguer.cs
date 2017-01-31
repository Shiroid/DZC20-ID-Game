using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FlexDialoguer : Dialoguer
{
    public Interactor onDown;
    public Interactor onUp;
    public string text;

    public override void doInteraction(GameObject intPlayer)
    {
        Globals.startDialog(text, this);
    }

    public override void doPassive()
    {
        if (Globals.currentDialog == this && Globals.isTalkMode() && Globals.assertionDelay == 0)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                Globals.DelayAssertion();
                if (onDown) onDown.doInteraction(interactingPlayer);
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                Globals.DelayAssertion();
                if (onUp) onUp.doInteraction(interactingPlayer);
            }
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
