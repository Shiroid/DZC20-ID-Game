using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asker : Dialoguer
{
    public int numPieces; //At most 4
    private int currentPiece = 0;
    public string[] pieces = new string[Globals.numDialogOptions];
    public Interactor[] onEnd = new Interactor[Globals.numDialogOptions];

    public override void doInteraction()
    {
        Globals.currentDialog = this;
        Globals.startDialog(pieces[currentPiece], this);
    }

    public override void doPassive()
    {
        if (Globals.currentDialog == this && Globals.isTalkMode())
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                currentPiece = (currentPiece+1)%Math.Min(numPieces, Globals.numDialogOptions);
                Globals.pendingDialog = pieces[currentPiece];
                Globals.advanceDialog = true;
            }
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                currentPiece = (currentPiece + Math.Min(numPieces, Globals.numDialogOptions) -1) % Math.Min(numPieces, Globals.numDialogOptions);
                Globals.pendingDialog = pieces[currentPiece];
                Globals.advanceDialog = true;
            }
            if (Globals.requestDialog)
            {
                Globals.endDialog();
                if (onEnd[currentPiece])
                {
                    if (onEnd[currentPiece].isActiveAndEnabled) onEnd[currentPiece].doInteraction();
                    else if (onFail) onFail.doInteraction();
                }
            }
        }
    }
}
