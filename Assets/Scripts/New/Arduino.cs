using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

//Arduino communication class, if the arduino fails to connect, it defaults to number keys as input instead.
public class Arduino : MonoBehaviour {

    public string port;
    private bool useArduino = true;

    private SerialPort sp;
	// Use this for initialization
	void Start () {

        try
        {
            sp = new SerialPort(port, 9600);
            sp.Open();
            sp.ReadTimeout = 1;
        } catch(System.Exception e)
        {
            useArduino = false;
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
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
