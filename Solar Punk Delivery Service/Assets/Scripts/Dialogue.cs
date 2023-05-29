using System;

[Serializable]
public class Dialogue
{
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
