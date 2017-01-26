using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.IO.Ports;

public class Arduino : MonoBehaviour {
	
	private SerialPort sp;
	public int towerLock = 0;
	// Use this for initialization
	void Start () {
		
		sp = new SerialPort(MainController.port, 9600);
		sp.Open();
		sp.ReadTimeout = 1;
		
	}
	
	// Update is called once per frame
	void Update () {
		if (sp.ReadByte == 1 || 2 || 3 || 4) {
			towerLock = 1
		} 
		else { towerLock = 0
			
	
		
	}
}
