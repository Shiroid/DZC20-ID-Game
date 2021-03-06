﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuPositioner : MonoBehaviour {

    //Dictates which of the three menus is currently operating
    //0: Map, 1: Pause, 2: Dialog
    public int currentMenu;

    public float turnSpeed;

    private int numMenus = 3;
    private float round = 360;

    private int lastMode = Globals.getMoveMode();

    // Update is called once per frame
    void Update() {

        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Globals.isPauseMode())
                Globals.setMode(lastMode);
            else
            {
                lastMode = Globals.getMode();
                Globals.setPauseMode();
            }
        }
        currentMenu = Globals.getMode();

        float desiredRot = (((float)currentMenu) * round / numMenus);
        Vector3 angles = transform.localEulerAngles;
        float currentRot = angles.x;
        //Adjust for euler angle protocol, breaks down if anything other than x is rotated!
        if (angles.y == round/2) currentRot = (3*round/2 - currentRot) % round;
        if (currentRot != desiredRot)
        {
            if ((desiredRot + round - currentRot)%round > round / 2)
                transform.Rotate(new Vector3(-Mathf.Min(turnSpeed * Time.deltaTime, Mathf.Abs(desiredRot - currentRot)), 0, 0));
            else transform.Rotate(new Vector3(Mathf.Min(turnSpeed * Time.deltaTime, Mathf.Abs(desiredRot - currentRot)), 0, 0));
        }
    }

    public void showDialog()
    {
        currentMenu = 2;
    }

    public void showPause()
    {
        currentMenu = 1;
    }

    public void showMap()
    {
        currentMenu = 0;
    }
}
