using System;
using UnityEngine;

[Serializable]
public class Dialogue
{
    [TextArea(3, 10)]
    public string[] text;

    private int current = 0;

    public string GetNextText()
    {
        if (current >= text.Length) { current = 0; }

        string nextText = text[current];
        current++;
        return nextText;
    }
}
