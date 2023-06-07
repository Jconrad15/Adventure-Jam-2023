using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeToBlack : MonoBehaviour
{
    [SerializeField]
    private Image image;
    [SerializeField]
    private CanvasGroup canvasGroup;

    private float fadeFrameCount = 300f;
    private float holdBlackFrameCount = 600f;

    private Action cbOnWakeUp;

    private void Start()
    {
        Hide();
    }

    private void Hide()
    {
        image.gameObject.SetActive(false);
        canvasGroup.alpha = 0;
        canvasGroup.interactable = false;
        canvasGroup.blocksRaycasts = false;
    }

    public void StartFade()
    {
        StopAllCoroutines();
        StartCoroutine(Fade());
    }

    private IEnumerator Fade()
    {
        PlayerController pc = FindAnyObjectByType<PlayerController>();
        pc.DisableMovement();

        image.gameObject.SetActive(true);

        for (int i = 0; i < fadeFrameCount; i++)
        {
            float t = i / fadeFrameCount;
            float alpha = Mathf.Lerp(0, 1, t);

            canvasGroup.alpha = alpha;
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < holdBlackFrameCount; i++)
        {
            yield return new WaitForEndOfFrame();
        }

        for (int i = 0; i < fadeFrameCount; i++)
        {
            float t = i / fadeFrameCount;
            float alpha = Mathf.Lerp(1, 0, t);

            canvasGroup.alpha = alpha;
            yield return new WaitForEndOfFrame();
        }

        Hide();

        pc.EnableMovement();
        cbOnWakeUp?.Invoke();
    }

    public void RegisterOnWakeUp(Action callbackfunc)
    {
        cbOnWakeUp += callbackfunc;
    }

    public void UnregisterOnWakeUp(Action callbackfunc)
    {
        cbOnWakeUp -= callbackfunc;
    }
}
