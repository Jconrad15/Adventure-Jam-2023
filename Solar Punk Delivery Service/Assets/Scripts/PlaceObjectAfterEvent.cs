using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceObjectAfterEvent : MonoBehaviour
{

    [SerializeField]
    [Range(0, 4)]
    private int potionEventNumber;

    [SerializeField]
    private GameObject prefabToPlace;

    private void Start()
    {
        NarrativeEvents.Instance.RegisterOnSleepAfterGivePotion(
            PlaceGameObject, potionEventNumber);
    }

    private void PlaceGameObject()
    {
        Instantiate(prefabToPlace, transform.position, transform.rotation);
    }

}
