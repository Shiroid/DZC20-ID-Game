using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals {

    public static int numDialogOptions = 4;

    private static int numItems = 9;

    private static bool[] items = new bool[numItems];

    private static int mode = 0;

    public static string pendingDialog;
    public static bool advanceDialog = false;
    public static bool requestDialog = false;
    public static Dialoguer currentDialog;
    public static int towerLock;

    public static void findItem(int itemIndex)
    {
        if (itemIndex < numItems) items[itemIndex] = true; 
    }

    public static void loseItem(int itemIndex)
    {
        if (itemIndex < numItems) items[itemIndex] = false;
    }

    public static bool haveItem(int itemIndex) { return items[itemIndex]; }

    public static void initItems()
    {
        for (int i = 0; i < numItems; i++)
        {
            loseItem(i);
        }
    }

    public static int getMode() { return mode; }
    public static void setMode(int m) { mode = m; }
    public static void setMoveMode() { mode = 0; }
    public static void setTalkMode() { mode = 2; }
    public static void setPauseMode() { mode = 1; }
    public static int getMoveMode() { return 0; }
    public static int getTalkMode() { return 2; }
    public static int getPauseMode() { return 1; }
    public static bool isMoveMode() { return mode == 0; }
    public static bool isTalkMode() { return mode == 2; }
    public static bool isPauseMode() { return mode == 1; }

    public static void startDialog(string s, Dialoguer d)
    {
        pendingDialog = s;
        currentDialog = d;
        advanceDialog = true;
        requestDialog = false;
        setTalkMode();
    }
    public static void endDialog()
    {
        pendingDialog = "";
        currentDialog = null;
        advanceDialog = false;
        requestDialog = false;
        setMoveMode();
    }
    public static bool hasRemainingDialog()
    {
        if(pendingDialog.Replace(" ", "").Replace("\n", "").Replace("\r", "") == "")
        {
            pendingDialog = "";
            return false;
        }
        return true;
    }
    public static void requestNextDialog()
    {
        pendingDialog = "";
        requestDialog = true;
    }

    public static int getNumItems()
    {
        return numItems;
    }
}
