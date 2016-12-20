using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTextBox : MonoBehaviour {

    public int numlines;
	
	// Update is called once per frame
	void LateUpdate () {
        TextMesh box = GetComponent<TextMesh>();
        string text = box.text;
        string[] lines = text.Split(new[] { '\r', '\n' });
        string newline = System.Environment.NewLine;
        string result = lines[0];
        for(int i = 1; i < numlines; i++)
        {
            if (lines.Length > i) result = result + newline + lines[i];
            else result = result + newline;
        }
        box.text = result;
	}
}
