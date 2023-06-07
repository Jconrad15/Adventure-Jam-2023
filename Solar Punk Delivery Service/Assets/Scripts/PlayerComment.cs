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

    [TextArea(3, 10)]
    public string onWakeUpText;

    private readonly float showTextTimeLength = 4f;

    private void Start()
    {
        playerComments.SetActive(false);
        NarrativeEvents.Instance.RegisterOnGivePotion(OnGivePotion);

        FindAnyObjectByType<FadeToBlack>().RegisterOnWakeUp(OnWakeUp);
    }

    private void OnGivePotion()
    {
        StartCoroutine(ShowText(onGivePotionText, 6f));
    }

    private void OnWakeUp()
    {
        StartCoroutine(ShowText(onWakeUpText, 0.75f));
    }

    private IEnumerator ShowText(string text, float timeDelay)
    {
        yield return new WaitForSeconds(timeDelay);

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
