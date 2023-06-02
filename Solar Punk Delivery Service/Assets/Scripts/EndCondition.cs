using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndCondition : MonoBehaviour
{
    [SerializeField]
    private GameObject endScreen;

    [SerializeField]
    private float displayTime = 2f;

    private void Start()
    {
        endScreen.SetActive(false);
        NarrativeEvents.Instance.RegisterOnGivePotion(TriggerEnd, 4);
    }

    private void TriggerEnd()
    {
        _ = StartCoroutine(DelaySwitchToCredits());
    }

    private IEnumerator DelaySwitchToCredits()
    {
        yield return new WaitForSeconds(3f);

        FindAnyObjectByType<PlayerController>().DisableMovement();
        endScreen.SetActive(true);

        yield return new WaitForSeconds(displayTime);
        FindAnyObjectByType<SceneChanger>().LoadCredits();
    }

}
