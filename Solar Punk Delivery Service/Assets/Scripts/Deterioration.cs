using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deterioration : MonoBehaviour
{
    [SerializeField]
    [Range(0, 4)]
    private int potionEventNumber;

    [SerializeField]
    private Sprite deterioratedSprite;

    private SpriteRenderer sr;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();

        NarrativeEvents.Instance.RegisterOnGivePotion(
            Deteriorate, potionEventNumber);
    }

    private void Deteriorate()
    {
        sr.sprite = deterioratedSprite;
    }

}
