using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditMover : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float startScrollDelay = 1f;
    [SerializeField]
    private float endCreditScreenTime = 35f;

    private float timer = 0f;

    private void Update()
    {
        timer += Time.deltaTime;

        if (timer < startScrollDelay)
        {
            return;
        }
        else if (timer > endCreditScreenTime)
        {
            FindAnyObjectByType<SceneChanger>().LoadMainMenu();
            Destroy(gameObject);
            return;
        }

        Move();
    }

    private void Move()
    {
        Vector3 newPosition = transform.position;
        newPosition.y -= speed * Time.deltaTime;
        transform.position = newPosition;
    }
}
