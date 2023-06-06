using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField]
    private string characterName;
    [SerializeField]
    private Dialogue normalDialogue;
    [SerializeField]
    private Dialogue thankfulDialogue;
    [SerializeField]
    private Color color;
    [SerializeField]
    private Sprite closeUpImage;
    [SerializeField]
    private AudioClip voice;

    [SerializeField]
    private Potion requestedPotion;

    private bool receivedPotion = false;

    private float talkTimer = 0f;
    private readonly float talkMaxTime = 0.5f;

    private void Update()
    {
        talkTimer += Time.deltaTime;
    }

    public void Talk()
    {
        // Check if player has the requested potion
        // if the player does not, play normal dialogue
        // if the player does, play thankful dialogue

        if (talkTimer < talkMaxTime)
        {
            return;
        }
        talkTimer = 0f;

        string text;
        if (Inventory.Instance.TryGivePotion(requestedPotion) ||
            receivedPotion)
        {
            receivedPotion = true;
            text = thankfulDialogue.GetNextText();
        }
        else
        {
            text = normalDialogue.GetNextText();
        }

        FindObjectOfType<TextDisplayer>().ShowDialogue(text, this);
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
