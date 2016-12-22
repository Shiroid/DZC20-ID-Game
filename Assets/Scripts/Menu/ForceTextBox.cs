using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceTextBox : MonoBehaviour {

    public int numLines;
    public int numCharsInLine;

    private string text;

    public string setText(string t)
    {
        //Split string into lines
        string[] lines = t.Split(new[] { '\r', '\n' });
        //Split lines into words
        string[][] words = new string[lines.Length][];
        //Assign words to 2D array
        for (int i = lines.Length-1; i >= 0; i--)
        {
            words[i] = lines[i].Split(' ');
        }
        //Set text to empty
        text = "";
        //Set return overflow to empty
        string overflow = "";

        //Prepare loop variables and constants
        string newline = System.Environment.NewLine;
        string space = " ";
        int currentLine = 0;
        int currentChar = 0;
        
        //Do word wrap
        for (int i = 0; i < words.Length; i++)
        {
            for (int j = 0; j < words[i].Length; j++)
            {
                if(currentLine < numLines)
                {
                    if(currentChar + words[i][j].Length < numCharsInLine)
                    {
                        //Ignore if word is empty
                        if (words[i][j].Length > 0)
                        {
                            text = text + words[i][j] + space;
                            currentChar += words[i][j].Length + 1;
                        }
                    }
                    else
                    {
                        //Word does not fit on line
                        text = text + newline;
                        currentLine++;
                        currentChar = 0;
                        j--;//Redo this round with the new line
                    }
                }
                else
                {
                    overflow = overflow + words[i][j] + space;
                }
            }
            if (currentLine < numLines)
            {
                if (i < words.Length - 1)
                {
                    if(currentLine < numLines-1) text = text + newline;
                    currentLine++;
                    currentChar = 0;
                }
            }
            else
            {
                if( i < words.Length-1) overflow = overflow + newline;
            }
        }
        //Pad out textbox
        while (currentLine < numLines-1)
        {
            text = text + newline;
            currentLine++;
        }

        //Set the text into the textbox
        TextMesh box = GetComponent<TextMesh>();
        box.text = text;

        return overflow;
    }
}
