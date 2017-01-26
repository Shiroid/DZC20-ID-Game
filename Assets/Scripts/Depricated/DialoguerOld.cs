using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Depricated Dialoguer, do not use!
public class DialoguerOld : Interactor
{

    // All arrays must be of equal length!!!
    private int currentDialogue; //Finish when -1
    public string[] pieces;
    public int[] nextPieces;
    // Piece on up or down must be -1 if no question
    public int[] pieceOnUp;
    public int[] pieceOnDown;
    public Interactor[] onEnd;

    public override void doInteraction()
    {
        currentDialogue = 0;
        //Globals.currentDialog = this;
        //Globals.startDialog(pieces[currentDialogue], this);
    }

    public override void doPassive()
    {
        if (Globals.currentDialog == this)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow) && pieceOnDown[currentDialogue] > -1)
            {
                currentDialogue = pieceOnDown[currentDialogue];
                Globals.advanceDialog = true;
                Globals.pendingDialog = pieces[currentDialogue];
            }
            if (Input.GetKeyDown(KeyCode.UpArrow) && pieceOnUp[currentDialogue] > -1)
            {
                currentDialogue = pieceOnUp[currentDialogue];
                Globals.advanceDialog = true;
                Globals.pendingDialog = pieces[currentDialogue];
            }
            if (Globals.requestDialog)
            {
                int last = currentDialogue;
                currentDialogue = nextPieces[currentDialogue];
                if (currentDialogue > -1)
                {
                    //Globals.startDialog(pieces[currentDialogue], this);
                }
                else
                {
                    Globals.endDialog();
                    if (onEnd[last])
                    {
                        if (onEnd[last].isActiveAndEnabled) onEnd[last].doInteraction();
                        else if (onFail) onFail.doInteraction();
                    }
                }
            }
        }

    }
}
