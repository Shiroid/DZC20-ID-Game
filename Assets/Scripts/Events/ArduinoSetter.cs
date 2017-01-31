using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoSetter : Interactor
{
    public string port; 
    public override void doInteraction(GameObject intPlayer)
    {
        Globals.arduinoPort = port;
    }

    public override void doPassive()
    {
    }
}
