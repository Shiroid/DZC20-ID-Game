using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {

    public GameObject[] items = new GameObject[Globals.getNumItems()];
    public GameObject[] itemIcons = new GameObject[Globals.getNumItems()];

	// Use this for initialization
	void Start () {
        Globals.initItems();
	}
	
	// Update is called once per frame
	void Update () {
		for(int i = 0; i < items.Length; i++)
        {
            items[i].SetActive(!Globals.haveItem(i));
            itemIcons[i].SetActive(Globals.haveItem(i));
        }
	}
}
