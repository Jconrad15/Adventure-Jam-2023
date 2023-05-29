using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string characterName;
    [SerializeField]
    private Dialogue dialogue;
    [SerializeField]
    private Color color;
    [SerializeField]
    private Sprite closeUpImage;
    [SerializeField]
    private Sprite topDownImage;
    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    private Potion requestedPotion;

    public void Talk()
    {
        string text = dialogue.GetNextText();

        FindObjectOfType<TextDisplayer>()
            .ShowDialogue(text, this);
    }

    public Sprite GetCloseUpImage()
    {
        return closeUpImage;
    }

    public string GetCharacterName()
    {
        return characterName;
    }

    public Color GetColor()
    {
        return color;
    }
}
