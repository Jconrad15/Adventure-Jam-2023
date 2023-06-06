using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerComment : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI commentText;

    [SerializeField]
    private GameObject playerComments;

    [TextArea(3, 10)]
    public string onGivePotionText;

    private readonly float showTextTimeLength = 4f;
    private readonly float showTimeDelay = 4f;

    private void Start()
    {
        playerComments.SetActive(false);
        NarrativeEvents.Instance.RegisterOnGivePotion(OnGivePotion);
    }

    private void OnGivePotion()
    {
        StartCoroutine(ShowText(onGivePotionText));
    }

    private IEnumerator ShowText(string text)
    {
        yield return new WaitForSeconds(showTimeDelay);

        playerComments.SetActive(true);
        commentText.SetText(text);
        StartCoroutine(Clear());
    }

    private IEnumerator Clear()
    {
        yield return new WaitForSeconds(showTextTimeLength);
        playerComments.SetActive(false);
    }

}
