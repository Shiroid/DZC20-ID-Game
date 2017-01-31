using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainController : MonoBehaviour {

    public GameObject[] worldItems = new GameObject[Globals.getNumItems()];
    public GameObject[] worldItems2 = new GameObject[Globals.getNumItems()];
    public GameObject[] inventoryItems = new GameObject[Globals.getNumItems()];
    public GameObject[] inventoryItems2 = new GameObject[Globals.getNumItems()];

    // Use this for initialization
    void Start () {
        Globals.assertionDelay = 0;
        Globals.initItems();
    }
	
	// Update is called once per frame
	void Update () {
        if (Globals.assertionDelay > 0) Globals.assertionDelay--;
        for(int i = 0; i < Globals.getNumItems(); i++)
        {
            if (worldItems[i]) worldItems[i].SetActive(!Globals.haveItem(i));
            if (worldItems2[i]) worldItems2[i].SetActive(!Globals.haveItem(i));
            if (inventoryItems[i])
            {
                if (Globals.isPauseMode()) 
                    inventoryItems[i].SetActive(Globals.haveItem(i));
                else inventoryItems[i].SetActive(false);
            }
            if (inventoryItems2[i]) inventoryItems2[i].SetActive(Globals.haveItem(i));
        }
	}
}
