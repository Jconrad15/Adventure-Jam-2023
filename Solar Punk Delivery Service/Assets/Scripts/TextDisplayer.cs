using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplayer : MonoBehaviour
{
    [SerializeField]
    private GameObject textBox;
    [SerializeField]
    private TextMeshProUGUI textArea;
    [SerializeField]
    private float delay = 0.05f;

    private string testText = "Hello, this is some text!";

    private void Start()
    {
        textBox.SetActive(false);
    }

    // For testing
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ShowText(testText);
        }
    }

    public void ShowText(string text)
    {
        textBox.SetActive(true);

        // Need to parse text into characters
        char[] characters = text.ToCharArray();
        // Add characters one at a time
        StartCoroutine(ShowCharacters(characters));
    }

    private IEnumerator ShowCharacters(char[] characters)
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
