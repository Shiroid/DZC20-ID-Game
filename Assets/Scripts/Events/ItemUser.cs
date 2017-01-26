using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUser : Interactor {


    public bool[] neededItems = new bool[Globals.getNumItems()];
    public int neededArduinoInput;

    public override void doInteraction()
    {
        bool success = true;
        for(int i = 0; i < neededItems.Length; i++)
        {
            if (neededItems[i] && !Globals.haveItem(i)) success = false;
        }
        if (success) if(onSucceed) onSucceed.doInteraction();
        else if(onFail) onFail.doInteraction();
    }

    public override void doPassive()
    {
        //Do Nothing
    }
}
