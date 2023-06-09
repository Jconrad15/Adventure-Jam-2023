using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Companion : MonoBehaviour
{
    private PlayerController playerController;
    private Vector2 previousPlayerPosition;

    private float speed = 3f;

    private void Start()
    {
        playerController = FindAnyObjectByType<PlayerController>();
        playerController.RegisterOnPlayerStartMove(OnPlayerStartMove);
        previousPlayerPosition = playerController.transform.position;
    }

    private void OnPlayerStartMove(Vector2 newPlayerPosition)
    {
        StartCoroutine(LerpMove(previousPlayerPosition));
        previousPlayerPosition = newPlayerPosition;
    }

    private IEnumerator LerpMove(Vector2 targetPos)
    {
        Vector2 startPos = transform.position;
        float timer = 0f;

        while (timer <= 1f)
        {
            transform.position = Vector2.Lerp(
                startPos, targetPos, timer);
            timer += Time.deltaTime * speed;
            yield return new WaitForEndOfFrame();
        }

        transform.position = targetPos;
    }

}
