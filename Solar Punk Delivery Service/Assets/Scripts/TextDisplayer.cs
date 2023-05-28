using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class TextDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject textBox;
    [SerializeField]
    private TextMeshProUGUI textArea;

    [SerializeField]
    private Image npcCloseUpImage;

    [SerializeField]
    private Image playerCloseUpImage;
    [SerializeField]
    private Sprite playerCloseUpSprite;

    [SerializeField]
    private float delay = 0.05f;

    private void Start()
    {
        textBox.SetActive(false);
        playerCloseUpImage.sprite = playerCloseUpSprite;
    }

    public void HideText()
    {
        textBox.SetActive(false);
    }

    public void ShowDialogue(string text, Sprite npc)
    {
        textBox.SetActive(true);
        npcCloseUpImage.sprite = npc;
        
        // Need to parse text into characters
        char[] characters = text.ToCharArray();
        // Add characters one at a time
        _ = StartCoroutine(ShowChars(characters));
    }

    private IEnumerator ShowChars(char[] characters)
    {
        string text = null;
        for (int i = 0; i < characters.Length; i++)
        {
            text += characters[i];
            textArea.SetText(text);

            yield return new WaitForSeconds(delay);
        }

    }

}
