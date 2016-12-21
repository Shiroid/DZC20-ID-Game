using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetTextTest : MonoBehaviour {

    public GameObject dialog;

	// Use this for initialization
	void Start () {
        print(dialog.GetComponent<ForceTextBox>().setText("a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a a \n test \n test \n test \n test \n test"));
    }
	
	// Update is called once per frame
	void Update ()
    {

    }
}
