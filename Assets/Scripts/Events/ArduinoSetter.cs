using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArduinoSetter : Interactor
{
    string port; 
    public override void doInteraction()
    {
        Globals.arduinoPort = port;
    }

    public override void doPassive()
    {
    }
}
