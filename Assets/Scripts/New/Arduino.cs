using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

//Arduino communication class, if the arduino fails to connect, it defaults to number keys as input instead.
public class Arduino : MonoBehaviour {
    
    private bool useArduino = true;

    private SerialPort sp;
	// Use this for initialization
	void Start () {

        useArduino = false;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Globals.arduinoPort != "" && useArduino == false)
        {
            try
            {
                sp = new SerialPort(Globals.arduinoPort, 9600);
                sp.Open();
                sp.ReadTimeout = 1;
                useArduino = true;
            }
            catch (System.Exception e)
            {
                useArduino = false;
                Globals.arduinoPort = "";
            }
        }
        if (useArduino)
        {
            if (sp.IsOpen)
                try
                {
                    Globals.towerLock = sp.ReadByte();
                }
                catch (System.Exception e)
                {

                }
        }
        else
        {
            Globals.towerLock = 0;
            if (Input.GetKey(KeyCode.Alpha1)) Globals.towerLock = 1;
            if (Input.GetKey(KeyCode.Alpha2)) Globals.towerLock = 2;
            if (Input.GetKey(KeyCode.Alpha3)) Globals.towerLock = 3;
            if (Input.GetKey(KeyCode.Alpha4)) Globals.towerLock = 4;
        }
    }
}
