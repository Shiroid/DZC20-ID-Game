using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoChecker : Interactor {

    public Interactor[] circuits = new Interactor[5];
    private bool inRange = false;

    public override void doInteraction(GameObject intPlayer)
    {
        if(isAssertive) inRange = true;
        else if (circuits[Globals.towerLock]) circuits[Globals.towerLock].doInteraction(null);
    }

    public override void doPassive()
    {
        if (inRange)
        {
            if(circuits[Globals.towerLock]) circuits[Globals.towerLock].doInteraction(null);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isAssertive)
        {
            inRange = false;
        }
    }
}
