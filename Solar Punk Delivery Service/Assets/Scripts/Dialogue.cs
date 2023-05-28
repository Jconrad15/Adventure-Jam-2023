using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Dialogue
{
    public string[] text;

    public int current = 0;

    public string GetNextText()
    {
        if (current >= text.Length) { current = 0; }

        string nextText = text[current];
        current++;
        return nextText;
    }



}
